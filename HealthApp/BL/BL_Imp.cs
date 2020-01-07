using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BL
{
    //implment interface IBL that doing the logic of the project and connect between data and view
    public class BL_Imp : IBL
    {
        IDAL dal;

        public BL_Imp()
        {
            dal = new DAL_Imp();

        }
        public void addUser(User user)
        {
            dal.addUser(user);
        }
        public List<String> GetAllFood(String xml)
        {
            return dal.GetAllFood(xml);
        }
        public String XmlFood(String text)
        {
            return dal.XmlFood(text);
        }
        public String GetKeyOfFood(String xml, String food)
        {
            return dal.GetKeyOfFood(xml, food);
        }
        public String CheckUser(BE.Client client)
        {
            return dal.CheckUser(client);
        }
        public void AddFood(BE.Food food)
        {
            dal.AddFood(food);
        }
        public List<BE.Food> ListOfFoodsInDate(DateTime date, String id, String meal)
        {
            return dal.ListOfFoodsInDate(date, id, meal);
        }

        public void addAmountFood(Food food)
        {
            dal.addAmountFood(food);
        }
        public void minusAmountFood(Food food)
        {
            dal.minusAmountFood(food);
        }
       public Component ReturnComponent(String key, int amount)
        {
           return dal.ReturnComponent(key, amount);
        }

        public Component SumOfComponents(string id, DateTime date, string time)
        {
            return dal.SumOfComponents(id, date, time);
        }
    }
}
