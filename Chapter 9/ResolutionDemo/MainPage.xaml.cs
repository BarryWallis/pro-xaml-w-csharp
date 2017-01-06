using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ResolutionDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DisplayInformation info = DisplayInformation.GetForCurrentView();
            double scaleFactor = info.RawPixelsPerViewPixel * 100;

            string selectedScaleFactor =
                (scaleFactor <= 100) ? "100" :
                (scaleFactor <= 140) ? "140" :
                (scaleFactor <= 200) ? "200" :
                "240";
            string imageUriString = string.Format(@"ms-appx:///Images/star.scale-{0}.png", selectedScaleFactor);
            Uri selectedImageUri = new Uri(imageUriString, UriKind.RelativeOrAbsolute);
            BitmapImage bmpImage = new BitmapImage(selectedImageUri);
            MyImage.Source = bmpImage;
        }
    }
}
