using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BasicMVVMWPF.Model;

[assembly: CLSCompliant(true)]

namespace BasicMVVMWPF.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private PersonModel model;

        private string fullName;
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                NotifyPropertyChanged();
            }
        }

        public string FirstName
        {
            get => model.FirstName;
            set
            {
                model.FirstName = value;
                FullName = ConcatenatedFullName;
                NotifyPropertyChanged();
            }
        }

        public string LastName
        {
            get => model.LastName;
            set
            {
                model.LastName = value;
                FullName = ConcatenatedFullName;
                NotifyPropertyChanged();
            }
        }

        private string ConcatenatedFullName => $"{model.FirstName} {model.LastName}";

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            model = new PersonModel()
            {
                FirstName = "Buddy",
                LastName = "James",
            };

            FullName = ConcatenatedFullName;
        }

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
