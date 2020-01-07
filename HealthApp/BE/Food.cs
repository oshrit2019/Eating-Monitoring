using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BE
{
    //class of data of food
    public class Food
    {
        [Key]
        public int key { get; set; }
        public String Description { get; set; }
        public String ndbo { get; set; }
        public String ID { get; set; }
        public DateTime Date { get; set; }
        public String Meal { get; set; }
        public String Amount { get; set; }
    }
}
