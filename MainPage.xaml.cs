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
using System.Diagnostics;

namespace Discount
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly DiscountServiceClient wcfService = new DiscountServiceClient();
        public string hash;
        public List<CProduct> products = new List<CProduct>();
        public List<CStore> stores = new List<CStore>();
        //Конструктор
        public MainPage()
        {
            InitializeComponent();
            LoadData();
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

            wcfService.getHashCompleted += wcfService_GetHashCompleted;
            wcfService.getDiscountListCompleted += wcfService_GetDiscountListCompleted;
            wcfService.getStoreListCompleted += wcfService_GetStoreListCompleted;

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if ((bool)settings["isStoresDownloaded"])
                {
                    loadStoreListFromDB();
                    wcfService.getHashAsync();
                }
                else
                    wcfService.getStoreListAsync();

            }
            else if ((bool)settings["isStoresDownloaded"])
            {
                loadStoreListFromDB();
                bindingStoreData();
                progress.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Необходимо интернет-соединение!", "Выход", MessageBoxButton.OK);
                    throw new ExitException();
            }
        }
        
        private void loadStoreListFromDB()
        {
            DiscountDataContext db = new DiscountDataContext();

            var lStores = from c in db.Stores
                     select new CStore
                     {
                         storeID = c.storeID,
                         storeName = c.storeName
                     };

            stores = lStores.ToList();
        }

        void wcfService_GetStoreListCompleted(object sender, getStoreListCompletedEventArgs e)
        {
            stores = e.Result.ToList();
            saveDBStoresLocally();
            //loadStoreListFromDB();
            wcfService.getHashAsync();
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings["isStoresDownloaded"] = true;
            settings.Save();

        }


        void wcfService_GetHashCompleted(object sender, getHashCompletedEventArgs e)
        {
            string hash_ = e.Result;
            if (hash != hash_)
            {
                var settings = IsolatedStorageSettings.ApplicationSettings;
                settings["hash"] = hash_;
                wcfService.getDiscountListAsync();
            }
            else
            {
                bindingStoreData();
                progress.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void wcfService_GetDiscountListCompleted(object sender, getDiscountListCompletedEventArgs e)
        {
            products = e.Result.ToList();
            saveDBProductsLocally();
            bindingStoreData();

            progress.Visibility = System.Windows.Visibility.Collapsed;
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

            using (DiscountDataContext db = new DiscountDataContext())
            {

                var lProducts = from c in db.Products
                                select c;

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
                    product.storeID = prod_i.storeID;
                    product.storeName = prod_i.storeName;
                    product.productTypeID = prod_i.productsTypeID;
                    product.productType = prod_i.productsType;
                    product.discount = prod_i.discount;
                    product.oldPrice = prod_i.oldPrice;
                    product.newPrice = prod_i.newPrice;
                    product.startDate = prod_i.startDate;
                    product.endDate = prod_i.endDate;
                    product.imageURL = prod_i.imageURL;
                    db.Products.InsertOnSubmit(product);
                }
                db.SubmitChanges();
            }

            cleanStorage();
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
                store.storeID = store_i.storeID;
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
            progress.Visibility = System.Windows.Visibility.Visible;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                wcfService.getStoreListAsync();
            }
            progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SearchPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void cleanStorage()
        {
            using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string path = "Shared\\Media\\Pictures";
                if (isolatedStorage.DirectoryExists(path))
                {
                    var fileNames = isolatedStorage.GetFileNames(string.Format("{0}\\*.jpg",path)).ToList();
                    foreach (var fileName in fileNames)
                    {
                        Debug.WriteLine(fileName);
                        int indexPoint = fileName.IndexOf(".");
                        string id = fileName.Remove(indexPoint);
                        Debug.WriteLine(id);

                        using (var ctx = new DiscountDataContext())
                        {
                            var product = from c in ctx.Products
                                          where c.productID == id
                                          select c;
                            if (product.Count() == 0)
                            {
                                Debug.WriteLine("deletion");
                                isolatedStorage.DeleteFile(string.Format("{0}\\{1}.jpg", path, id));
                            }
                        }
                    }
                }
            }
        }
        private void bindingStoreData()
        {
            List<CStore> storesLeft = new List<CStore>();
            List<CStore> storesRight = new List<CStore>();
            for (int i = 0; i < stores.Count; i++)
            {
                if((i+1) % 2 == 0)
                    storesRight.Add(stores.ElementAt(i));
                else
                    storesLeft.Add(stores.ElementAt(i));
            }
            lbStoresLeft.ItemsSource = storesLeft;
            lbStoresRight.ItemsSource = storesRight;
        }

        private void buysButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BuysPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }

}