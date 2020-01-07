using HealthApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HealthApp.viewModel
{
    class VMRegister : DependencyObject ,INotifyPropertyChanged
    {
        public ModelRegister modelRegister { get; set; }
      
        public event PropertyChangedEventHandler PropertyChanged;
        public commands.cmdAddUser AddUser { get; set; }
        /// <summary>
        /// constructor, definition command and model
        /// </summary>
        public VMRegister()
        {
            modelRegister = new ModelRegister();
            AddUser = new commands.cmdAddUser(this);
        }
        /// <summary>
        /// add user to database
        /// </summary>
        /// <param name="user"></param>
        public void AddUserFunc(BE.User user )
        {
            modelRegister.AddUser(user);
        }

    }
}
