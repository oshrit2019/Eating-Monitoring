using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthApp.commands
{
    //cmd click button to replace user control to grahp user control
   public class cmdGrahp : ICommand
    {

        VMMenu mVm;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public String Id { get; set; }
        public cmdGrahp(VMMenu vm,String id)
        {
            mVm = vm;
            Id = id;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Comparison c=  new Comparison();
            c.initProperty(Id);
            mVm.UserControl = c;
        }
    }
}
