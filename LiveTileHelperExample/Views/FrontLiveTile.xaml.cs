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

namespace LiveTileHelperExample.Views
{
    public partial class FrontLiveTile : UserControl
    {
        public void SetProperties(ImageSource imageSource, string temperature)
        {
            this.frontImage.Source = imageSource;
            this.temperature.Text = temperature;
        }

        public void SetTemperatureRange(string temperatureRange)
        {
            this.temperatureRange.Text = temperatureRange;
        }

        public void SetCityName(string cityName)
        {
            this.cityName.Text = cityName;
        }

        public void SetScale(string scale)
        {
            this.scale.Text = scale;
        }

        public FrontLiveTile()
        {
            InitializeComponent();
            this.SetScale("C");
        }
    }
}
