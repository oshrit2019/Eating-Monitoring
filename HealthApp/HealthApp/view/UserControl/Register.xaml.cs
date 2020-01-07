using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthApp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        //giving options to combobox and connection to vmRegister
        public Register()
        {
            InitializeComponent();
            this.FamilyStatusCombobox.ItemsSource = Enum.GetValues(typeof(BE.status));
            VMRegister vm = new VMRegister();
            this.DataContext = vm;

        }

        
    }
}
