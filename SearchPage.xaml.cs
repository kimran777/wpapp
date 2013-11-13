using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;
using System.Windows.Media;

namespace Discount
{
    public partial class SearchPage : PhoneApplicationPage
    {
        Color currentAccentColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];

        public string defaultSearchString = "Введите запрос";
        public List<ProductsTable> products = new List<ProductsTable>();
        public List<CProductsSearch> searchResult = new List<CProductsSearch>();
        //public List<ProductsTable> searchResultOut = new List<ProductsTable>();
        public List<string> searchWords = new List<string>();
        public string productID;
        public char[] separator = new char[] { ' ' };
        public SearchPage()
        {
            InitializeComponent();
            using (var ctx = new DiscountDataContext())
            {
                products = ctx.Products.ToList();
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void searchString_TextChanged(object sender, TextChangedEventArgs e)
        {
            search(searchString.Text.ToUpper());
        }

        private void search(string searchWord)
        {
            searchWord.Replace(',', ' ');

            searchWords = searchWord.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!string.IsNullOrEmpty(searchWord) && searchWord != defaultSearchString)
            {
                progress.Visibility = System.Windows.Visibility.Visible;
                searchResult.Clear();
                foreach (var product in products)
                {
                    int count = 0;
                    foreach (string str in searchWords)
                    {
                        if (product.productName.ToUpper().Contains(str))
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        CProductsSearch prod = new CProductsSearch(product);
                        prod.priority = count;
                        searchResult.Add(prod);
                    }

                }
                searchResult.Sort((v1, v2) => v2.priority - v1.priority);
                lbProducts.ItemsSource = null;
                lbProducts.ItemsSource = searchResult;
                SolidColorBrush brush = new SolidColorBrush(currentAccentColorHex);
                progress.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void searchString_GotFocus(object sender, RoutedEventArgs e)
        {
            if(searchString.Text == defaultSearchString)
                searchString.Text = "";

        }

        private void searchString_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(searchString.Text))
            {
                searchString.Text = defaultSearchString;
            }
        }


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

        private void buttonProduct_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var button = sender as Button;
            SolidColorBrush brush = new SolidColorBrush(currentAccentColorHex);
            button.Background = brush;
            productID = button.Tag.ToString();
        }


    }

    public class CProductsSearch: ProductsTable
    {
        CProductsSearch() { }
        public CProductsSearch(ProductsTable p_)
        {
            base.discount = p_.discount;
            base.endDate = p_.endDate;
            base.imageURL = p_.imageURL;
            base.newPrice = p_.newPrice;
            base.oldPrice = p_.oldPrice;
            base.productID = p_.productID;
            base.productName = p_.productName;
            base.productType = p_.productType;
            base.productTypeID = p_.productTypeID;
            base.startDate = p_.startDate;
            base.storeID = p_.storeID;
            base.storeName = p_.storeName;
        }
        public int priority = 0;
    }
 
}