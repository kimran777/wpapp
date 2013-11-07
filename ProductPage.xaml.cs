using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.NetworkInformation;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace Discount
{
    public partial class ProductPage : PhoneApplicationPage
    {
        Color currentAccentColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];
        public ProductPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string productID_;
            string storeName_;
            NavigationContext.QueryString.TryGetValue("idParam", out productID_);
            NavigationContext.QueryString.TryGetValue("storeNameParam", out storeName_);
            if (!string.IsNullOrEmpty(productID_) && !string.IsNullOrEmpty(storeName_))
            {
                productID = Convert.ToInt32(productID_);
                storeName = storeName_;
                tbStoreName.Text = storeName;
                tbID.Text = productID.ToString();
                DiscountDataContext db = new DiscountDataContext();
                var lProduct = from c in db.Products where c.productID == productID.ToString() select c;
                foreach (var prod_i in lProduct)
                {
                    product = prod_i;
                }
                nameFolder = product.productID.Remove(2);
                nameFile = product.productID.Remove(0, 2);

                InitializeSettings();

                tbProductName.Text = product.productName;
                tbOldPrice.Text = product.oldPrice;
                tbNewPrice.Text = product.newPrice;
                tbDiscount.Text = product.discount.ToString();

                tbStartDate.Text = product.startDate;
                tbEndDate.Text = product.endDate;

                SolidColorBrush brush = new SolidColorBrush(currentAccentColorHex);
                tbNewPrice.Foreground = brush;
                tbEndDate.Foreground = brush;
                
                //lbProduct.ItemsSource = product;
            }
        }

        private void InitializeSettings()
        {

            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("isDownloadImage"))
            {
                isDownloadImage = (bool)settings["isDownloadImage"];
            }
            else
            {
                isDownloadImage = false;
            }

   
            if (isFileExistsInIsoStore())
            {
                loadImageFileFromIsoStore();
            }
            else
            {
                if (NetworkInterface.GetIsNetworkAvailable() && isDownloadImage)
                    loadImageFileFromWeb();
                else
                    loadDefaultImage();
            }



        }
        private bool isFileExistsInIsoStore()
        {
            var fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            if(fileStorage.FileExists(string.Format("{0}\\{1}.jpg",nameFolder, nameFile)))
            {
                Debug.WriteLine(string.Format("{0}\\{1}.jpg", nameFolder, nameFile));
                return true;
            }
            else
                return false;
        }
        private void loadImageFileFromIsoStore()
        {
            var bmp = new BitmapImage();
            var fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            Debug.WriteLine(string.Format("{0}\\{1}.jpg", nameFolder, nameFile));
            if( fileStorage.FileExists( string.Format("{0}\\{1}.jpg",nameFolder, nameFile) ) )
            {
                using (var fstream = fileStorage.OpenFile(string.Format("{0}\\{1}.jpg",nameFolder, nameFile),System.IO.FileMode.Open))
                {
                    bmp.SetSource(fstream);
                    imgProductImage.Source = bmp;
                }
            }
        }
        private void loadImageFileFromWeb()
        {
            var uri = new Uri(product.imageURL, UriKind.Absolute);
            var wc = new WebClient();


            var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            wc.OpenReadAsync(uri);
            wc.OpenReadCompleted += (o, args) =>
                {
                    var sourceImage = new BitmapImage();
                    sourceImage.SetSource(args.Result);
                    if (!isolatedStorage.DirectoryExists(nameFolder))
                    {
                        isolatedStorage.CreateDirectory(nameFolder);
                    }
                    using (var fileStream = new IsolatedStorageFileStream(string.Format("{0}\\{1}.jpg", nameFolder, nameFile), System.IO.FileMode.Create, isolatedStorage))
                    {
                        var bitmap = new WriteableBitmap(sourceImage);
                        bitmap.SaveJpeg(fileStream, sourceImage.PixelWidth, sourceImage.PixelHeight, 0, 100);
                        fileStream.Close();
                        loadImageFileFromIsoStore();
                    }
                };

        }
        private void loadDefaultImage()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri("/images/dark/default.png", UriKind.Relative);
            imgProductImage.Source = bitmap;
        }

        private bool isDownloadImage;
        private int productID;
        private ProductsTable product;
        private string storeName;
        private string nameFolder;
        private string nameFile;

    }
}