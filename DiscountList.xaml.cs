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
using System.Windows.Media;

namespace Discount
{
    public partial class DiscountList : PhoneApplicationPage
    {
        Color currentAccentColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];

        public List<ProductsTable> products = new List<ProductsTable>();
        string productID;
        public DiscountList()
        {
            InitializeComponent();
            InitializeSettings();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new DiscountDataContext())
            {
                var lProducts = from c in db.Products
                                where c.storeID == storeID
                                orderby c.productTypeID
                                select c;
                products = lProducts.ToList();

                bindingProductData();
            }

        }

        private void InitializeSettings()
        {
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string storeID_;
            NavigationContext.QueryString.TryGetValue("id", out storeID_);
            using (DiscountDataContext db = new DiscountDataContext())
            {
                if (!string.IsNullOrEmpty(storeID_))
                {
                    storeID = Convert.ToInt32(storeID_);
                    var storeName_ = from c in db.Stores where c.storeID == storeID select c;
                    storeName = storeName_.First().storeName;
                    tbStoreName.Text = storeName;
                }
                else
                {
                    MessageBox.Show("Ошибка перехода на страницу: " + storeTitle.Text);
                    storeTitle.Text = "ошибка";
                }
                var settings = IsolatedStorageSettings.ApplicationSettings;
            }
        }

        private void bindingProductData()
        {
            lbProducts.ItemsSource = products;
            progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        private string storeName { get; set; }
        private int storeID { get; set; }
        private bool isDownloadImage { get; set; }


        private void buttonProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string id = button.Tag.ToString();
            NavigationService.Navigate(new Uri(string.Format("/ProductPage.xaml?id={0}", id), UriKind.RelativeOrAbsolute));
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DiscountDataContext())
            {
                var res = from c in db.Buys
                          where c.productID == productID
                          select c;
                if (res.Count() == 0)
                {
                    BuysTable buy = new BuysTable();
                    buy.productID = productID;
                    db.Buys.InsertOnSubmit(buy);
                    db.SubmitChanges();
                }
            }
        }

        private void btnProduct_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var button = sender as Button;
            SolidColorBrush brush = new SolidColorBrush(currentAccentColorHex);
            button.Background = brush;
            productID = button.Tag.ToString();
        }
    }
}