using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    //interface of BL
    public interface IBL
    {
        void addUser(BE.User user);
        List<String> GetAllFood(String xml);
        String XmlFood(String text);
        String GetKeyOfFood(String xml, String food);
        String CheckUser(BE.Client client);
        void AddFood(BE.Food food);
        Component SumOfComponents(string id, DateTime date, string time);
        List<BE.Food> ListOfFoodsInDate(DateTime date, String id, String meal);
        void addAmountFood(Food food);
        Component ReturnComponent(String key, int amount);
        void minusAmountFood(Food food);

    }
}
