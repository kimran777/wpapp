using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Diagnostics;

namespace Discount
{
    public partial class BuysPage : PhoneApplicationPage
    {
        List<ProductsTable> buys = new List<ProductsTable>();
        Color currentAccentColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];
        string productID;
        public BuysPage()
        {
            InitializeComponent();
            InitializeSettings();
        }
        private void InitializeSettings()
        {
            progress.Visibility = System.Windows.Visibility.Visible;
            using (var db = new DiscountDataContext())
            {
                buys.Clear();
                List<BuysTable> b = db.Buys.ToList();
                foreach (var buy in b)
                {
                    var product = from c in db.Products
                                  where c.productID == buy.productID
                                  select c;
                    buys.Add(product.First());
                }
            }
            lbBuys.ItemsSource = null;
            lbBuys.ItemsSource = buys;
            progress.Visibility = System.Windows.Visibility.Collapsed;
        }


        private void buttonProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string id = button.Tag.ToString();
            NavigationService.Navigate(new Uri(string.Format("/ProductPage.xaml?id={0}", id), UriKind.RelativeOrAbsolute));
        }

        private void buttonProduct_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var button = sender as Button;
            SolidColorBrush brush = new SolidColorBrush(currentAccentColorHex);
            button.Background = brush;
            productID = button.Tag.ToString();
        }

        private void delProduct_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DiscountDataContext())
            {
                var res = from c in db.Buys
                          where c.productID == productID
                          select c;
                BuysTable buy = res.First();
                //Debug.WriteLine(productID);
                db.Buys.DeleteOnSubmit(buy);
                db.SubmitChanges();
                InitializeSettings();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите очистить список покупок?", "Удаление списка", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                clearBuys();                    
            }
        }
        private void clearBuys()
        {
            using (var db = new DiscountDataContext())
            {
                var res = from c in db.Buys select c;
                foreach (var r in res)
                {
                    db.Buys.DeleteOnSubmit(r);
                }
                db.SubmitChanges();
                InitializeSettings();
            }          
        }
    }
}