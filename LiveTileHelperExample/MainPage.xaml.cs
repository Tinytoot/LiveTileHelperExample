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
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Shell;
using LiveTileHelperExample.Views;


namespace LiveTileHelperExample
{
    public partial class MainPage : PhoneApplicationPage
    {
        private FrontLiveTile frontTile = new FrontLiveTile();
        private BackLiveTile backTile = new BackLiveTile();
        const char DegreeSign = (char)176;

        public MainPage()
        {
            InitializeComponent();

            this.frontTile.SetCityName(this.cityname.Text);
            this.radHubTile.Height = 173;
            this.radHubTile.Width = 173;
            this.frontTile.SetProperties(new BitmapImage(new Uri("/Images/sunny.png", UriKind.RelativeOrAbsolute)),
                String.Format("25{0}", DegreeSign));
            this.radHubTile.FrontContent = this.frontTile;
            this.radHubTile.BackContent = this.backTile;
        }

        private void RadImageButton_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            RadExtendedTileData tileData = new RadExtendedTileData()
            {
                VisualElement = Tile
                 
            };
            Uri tileUri = new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute);
            ShellTile tile = Telerik.Windows.Controls.LiveTileHelper.GetTile(tileUri);
                        
            if (tile != null)
            {
                tile.Delete();
            }

            Telerik.Windows.Controls.LiveTileHelper.CreateTile(tileData, tileUri);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            string imageName = (sender as RadioButton).Name;

            if (radHubTile != null)
            {
                this.frontTile.SetProperties(new BitmapImage(new Uri("/Images/"+ imageName + ".png", UriKind.RelativeOrAbsolute)), 
                String.Format("25{0}", 0));

               // selectedImage.Source = new BitmapImage(new Uri("Images/" + imageName + ".png", UriKind.RelativeOrAbsolute));
            }
        }
    }
}