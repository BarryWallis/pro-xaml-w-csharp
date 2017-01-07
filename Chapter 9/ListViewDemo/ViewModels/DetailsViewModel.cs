using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewDemo.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        private Company company;

        public Company SelectedCompany
        {
            get { return company; }
            set
            {
                if (company != value)
                {
                    company = value;
                    NotifyPropertyChanged();
                }
            }
        }

    }
}
