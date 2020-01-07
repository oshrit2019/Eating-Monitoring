using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    //interface of functions that they with interaction data and cloud services
    public interface IDAL
    {
        void addUser(BE.User user);
         List<String> GetAllFood(String xml);
        String XmlFood(String text);
        String GetKeyOfFood(String xml, String food);
        String CheckUser(BE.Client client);
        void AddFood(BE.Food food);
        List<BE.Food> ListOfFoodsInDate(DateTime date, String id, String meal);
        void addAmountFood(Food food);
        void minusAmountFood(Food food);
        String XmlProduct(String key);
        Component ReturnComponent(String key, int amount);
        Component SumOfComponents(string id, DateTime date, string time);
        bool CheckId(String id);

    }
}
