using HealthApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;
using BE;

namespace HealthApp.viewModel
{
    //view model of compresion data 
   public class VMComparsion : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ModelComprasion model;
        public String Id { get; set; }
        //collection of the data in the pie
        private ObservableCollection<KeyValuePair<string, float>> _pieCollection;
        public ObservableCollection<KeyValuePair<string, float>> PieCollection
        {
            get { return _pieCollection; }
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id"></param>
        public VMComparsion(String id)
        {
            model = new ModelComprasion();
            Id = id;
            _pieCollection = new ObservableCollection<KeyValuePair<string, float>>();
            filterPie("A day");
        }
      
        private String filter;
        public String Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                filterPie(Filter);
            }
        }
        //filtering time and change the pie
        private void filterPie(String filter)
        {
            int counter = PieCollection.Count;
            for (int i = counter; i > 0; i--)
            {
                PieCollection.Remove(PieCollection[i - 1]);
            }

            string[] _time = filter.Split(' ');
            String time = _time[1];
            // _pieCollection = new ObservableCollection<KeyValuePair<string, int>>();
            BE.Component c = new BE.Component();
            c = model.SumOfComponents(Id, DateTime.Now, time);
            //change  data in pie according to time and Id
            PieCollection.Add(new KeyValuePair<string, float>("Energy", c.Iron));
            PieCollection.Add(new KeyValuePair<string, float>("Sugar", c.Sugar));
            PieCollection.Add(new KeyValuePair<string, float>("Fats", c.Fats));
            PieCollection.Add(new KeyValuePair<string, float>("Carbohydrate", c.Carbohydrate));
            PieCollection.Add(new KeyValuePair<string, float>("Vitamins", c.Cholesterol));
            PieCollection.Add(new KeyValuePair<string, float>("Protien", c.Protien));
            PieCollection.Add(new KeyValuePair<string, float>("Fiber", c.Fiber));
            //PieCollection.Add(new KeyValuePair<string, float>("Water", c.Water));
        }
    }
}
