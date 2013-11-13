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
using System.Data.Linq;
using System.Threading;

namespace Discount
{
    public partial class ProductPage : PhoneApplicationPage
    {

        private bool isDownloadImage;
        private string productID;
        private ProductsTable product;
        private string storeName;
        private string nameFile;

        public ProductPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string productID_;
            NavigationContext.QueryString.TryGetValue("id", out productID_);
            if (!string.IsNullOrEmpty(productID_) )
            {
                productID = productID_;
                tbID.Text = productID;
                DiscountDataContext db = new DiscountDataContext();
                var lProduct = from c in db.Products where c.productID == productID select c;
                foreach (var prod_i in lProduct)
                {
                    product = prod_i;
                }
                storeName = product.storeName;
                tbStoreName.Text = storeName;

                nameFile = product.productID;

                InitializeSettings();

                tbProductName.Text += product.productName;
                tbOldPrice.Text = product.oldPrice + " р.";
                tbNewPrice.Text = product.newPrice + " р.";
                tbDiscount.Text = product.discount.ToString() + "%";

                tbStartDate.Text = product.startDate;
                tbEndDate.Text = product.endDate;

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
            if (fileStorage.FileExists(string.Format("Shared\\Media\\Pictures\\{0}.jpg", nameFile)))
            {
                Debug.WriteLine(string.Format("Shared\\Media\\Pictures\\{0}.jpg", nameFile));
                return true;
            }
            else
                return false;
        }
        private void loadImageFileFromIsoStore()
        {
            var bmp = new BitmapImage();
            var fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            Debug.WriteLine(string.Format("{0}.jpg", nameFile));
            if (fileStorage.FileExists( string.Format("Shared\\Media\\Pictures\\{0}.jpg", nameFile) ))
            {
                using (var fstream = fileStorage.OpenFile(string.Format("Shared\\Media\\Pictures\\{0}.jpg", nameFile), System.IO.FileMode.Open))
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
                    if (!isolatedStorage.DirectoryExists("Shared\\Media\\Pictures"))
                    {
                        isolatedStorage.CreateDirectory("Shared\\Media\\Pictures");
                    }
                    using (var fileStream = new IsolatedStorageFileStream(string.Format("Shared\\Media\\Pictures\\{0}.jpg", nameFile), System.IO.FileMode.Create, isolatedStorage))
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



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            saveBuy();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            saveBuy();
        }
        private void saveBuy()
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
                    popupMsgText.Text = "Добавлено";
                    showPopup();
                }
                else
                {
                    popupMsgText.Text = "Уже есть в списке покупок";
                    showPopup();
                }
            }
        }
        private void showPopup()
        {
            popupMsg.IsOpen = true;
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += closePopup;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }
        private void closePopup(object sender, EventArgs e)
        {
            popupMsg.IsOpen = false;
            var dispatcherTimer = sender as System.Windows.Threading.DispatcherTimer;
            dispatcherTimer.Stop();
        }
    }
}