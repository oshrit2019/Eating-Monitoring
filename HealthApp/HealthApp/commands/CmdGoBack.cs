using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthApp.commands
{
    //command click button to go fisrt page
    class CmdGoBack : ICommand
    {
        VMMain gVm;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public CmdGoBack(VMMain vm)
        {
            gVm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            gVm.UserControl = null;
        }
    }
}
