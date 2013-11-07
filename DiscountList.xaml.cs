using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.ServiceModel;
using Discount.Proxies;

namespace Discount
{
    public partial class DiscountList : PhoneApplicationPage
    {

        public System.Collections.ObjectModel.ObservableCollection<ProductsTable> products = new System.Collections.ObjectModel.ObservableCollection<ProductsTable>();

        public DiscountList()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            DiscountDataContext db = new DiscountDataContext();
            var lProducts = from c in db.Products where c.storeID == Convert.ToInt32(storeID) select c;
            foreach (var prod_i in lProducts)
            {
                products.Add(prod_i);
            }
            lbProducts.ItemsSource = products;

            progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void InitializeSettings()
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if(settings.Contains("isDownloadImage"))
            {
                isDownloadImage = (bool)settings["isDownloadImage"];
            }
            else
            {
                isDownloadImage = false;
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            lbProducts.SelectedIndex = -1;
            string storeID_;
            NavigationContext.QueryString.TryGetValue("id", out storeID_);
            if (!string.IsNullOrEmpty(storeID_))
            {
                storeID = storeID_;
                DiscountDataContext db = new DiscountDataContext();
                var storeName_ = from c in db.Stores where c.storeID == Convert.ToInt32(storeID) select c;
                storeName = storeName_.First().storeName;
                tbStoreName.Text = storeName;
            }
            else
            {
                MessageBox.Show("Ошибка перехода на страницу: " + storeTitle.Text);
                storeTitle.Text = "ошибка";
            }
        }
        private void lbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbProducts.SelectedIndex >= 0)
            {
                ListBox lb = sender as ListBox;
                ProductsTable pr = lb.SelectedItem as ProductsTable;
                NavigationService.Navigate(new Uri(string.Format("/ProductPage.xaml?idParam={0}&storeNameParam={1}", pr.productID, tbStoreName.Text), UriKind.RelativeOrAbsolute));
            }
        }

        private string storeName { get; set; }
        private string storeID { get; set; }
        private bool isDownloadImage { get; set; }
    }
}