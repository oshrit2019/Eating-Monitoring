using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models
{
    //class that connect between view model to bl
    public class ModelRegister
    {
        public BL.IBL bl { get; set; }
        public ModelRegister()
        {
            bl = new BL.BL_Imp();

        }
        /// <summary>
        /// add user to data base
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(BE.User user)
        {
            bl.addUser(user);
        }
    }
}
