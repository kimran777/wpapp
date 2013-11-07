using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace Discount
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
            InitializeSettings();
        }
        private void InitializeSettings()
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            const string isDownloadImage = "isDownloadImage";
            if (!settings.Contains(isDownloadImage))
            {
                settings.Add(isDownloadImage, false);
                settings.Save();
            }
            cbDownloadImage.IsChecked = (bool)settings[isDownloadImage];
        }

        private void DownloadImageCheckedChanged(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings["isDownloadImage"] = cbDownloadImage.IsChecked;
            settings.Save();
        }
    }
}