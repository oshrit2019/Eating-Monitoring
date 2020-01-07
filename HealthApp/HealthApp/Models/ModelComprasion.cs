using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models
{
    //class that connect between view model to bl
    public class ModelComprasion
    {
        public BL.IBL bl { get; set; }
        public ModelComprasion()
        {
            bl = new BL.BL_Imp();

        }
        /// <summary>
        ///call to function in bl to sum of compinents according to id, date and specific time 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public BE.Component SumOfComponents(String id, DateTime date, String time)
        {
            return bl.SumOfComponents(id, date, time);
        }
    }
}
