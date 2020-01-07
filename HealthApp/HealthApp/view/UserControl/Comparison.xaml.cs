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
    /// Interaction logic for Comparison.xaml
    /// </summary>
    public partial class Comparison : UserControl
    {
        public String Id { get; set; }
        public Comparison()
        {
            InitializeComponent();
        }
        //connection to vmComparsion and default boot to day
        public void initProperty(String id)
        {
            Id = id;
            VMComparsion vm = new VMComparsion(Id);
            this.DataContext = vm;
        }
    

       
    }
}
