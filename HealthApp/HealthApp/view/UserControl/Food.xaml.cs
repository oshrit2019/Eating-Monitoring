using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Interaction logic for Food.xaml
    /// </summary>
    public partial class Food : UserControl
    {
        public String Id { get; set; }
        private VMFoods vM;
        // connection to vmFood
        public Food(String id)
        {
            InitializeComponent();
            Id = id;
             vM = new VMFoods(Id);
            MainGrid.DataContext = vM;

            
        }
        //viewing the list of meal of the selected date
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            vM.initAllListsOfFood();

        }
    }
}
