using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthApp.commands
{
    //command to add user to data base
    class cmdAddUser : ICommand
    {
        VMRegister rVm;
        public event EventHandler CanExecuteChanged
        {

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public cmdAddUser(VMRegister vm)
        {
            rVm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                //extract the parameter and insert to user 
                var values = (Object[])parameter;
                BE.User user = new BE.User();
                user.Name = values[0].ToString();
                user.Id = values[1].ToString();
                //all feild that are not necessary if there is a problem with them - put defult value
                try
                {
                    user.Phone = values[2].ToString();
                }
                catch (Exception ex)
                {
                    user.Phone = "";
                }
                try
                {
                    user.Email = values[6].ToString();
                }
                catch (Exception ex)
                {
                    user.Phone = "";
                }

                try
                {
                    user.familyStatus = (BE.status)Enum.Parse(typeof(BE.status), values[3].ToString());
                }
                catch(Exception ex)
                {
                    user.familyStatus = BE.status.Single;
                }
                try
                {
                    user.Height = double.Parse(values[4].ToString());
                }
                catch (Exception ex)
                {
                    user.Height = 0;
                }
                try
                {
                    user.Weight = double.Parse(values[5].ToString());
                }
                catch (Exception ex)
                {
                    user.Weight = 0;
                }
                try
                {
                    user.Date = DateTime.Parse(values[7].ToString());
                }
                catch(Exception ex)
                {
                    user.Date = DateTime.Now;
                }
                var PasswordBox = values[8] as PasswordBox;
                user.Password = PasswordBox.Password.ToString();
                rVm.AddUserFunc(user); //call function in vm that sdd this user
                MessageBox.Show("User Created successfully");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
