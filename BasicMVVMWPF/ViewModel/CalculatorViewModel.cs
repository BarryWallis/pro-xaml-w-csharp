using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BasicMVVMWPF.Command;

namespace BasicMVVMWPF.ViewModel
{
    class CalculatorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int firstNumber;
        public int FirstNumber
        {
            get => firstNumber;
            set
            {
                firstNumber = value;
                NotifyPropertyChanged();
            }
        }

        private int secondNumber;
        public int SecondNumber
        {
            get => secondNumber;
            set
            {
                secondNumber = value;
                NotifyPropertyChanged();
            }
        }

        private int sum;
        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand addNumbersCommand;
        public ICommand AddNumbersCommand
        {
            get => addNumbersCommand;
            set
            {
                addNumbersCommand = value;
                NotifyPropertyChanged();
            }

        }

        public CalculatorViewModel()
        {
            addNumbersCommand = new AddNumbersCommand();
        }

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
