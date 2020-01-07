using HealthApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HealthApp.viewModel
{
    class VMMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private UserControl _UserControl;
        public UserControl UserControl
        {
            get { return _UserControl; }
            set
            {
                _UserControl = value;
                PropertyChanged(this, new PropertyChangedEventArgs(null));
            }
        }
        public ModelLogin modelLogin { get; set; }
        public commands.cmdLogin Login { get; set; }
        public commands.cmdRegister Register { get; set; }
        public commands.CmdGoBack GoBack { get; set; }
        /// <summary>
        /// constructor, definition commands and model
        /// </summary>
        public VMMain()
        {
            Register = new commands.cmdRegister(this);
            Login = new commands.cmdLogin(this);
            GoBack = new commands.CmdGoBack(this);
            modelLogin = new ModelLogin();
        }

        /// <summary>
        /// check if client exists in database
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public String CheckUser(BE.Client client)
        {
            return modelLogin.CheckUser(client);
        }
    }
}
