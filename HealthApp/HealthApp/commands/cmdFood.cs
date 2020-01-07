using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthApp.commands
{
    //cmd to replace the user control to food user.
    public class cmdFood : ICommand
    {

        VMMenu mVm;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public String Id { get; set; }
        public cmdFood(VMMenu vm,String id)
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
            //replace the user control to food user control
            
            mVm.UserControl = new Food(Id);
           
        }
    }
}
