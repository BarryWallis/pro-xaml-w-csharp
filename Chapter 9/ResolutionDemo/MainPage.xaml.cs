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
            double scaleFactor = info.RawPixelsPerViewPixel;

            double displayResolutionWidth = Window.Current.Bounds.Width * scaleFactor;
            double displayResolutionHeight = Window.Current.Bounds.Height * scaleFactor;
            PixelResolution.Text = $"Pixel resolution: {Window.Current.Bounds.Width}x{Window.Current.Bounds.Height}";
            DisplayResolution.Text = $"Display resolution: {displayResolutionWidth}x{displayResolutionHeight}";
        }
    }
}
