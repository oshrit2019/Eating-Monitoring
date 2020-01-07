using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace HealthApp.commands
{
    //cmd click buttom to insert your application with id and password, 
    //check id and password and replace user control to menu user control
    class cmdLogin : ICommand
    {

        VMMain lVm;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public cmdLogin(VMMain vm)
        {
            lVm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (Object[])parameter;
            var client = new BE.Client();
            client.Id = values[0].ToString();
            var PasswordBox = values[1] as PasswordBox;
            client.password = PasswordBox.Password.ToString();
            //call function in view model to check user
            String Id = lVm.CheckUser(client);
            if ( Id != null)
                //save Id's user in client 
            {
                Menu user = new Menu();
                user.Id = client.Id;
                user.init();
                lVm.UserControl = user;                             
            }
            else
            {
                MessageBox.Show("User does not exist!");
            }

        }
    }
}
