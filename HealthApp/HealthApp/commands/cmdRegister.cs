using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthApp.commands
{
    //cmd click buttom to register to application
    class cmdRegister : ICommand
    {

        VMMain rVm;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public cmdRegister(VMMain vm)
        {
            rVm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //replace user control to register user
            rVm.UserControl =new Register();
        }
    }
}
