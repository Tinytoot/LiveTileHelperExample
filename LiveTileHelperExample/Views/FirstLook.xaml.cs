using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
//using Telerik.QSF.WP;
using System.Windows.Threading;
using Microsoft.Phone.Shell;

namespace MyWeather.Views
{
    public partial class FirstLook : UserControl
    {
        const char DegreeSign = (char)176;

        private FrontLiveTile frontTile = new FrontLiveTile();
        private BackLiveTile backTile = new BackLiveTile();
        private string currentTemperatureRange;

        public FirstLook()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler(FirstLook_Loaded);

            this.radioSunny.IsChecked = true;

            this.frontTile.SetCityName(this.cityName.Text);
            this.radHubTile.Height = 173;
            this.radHubTile.Width = 173;
            this.radHubTile.FrontContent = this.frontTile;
            this.radHubTile.BackContent = this.backTile;

            //this.cityName.GotFocus += new RoutedEventHandler(cityName_GotFocus);
            //this.cityName.LostFocus += new RoutedEventHandler(cityName_LostFocus);
        }

        void FirstLook_Loaded(object sender, RoutedEventArgs e)
        {
            this.backTileCheckBox.IsChecked = true;
        }

        //void cityName_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    MainViewModel.Instance.CurrentPage.ApplicationBar.IsVisible = false;
        //}

        //void cityName_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    MainViewModel.Instance.CurrentPage.ApplicationBar.IsVisible = true;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadExtendedTileData extendedData = new RadExtendedTileData()
            {
                VisualElement = frontTile
            };

            if (this.backTileCheckBox.IsChecked.Value == true)
            {
                extendedData.BackVisualElement = backTile;
            }

            Uri tileUri = new Uri("/MainPage.xaml?redirect=true", UriKind.RelativeOrAbsolute);
            ShellTile tile = Telerik.Windows.Controls.LiveTileHelper.GetTile(tileUri);

            if (tile != null)
            {
                tile.Delete();
            }

            Telerik.Windows.Controls.LiveTileHelper.CreateTile(extendedData, tileUri);
        }

        private void radioSunny_Checked(object sender, RoutedEventArgs e)
        {
            this.frontTile.SetProperties(
                new BitmapImage(new Uri("../Images/sunny.png", UriKind.RelativeOrAbsolute)), 
                String.Format("25{0}", DegreeSign));
            
            this.currentTemperatureRange = String.Format("22{0}/28{0}", DegreeSign);
            if (this.minMaxCheckBox.IsChecked.Value)
            {
                this.frontTile.SetTemperatureRange(currentTemperatureRange);
            }

            this.backTile.SetProperties(
                new BitmapImage(new Uri("../Images/sunny-back.png", UriKind.RelativeOrAbsolute)),
                "Umbrella free day!");
        }

        private void radioCloudy_Checked(object sender, RoutedEventArgs e)
        {
            this.frontTile.SetProperties(
                new BitmapImage(new Uri("../Images/cloudy.png", UriKind.RelativeOrAbsolute)),
                String.Format("20{0}", DegreeSign));

            this.currentTemperatureRange = String.Format("15{0}/20{0}", DegreeSign);
            if (this.minMaxCheckBox.IsChecked.Value)
            {
                this.frontTile.SetTemperatureRange(currentTemperatureRange);
            }

            this.backTile.SetProperties(
                new BitmapImage(new Uri("../Images/cloudy-back.png", UriKind.RelativeOrAbsolute)),
                "Umbrella free day!");
        }

        private void radioRainy_Checked(object sender, RoutedEventArgs e)
        {
            this.frontTile.SetProperties(
                new BitmapImage(new Uri("../Images/rainy.png", UriKind.RelativeOrAbsolute)),
                String.Format("10{0}", DegreeSign));

            this.currentTemperatureRange = String.Format("  5{0}/14{0}", DegreeSign);
            if (this.minMaxCheckBox.IsChecked.Value)
            {
                this.frontTile.SetTemperatureRange(currentTemperatureRange);
            }

            this.backTile.SetProperties(
                new BitmapImage(new Uri("../Images/rainy-back.png", UriKind.RelativeOrAbsolute)),
                "You should bring an umbrella today!");
        }

        private void radioSnowy_Checked(object sender, RoutedEventArgs e)
        {
            this.frontTile.SetProperties(
                new BitmapImage(new Uri("../Images/snowy.png", UriKind.RelativeOrAbsolute)),
                String.Format("-5{0}", DegreeSign));

            this.currentTemperatureRange = String.Format("  -8{0}/3{0}", DegreeSign);
            if (this.minMaxCheckBox.IsChecked.Value)
            {
                this.frontTile.SetTemperatureRange(currentTemperatureRange);
            }

            this.backTile.SetProperties(
                new BitmapImage(new Uri("../Images/snowy-back.png", UriKind.RelativeOrAbsolute)),
                "You should bring an umbrella today!");
        }
        
        private void cityName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.frontTile.SetCityName(this.cityName.Text);
        }

        private void minMaxCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.frontTile.SetTemperatureRange(currentTemperatureRange);
        }

        private void minMaxCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.frontTile.SetTemperatureRange(string.Empty);
        }

        private void backTileCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.radHubTile.BackContent = this.backTile;
        }

        private void backTileCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.radHubTile.BackContent = null;
        }
    }
}
