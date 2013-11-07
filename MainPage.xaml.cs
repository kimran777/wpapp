using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Discount.Proxies;
using System.Net.NetworkInformation;

namespace Discount
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly DiscountServiceClient wcfService = new DiscountServiceClient();
        public string hash;
        public System.Collections.ObjectModel.ObservableCollection<CProduct> products;
        public System.Collections.ObjectModel.ObservableCollection<CStore> stores { get; set; }
        //Конструктор
        public MainPage()
        {
            InitializeComponent();
            LoadData();
            //DataContext = this;
        }



        public void LoadData()
        {
            using (var db = new DiscountDataContext())
            {
                if (db.DatabaseExists() == false)
                    db.CreateDatabase();
            }

            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("hash"))
            {
                settings.Add("hash", "0");
                settings.Save();
            }
            hash = settings["hash"].ToString();
            if (!settings.Contains("isStoresDownloaded"))
            {
                settings.Add("isStoresDownloaded", false);
                settings.Save();
            }

            wcfService.OpenCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(wcfService_OpenCompleted);
            wcfService.CloseCompleted += new EventHandler<AsyncCompletedEventArgs>(wcfService_CloseCompleted);
            wcfService.getHashCompleted += new EventHandler<getHashCompletedEventArgs>(wcfService_GetHashCompleted);
            wcfService.getDiscountListCompleted += new EventHandler<getDiscountListCompletedEventArgs>(wcfService_GetDiscountListCompleted);
            wcfService.getStoreListCompleted += new EventHandler<getStoreListCompletedEventArgs>(wcfService_GetStoreListCompleted);

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                wcfService.OpenAsync();
            }
            else if ((bool)settings["isStoresDownloaded"])
            {
                loadStoreListFromDB();
                lbStores.ItemsSource = stores;
                progress.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Необходимо интернет-соединение!", "Выход", MessageBoxButton.OK);
                    throw new ExitException();
            }
        }
        
        void wcfService_OpenCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if ((bool)settings["isStoresDownloaded"])
            {
                loadStoreListFromDB();
                wcfService.getHashAsync();
            }
            else
                wcfService.getStoreListAsync();
        }
        void wcfService_CloseCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progress.Visibility = System.Windows.Visibility.Collapsed;
            lbStores.ItemsSource = stores;
        }

        private void loadStoreListFromDB()
        {
            DiscountDataContext db = new DiscountDataContext();

            var lStore = from c in db.Stores select c;

            if (stores == null)
                stores = new System.Collections.ObjectModel.ObservableCollection<CStore>();

            foreach (var store_i in lStore)
            {
                CStore store = new CStore();
                store.storeID = store_i.storeID.ToString();
                store.storeName = store_i.storeName;
                stores.Add(store);
            } 
        }

        void wcfService_GetStoreListCompleted(object sender, getStoreListCompletedEventArgs e)
        {
            stores = e.Result;
            saveDBStoresLocally();
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings["isStoresDownloaded"] = true;
            settings.Save();

            wcfService.getHashAsync();
        }

        void wcfService_GetHashCompleted(object sender, getHashCompletedEventArgs e)
        {
            string hash_ = e.Result;
            if (hash != hash_)
            {
                var settings = IsolatedStorageSettings.ApplicationSettings;
                settings["hash"] = hash_;
                wcfService.getDiscountListAsync("*");
            }
            else
            {
                wcfService.CloseAsync();
            }
        }

        void wcfService_GetDiscountListCompleted(object sender, getDiscountListCompletedEventArgs e)
        {
            products = e.Result;
            saveDBProductsLocally();
            wcfService.CloseAsync();
        }
        private void settingsButton_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
        /*
        private void buttonOkay_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DiscountList.xaml?storeName=окей&id=1", UriKind.Relative));
        }
        */
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void saveDBProductsLocally()
        {

            DiscountDataContext db = new DiscountDataContext();

            var lProducts = from c in db.Products select c;
            foreach (var i in lProducts)
            {
                db.Products.DeleteOnSubmit(i);
            }
            db.SubmitChanges();

            foreach (CProduct prod_i in products)
            {
                var product = new ProductsTable();
                product.productID = prod_i.productID;
                product.productName = prod_i.productName;
                product.storeID = Convert.ToInt32(prod_i.storeID);
                product.discount = Convert.ToInt32(prod_i.discount);
                product.oldPrice = prod_i.oldPrice;
                product.newPrice = prod_i.newPrice;
                product.startDate = prod_i.startDate;
                product.endDate = prod_i.endDate;
                product.imageURL = prod_i.imageURL;
                db.Products.InsertOnSubmit(product);
            }

            db.SubmitChanges();
        }
        private void saveDBStoresLocally()
        {
            DiscountDataContext db = new DiscountDataContext();

            var lStores = from c in db.Stores select c;
            foreach (var i in lStores)
            {
                db.Stores.DeleteOnSubmit(i);
            }
            db.SubmitChanges();

            foreach (CStore store_i in stores)
            {
                var store = new StoresTable();
                store.storeID = Convert.ToInt32(store_i.storeID);
                store.storeName = store_i.storeName;
                db.Stores.InsertOnSubmit(store);
            }
            db.SubmitChanges();
        }

        private void btnStore_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string id = button.Tag.ToString();

            NavigationService.Navigate(new Uri(string.Format("/DiscountList.xaml?id={0}", id), UriKind.RelativeOrAbsolute));
            
        }

        private void updateListButton_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

    }

}