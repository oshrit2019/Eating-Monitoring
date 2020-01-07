using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace HealthApp.Models
{
    //class that connect between view model to bl

    public class ModelFoods
    {
        public BL.IBL bl { get; set; }
        public List<BE.Food> listBreakfast;
        public List<BE.Food> listDinner;
        public List<BE.Food> listLunch;
        public List<BE.Food> listSnack;

        /// <summary>
        /// constructor
        /// </summary>
        public ModelFoods()
        {
            bl = new BL.BL_Imp();
            listBreakfast = new List<BE.Food>();
            listDinner = new List<BE.Food>();
            listLunch = new List<BE.Food>();
            listSnack = new List<BE.Food>();
        }
        /// <summary>
        ///add food to data base
        /// </summary>
        /// <param name="food"></param>
        public void AddFood(BE.Food food)
        {
            bl.AddFood(food);
        }
        /// <summary>
        ///return the list according to id ,date and meal
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <param name="meal"></param>
        /// <returns></returns>
        public List<BE.Food> ListOfFoodsInDate(DateTime date, String id, String meal)
        {
            return bl.ListOfFoodsInDate(date, id, meal);
        }
        /// <summary>
        ///add to amount of specific food 
        /// </summary>
        /// <param name="food"></param>
        public void addAmountFood(BE.Food food)
        {
            bl.addAmountFood(food);
        }
        /// <summary>
        ///substract from amount of specific food
        /// </summary>
        /// <param name="food"></param>
        public void minusAmountFood(BE.Food food)
        {
            bl.minusAmountFood(food);
        }

    }
}
