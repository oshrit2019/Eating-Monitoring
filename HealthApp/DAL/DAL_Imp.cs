using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE;
using System.Xml;
using System.Net;
using System.IO;
using System.Xml.Linq;
using RestSharp;
using System.Json;
using JsonObject = System.Json.JsonObject;
using ServiceStack.Text;
using Nancy.Json.Simple;
using Newtonsoft.Json.Linq;
using System.Data.Entity.Core.Metadata.Edm;

namespace DAL
{
    //class of the functions that they have interaction with data and and cloud services
    public class DAL_Imp : IDAL
    {
        /// <summary>
        ///add user to db of  users
        /// </summary>
        /// <param name="user"></param>
        public void addUser(User user)
        {
            if (CheckId(user.Id))//if the user exist on database
                throw new Exception("The user exist on system");
            else
            {
                using (var db = new BE.AppContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        ///  return all the name of foods in the list in the api
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public List<String> GetAllFood(String xml)
        {
            JObject details = JObject.Parse(xml);
            List < JObject > foods1 = details["foods"].ToObject<List<JObject>>();
               
            XmlDocument xDoc = new XmlDocument();
            List<String> foods = new List<string>();
            foreach (JObject item in foods1)
            {
                foods.Add(item["description"].ToString());
            }
            return foods;
        }
        /// <summary>
        /// get the xml of foods
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public String XmlFood(String text)
        {
            String address = "https://api.nal.usda.gov/fdc/v1/foods/search?api_key=qQSwzmN3AxhmXRcuzavIx0RYOIrhR1utDhsafXCb&query=" + text;// + "&max=25&offset=0&api_key=qQSwzmN3AxhmXRcuzavIx0RYOIrhR1utDhsafXCb";
            WebRequest requst = WebRequest.Create(address);
            requst.Method = "GET";
            WebResponse response = requst.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(dataStream);
            String output = streamReader.ReadToEnd();
            return output;
        }
        /// <summary>
        /// get key of specific food
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="food"></param>
        /// <returns></returns>
        public String GetKeyOfFood(String xml, String food)
        {
            JObject details = JObject.Parse(xml);
            List<JObject> foods1 = details["foods"].ToObject<List<JObject>>();
            foreach (JObject item in foods1)
            {
                if (item["description"].ToString() == food)
                {
                    return item["fdcId"].ToString();
                }
            }
            return null;
        }
        /// <summary>
        ///get xml components specific food 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public String XmlProduct(String key)
        {
            String address = @"https://api.nal.usda.gov/fdc/v1/food/"+key+@"?api_key=qQSwzmN3AxhmXRcuzavIx0RYOIrhR1utDhsafXCb";
            WebRequest requst = WebRequest.Create(address);
            requst.Method = "GET";
            WebResponse response = requst.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(dataStream);
            String output = streamReader.ReadToEnd();
            return output;
        }
        /// <summary>
        ///  return components of specific food
        /// </summary>
        /// <param name="key"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Component ReturnComponent(String key, int amount )
        {

            String xml = XmlProduct(key);
            JObject details = JObject.Parse(xml);
            JObject foods1 = JObject.Parse(details["labelNutrients"].ToString());
            BE.Component component = new Component();
            component.ndbo = key;
            JObject comp = JObject.Parse(foods1["fat"].ToString());
            float x1 = float.Parse(comp["value"].ToString());
            component.Fats =x1*amount;
            comp = JObject.Parse(foods1["fiber"].ToString());
             x1 = float.Parse(comp["value"].ToString());
            component.Fiber = x1 * amount;

            comp = JObject.Parse(foods1["carbohydrates"].ToString());
            x1 = float.Parse(comp["value"].ToString());
            component.Carbohydrate = x1 * amount;
            comp = JObject.Parse(foods1["sugars"].ToString());
            x1 = float.Parse(comp["value"].ToString());
            component.Sugar = x1 * amount;

            comp = JObject.Parse(foods1["protein"].ToString());
            x1 = float.Parse(comp["value"].ToString());
            component.Protien = x1 * amount;

            comp = JObject.Parse(foods1["cholesterol"].ToString());
            x1 = float.Parse(comp["value"].ToString());
            component.Cholesterol = x1 * amount;

            comp = JObject.Parse(foods1["iron"].ToString());
            x1 = float.Parse(comp["value"].ToString());
            component.Iron = x1 * amount;

            //string name1 = details["description"].ToString();

            //string name1 = foods1[x].ToString();
            // JObject name1 = JObject.Parse(foods1[details["description"].ToString()]);
            /*   foreach(JObject item in foods1)
               {
                  // if(item[""])
               }*/
            //labelNutrients
            /* XmlDocument xDoc = new XmlDocument();
             xDoc.LoadXml(xml);
             XmlNodeList nutrientsList = xDoc.SelectNodes("/report/food/nutrients/nutrient");

             float vitamins = 0;
             String name = "";
             String value = "";
             //go over all nutrients List
             for (int i = 0; i < nutrientsList.Count; i++)
             {

                 foreach (var item in (nutrientsList[i]).Attributes)//go over the attributes of the current nutrient
                 {
                     if ((((XmlAttribute)item).Name).Equals("name"))//save the name
                     {
                         name = (((XmlAttribute)item).Value);

                     }
                     if ((((XmlAttribute)item).Name).Equals("value"))//save the value
                     {
                         value = (((XmlAttribute)item).Value);
                     }
                     if ((((XmlAttribute)item).Name).Equals("group") && (((XmlAttribute)item).Value).Equals("Vitamins")) //if the nutrient is any vitamin save to name vitamin  
                     {
                         name = "Vitamins";
                     }
                 }
                 //insert to component
                 switch (name)
                 {
                     case "Energy":
                         component.Energy = float.Parse(value)*amount;
                         break;
                     case "Water":
                         component.Water = float.Parse(value)*amount;
                         break;
                     case "Protein":
                         component.Protien = float.Parse(value)*amount;
                         break;
                     case "Total lipid (fat)":
                         component.Fats = float.Parse(value)*amount;
                         break;
                     case "Fiber, total dietary":
                         component.Fiber = float.Parse(value);
                         break;
                     case "Carbohydrate, by difference":
                         component.Carbohydrate = float.Parse(value)*amount;
                         break;
                     case "Sugars, total":
                         component.Sugar = float.Parse(value)*amount;
                         break;
                     case "Vitamins":
                         vitamins += float.Parse(value) * amount; //all vitamins together
                         break;
                     default:
                         break;
                 }
             }
             component.Vitamins = vitamins;*/
            return component;
        }
        /// <summary>
        ///Sum of all components
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Component SumOfComponents(String id,DateTime date,String time)
        {
            Component c = new Component();
            if(time=="day")//sum according to day
            {
                using (var db = new BE.AppContext())
                {
                    foreach (var item in db.Foods)
                    {
                        if (item.ID.Equals(id) && item.Date.Date.Equals(date.Date))//check id and date that equal to Now
                        {

                            Component c1 = new Component();
                            c1 = ReturnComponent(item.ndbo,int.Parse(item.Amount));
                            c.ndbo = c1.ndbo;
                            c.Carbohydrate += c1.Carbohydrate;
                            //c.Energy += c1.Energy;
                            c.Fats += c1.Fats;
                            c.Fiber += c1.Fiber;
                            c.Protien += c1.Protien;
                            c.Sugar += c1.Sugar;
                            c.Iron += c1.Iron;
                            c.Cholesterol += c1.Cholesterol;
                        }
                    }
                }
            }
            else if (time =="month")//sum according to month
            {
                using (var db = new BE.AppContext())
                {
                    //check this month and this year and id
                    var qury1 = (from f in db.Foods where f.ID.Equals(id) && f.Date.Month.Equals(date.Month)&&f.Date.Year.Equals(date.Year) select f);
                    foreach (var item in qury1)
                    {
                        Component c1 = new Component();
                        c1 = ReturnComponent(item.ndbo, int.Parse(item.Amount));
                        c.ndbo = c1.ndbo;
                        c.Carbohydrate += c1.Carbohydrate;
                        //c.Energy += c1.Energy;
                        c.Fats += c1.Fats;
                        c.Fiber += c1.Fiber;
                        c.Protien += c1.Protien;
                        c.Sugar += c1.Sugar;
                        c.Cholesterol += c1.Cholesterol;
                        c.Iron += c1.Iron;
                    }
                }

            }
            else if(time=="week")//sum according to week
            {
                using (var db = new BE.AppContext())
                {

                    List<BE.Food> qury1 = new List<Food>();
                    //check this week and id and the date in the week
                    foreach (var item in db.Foods)
                    {
                        if(item.ID.Equals(id)&&dateInWeek(item.Date, date))
                        {
                            qury1.Add(item);
                        }
                    }

                    foreach (var item in qury1)
                    {
                        Component c1 = new Component();
                        c1 = ReturnComponent(item.ndbo, int.Parse(item.Amount));
                        c.ndbo = c1.ndbo;
                        c.Carbohydrate += c1.Carbohydrate;
                       // c.Energy += c1.Energy;
                        c.Fats += c1.Fats;
                        c.Fiber += c1.Fiber;
                        c.Protien += c1.Protien;
                        c.Sugar += c1.Sugar;
                        c.Cholesterol += c1.Cholesterol;
                        c.Iron += c1.Iron;
                    }
                }

            }
            else if (time == "year")//sum according to month
            {
                using (var db = new BE.AppContext())
                {
                    //check this month and this year and id
                    var qury1 = (from f in db.Foods where f.ID.Equals(id) && f.Date.Year.Equals(date.Year) select f);
                    foreach (var item in qury1)
                    {
                        Component c1 = new Component();
                        c1 = ReturnComponent(item.ndbo, int.Parse(item.Amount));
                        c.ndbo = c1.ndbo;
                        c.Carbohydrate += c1.Carbohydrate;
                        c.Iron += c1.Iron;
                        c.Fats += c1.Fats;
                        c.Fiber += c1.Fiber;
                        c.Protien += c1.Protien;
                        c.Sugar += c1.Sugar;
                        c.Cholesterol += c1.Cholesterol;
                       // c.Water += c1.Water;
                    }
                }

            }
            return c;
        }
        /// <summary>
        /// check if the date in week
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public bool dateInWeek(DateTime date1, DateTime date2)
        {
            if(date2.Day<=7)
            {
                int day;
                int month = date2.Month - 1;
                if(month==1||month==3||month==5||month==7||month==8||month==10||month==12)
                {
                    day = 31 - (7-date2.Day);
                }
                else if(month==4||month==6||month==9||month==11)
                {
                    day = 30 -(7- date2.Day);
                }
                else
                {
                    day = 28 - (7-date2.Day);
                }
                if ((date1.Month == date2.Month && date1.Day <= date2.Day) || (date1.Month == month && date1.Day > day))
                {
                    return true;
                }
                else return false;
            }
            else if(date1.Month==date2.Month&& date1.Day<=date2.Day&& (date1.Day>date2.Day-7))
            {
                return true;
            }
            return false;

        }
        /// <summary>
        ///check if the user is exsit
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public String CheckUser(BE.Client client)
        {
            using (var db = new BE.AppContext())
            {
                foreach (var item in db.Users)
                {
                    if (item.Id == client.Id && item.Password == client.password)
                        return item.Id;
                }
            }
            return null;
        }
        /// <summary>
        ///check if user exist in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckId(String id)
        {
            using (var db = new BE.AppContext())
            {
                foreach (var item in db.Users)
                {
                    if (item.Id == id)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        ///add food to the data base
        /// </summary>
        /// <param name="food"></param>
        public void AddFood(BE.Food food)
        {
            int count = 0;
            bool flag = false;
            String xmlfood = XmlFood(food.Description);
            food.ndbo = GetKeyOfFood(xmlfood, food.Description);
            BE.Food food2 = new BE.Food();
            using (var db = new BE.AppContext())
            {
                count = db.Foods.Count();
                //if the food exist to this user- upadte the amount
                var qury1 = (from f in db.Foods where f.ID.Equals(food.ID) && f.Date.Equals(food.Date) && f.Description.Equals(food.Description) select f);
                foreach (var item in qury1)
                {
                    food2 = item;
                    int amount=int.Parse(food2.Amount);
                    amount++;
                    food2.Amount = amount.ToString();
                    db.Foods.Remove(item);
                    flag = true;
                }
                db.SaveChanges();

                if (flag)
                {
                    db.Foods.Add(food2);
                }
                //if food not exist - add to db
                if (!flag && food.ndbo!=null)
                {
                    food.key = count + 1;
                    db.Foods.Add(food);
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        ///return list of food according to meal , date and Id
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <param name="meal"></param>
        /// <returns></returns>
        public List<BE.Food> ListOfFoodsInDate(DateTime date, String id, String meal)
        {
            List<BE.Food> lst = new List<BE.Food>();
            using (var db = new BE.AppContext())
            {
                foreach (var item in db.Foods)
                {
                    //when id and meal and Date equal to this(item) food
                    if (item.ID.Equals(id) && item.Meal.Equals(meal) && item.Date.Date.Equals(date.Date))
                    {
                        lst.Add((Food)item);
                    }
                }

            }
            return lst;
        }
        /// <summary>
        ///add to amount to food
        /// </summary>
        /// <param name="food"></param>
        public void addAmountFood(Food food)
        {
            Food food2 = new Food();
            using (var db = new BE.AppContext())
            {
                foreach (var item in db.Foods)
                {
                    //search the food and if exsit add 1 to amount
                    if (item.ID.Equals(food.ID) && item.Date.Date.Equals(food.Date.Date) && item.Description.Equals(food.Description))
                    {
                        food2 = item;
                        int amount = int.Parse(food2.Amount);
                        amount++;
                        food2.Amount = amount.ToString();
                        db.Foods.Remove(item);
                    }
                }
                db.SaveChanges();
                db.Foods.Add(food2);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Subtract from quantity 1
        /// </summary>
        /// <param name="food"></param>
        public void minusAmountFood(Food food)
        {
            Food food2 = new Food();
            using (var db = new BE.AppContext())
            {
                foreach (var item in db.Foods)
                {
                    //search the food and if exsit sub 1 to amount
                    if (item.ID.Equals(food.ID) && item.Date.Equals(food.Date) && item.Description.Equals(food.Description))
                    {
                        food2 = item;
                        int amount = int.Parse(food2.Amount);
                        amount--;
                        food2.Amount = amount.ToString();
                        db.Foods.Remove(item);
                    }
                }
                db.SaveChanges();
                if (int.Parse(food2.Amount) > 0)//when the amount greater than 0
                {
                    db.Foods.Add(food2);
                }
                db.SaveChanges();

            }
        }


    }

}



