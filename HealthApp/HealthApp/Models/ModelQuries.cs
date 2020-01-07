using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models
{
    public class ModelQuries
    {
        public BL.IBL bl { get; set; }
        public ModelQuries()
        {
            bl = new BL.BL_Imp();
        }
        /// <summary>
        /// Receives food and returns its ingredients
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public BE.Component ReturnComponent(String food)
        {
            BE.Component c = new BE.Component();
            String xml = bl.XmlFood(food);
            String key = bl.GetKeyOfFood(xml, food);
            c=bl.ReturnComponent(key, 1);
            return c;
        }
    }
}
