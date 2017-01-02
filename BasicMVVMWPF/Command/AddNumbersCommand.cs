using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BasicMVVMWPF.ViewModel;

namespace BasicMVVMWPF.Command
{
    class AddNumbersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private CalculatorViewModel viewModel = null;

        public bool CanExecute(object parameter)
        {
            if (parameter is CalculatorViewModel)
            {
                viewModel = parameter as CalculatorViewModel;
                return true;
            }
            else
                return false;
        }

        public void Execute(object parameter)
        {
            if ((parameter is null) && (viewModel is null))
                throw new ArgumentNullException(nameof(parameter));
            viewModel = (parameter is null) ? viewModel : parameter as CalculatorViewModel;
            viewModel.Sum = viewModel.FirstNumber + viewModel.SecondNumber;
        }
    }
}
