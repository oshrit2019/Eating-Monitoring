using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models
{
    //class that connect between view model to bl
    public class ModelLogin
    {
        public BL.IBL bl { get; set; }
        public ModelLogin()
        {
            bl = new BL.BL_Imp();

        }
        /// <summary>
        ///check if user in data base
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public String CheckUser(BE.Client client)
        {
            return bl.CheckUser(client);
        }
    }
}
