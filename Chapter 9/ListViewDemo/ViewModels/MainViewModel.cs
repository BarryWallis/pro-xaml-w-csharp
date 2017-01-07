using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewDemo.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Company> Companies { get; } = new ObservableCollection<Company>
        {
                new Company {LogoImagePath = "Assets/Amazon.png", Name = "Amazon", YearFounded=1994, Headquarters = "Seattle, WA, USA"},
                new Company {LogoImagePath = "Assets/Apple.png", Name = "Apple", YearFounded=1976, Headquarters = "Cupertino, CA, USA"},
                new Company {LogoImagePath = "Assets/Blackberry.png", Name = "Blackberry", YearFounded=1984, Headquarters="Waterloo, ON, Canada" },
                new Company {LogoImagePath = "Assets/BoxNet.png", Name = "Box.net", YearFounded = 2005, Headquarters = "Los Altos, CA, USA"},
                new Company {LogoImagePath = "Assets/Delicious.png", Name = "Delicious", YearFounded = 2003, Headquarters = "San Mateo, CA, USA"},
                new Company {LogoImagePath = "Assets/Digg.png", Name = "Digg", YearFounded = 2004, Headquarters = "New York, NY, USA"},
                new Company {LogoImagePath = "Assets/Ebay.png", Name = "eBay", YearFounded = 1995, Headquarters = "San Jose, CA, USA"},
                new Company {LogoImagePath = "Assets/Evernote.png", Name = "Evernote", YearFounded = 2007, Headquarters = "Redwood City, CA, USA"},
                new Company {LogoImagePath = "Assets/Facebook.png", Name = "Facebook", YearFounded = 2004, Headquarters = "Menlo Park, CA, USA"},
                new Company {LogoImagePath = "Assets/Flickr.png", Name = "Flickr", YearFounded = 2004, Headquarters = "Sunnyvale, CA, USA"},
                new Company {LogoImagePath = "Assets/Flipboard.png", Name = "Flipboard", YearFounded = 2010, Headquarters = "Palo Alto, CA, USA"},
                new Company {LogoImagePath = "Assets/Google.png", Name = "Google", YearFounded=1998, Headquarters = "Mountain View, CA, USA"},
                new Company {LogoImagePath = "Assets/HP.png", Name = "HP", YearFounded = 1939, Headquarters = "Palo Alto, CA, USA"},
                new Company {LogoImagePath = "Assets/Intel.png", Name = "Intel", YearFounded = 1968, Headquarters = "Santa Clara, CA, USA"},
                new Company {LogoImagePath = "Assets/Lenovo.png", Name = "Lenovo", YearFounded = 1984, Headquarters = "Morrisville, NC, USA"},
                new Company {LogoImagePath = "Assets/LG.png", Name = "LG", YearFounded = 1958, Headquarters = "Seoul, South Korea"},
                new Company {LogoImagePath = "Assets/LinkedIn.png", Name = "LinkedIn", YearFounded = 2003, Headquarters = "Mountain View, CA, USA"},
                new Company {LogoImagePath = "Assets/Microsoft.png", Name = "Microsoft", YearFounded = 1974, Headquarters = "Redmond, WA, USA"},
                new Company {LogoImagePath = "Assets/PayPal.png", Name = "PayPal", YearFounded = 1998, Headquarters = "San Jose, CA, USA"},
                new Company {LogoImagePath = "Assets/Pinterest.png", Name = "Pinterest", YearFounded = 2009, Headquarters = "San Francisco, CA, USA"},
                new Company {LogoImagePath = "Assets/Reddit.png", Name = "Reddit", YearFounded = 2005, Headquarters = "San Francisco, CA, USA"},
                new Company {LogoImagePath = "Assets/Square.png", Name = "Square", YearFounded = 2009, Headquarters = "San Francisco, CA, USA"},
                new Company {LogoImagePath = "Assets/Twitter.png", Name = "Twitter", YearFounded = 2006, Headquarters = "San Francisco, CA, USA"},
                new Company {LogoImagePath = "Assets/Udemy.png", Name = "Udemy", YearFounded = 2010, Headquarters = "San Francisco, CA, USA"},
                new Company {LogoImagePath = "Assets/YouTube.png", Name = "YouTube", YearFounded = 2005, Headquarters = "San Bruno, CA, USA"},
        };

        /// <summary>
        /// Create a new MainViewModel to connect the MainPage to the Company model.
        /// </summary>
        public MainViewModel()
        {
        }
    }
}
