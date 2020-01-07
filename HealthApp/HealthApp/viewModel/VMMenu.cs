using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HealthApp.viewModel
{
    public class VMMenu : INotifyPropertyChanged
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
        public String Id { get; set; }
        public commands.cmdFood Food { get; set; }
        public commands.cmdGrahp Grahp { get; set; }
        public commands.cmdQuery Query { get; set; }

        /// <summary>
        /// constructor, defintion commands
        /// </summary>
        /// <param name="id"></param>
        public VMMenu(String id)
        {
            Id = id;
            Food = new commands.cmdFood(this, Id);
            Grahp = new commands.cmdGrahp(this, Id);
            Query = new commands.cmdQuery(this);
        }
    }
}
