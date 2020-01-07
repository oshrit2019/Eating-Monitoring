using HealthApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Windows;
using BE;

namespace HealthApp.viewModel
{
    public class VMFoods : DependencyObject
    {
        public ModelFoods modelFoods { get; set; }
        public ObservableCollection<BE.Food> FoodsBreakfast { get; set; }
        public ObservableCollection<BE.Food> FoodsDinner { get; set; }
        public ObservableCollection<BE.Food> FoodsLunch { get; set; }
        public ObservableCollection<BE.Food> FoodsSnack { get; set; }
        public commands.cmdAddAmount AddAmount { get; set; }
        public commands.cmdMinusAmount MinusAmount { get; set; }


        public String Id { get; set; }
        public String Date { get; set; }

        /// <summary>
        /// constructor
        /// definition Observable Collection, command and model
        /// </summary>
        /// <param name="id"></param>
        public VMFoods(String id)
        {
            Id = id;
            modelFoods = new ModelFoods();
            AddAmount = new commands.cmdAddAmount(this, Id);
            MinusAmount = new commands.cmdMinusAmount(this);
            FoodsBreakfast = new ObservableCollection<BE.Food>(modelFoods.listBreakfast);
            FoodsBreakfast.CollectionChanged += Foods_CollectionChangedBreakfast;

            FoodsDinner = new ObservableCollection<BE.Food>(modelFoods.listDinner);
            FoodsDinner.CollectionChanged += Foods_CollectionChangedDinner;

            FoodsLunch = new ObservableCollection<BE.Food>(modelFoods.listLunch);
            FoodsLunch.CollectionChanged += Foods_CollectionChangedLunch;

            FoodsSnack = new ObservableCollection<BE.Food>(modelFoods.listSnack);
            FoodsSnack.CollectionChanged += Foods_CollectionChangedSnack;


            Date = DateTime.Now.Date.ToString();
            initAllListsOfFood();

        }
        /// <summary>
        /// when that click add to food
        /// </summary>
        /// <param name="food"></param>
        public void addAmountFood(BE.Food food)
        {
            modelFoods.addAmountFood(food);
            initAllListsOfFood();

        }
        /// <summary>
        /// when that click reduce to food 
        /// </summary>
        /// <param name="food"></param>
        public void minusAmountFood(BE.Food food)
        {
            modelFoods.minusAmountFood(food);
            initAllListsOfFood();

        }


        /// <summary>
        /// dependency property to description of breakfast
        /// </summary>
        public String DescriptionBreakfast
        {
            get { return (String)GetValue(DescriptionBreakfastProperty); }
            set { SetValue(DescriptionBreakfastProperty, value); }
        }
        public static readonly DependencyProperty DescriptionBreakfastProperty =
           DependencyProperty.Register("DescriptionBreakfast", typeof(String), typeof(VMFoods), new UIPropertyMetadata(new PropertyChangedCallback(AddFoodBreakfast)));

        /// <summary>
        /// dependency property to description of dinner
        /// </summary>
        public String DescriptionDinner
        {
            get { return (String)GetValue(DescriptionDinnerProperty); }
            set { SetValue(DescriptionDinnerProperty, value); }
        }
        public static readonly DependencyProperty DescriptionDinnerProperty =
           DependencyProperty.Register("DescriptionDinner", typeof(String), typeof(VMFoods), new UIPropertyMetadata(new PropertyChangedCallback(AddFoodDinner)));

        /// <summary>
        /// dependency property to description of lunch
        /// </summary>
        public String DescriptionLunch
        {
            get { return (String)GetValue(DescriptionLunchProperty); }
            set { SetValue(DescriptionLunchProperty, value); }
        }
        public static readonly DependencyProperty DescriptionLunchProperty =
           DependencyProperty.Register("DescriptionLunch", typeof(String), typeof(VMFoods), new UIPropertyMetadata(new PropertyChangedCallback(AddFoodLunch)));

        /// <summary>
        /// dependency property to description of snack
        /// </summary>
        public String DescriptionSnack
        {
            get { return (String)GetValue(DescriptionSnackProperty); }
            set { SetValue(DescriptionSnackProperty, value); }
        }
        public static readonly DependencyProperty DescriptionSnackProperty =
           DependencyProperty.Register("DescriptionSnack", typeof(String), typeof(VMFoods), new UIPropertyMetadata(new PropertyChangedCallback(AddFoodSnack)));

        /// <summary>
        /// add or remove food to list of breakfast 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foods_CollectionChangedBreakfast(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //הוספה
                BE.Food f = e.NewItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listBreakfast.Add(e.NewItems[0] as BE.Food);
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                //הסרה
                BE.Food f = e.OldItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listBreakfast.Remove(f);
                }
            }
        }

        /// <summary>
        /// add or remove food to list of dinner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foods_CollectionChangedDinner(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //הוספה
                BE.Food f = e.NewItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listDinner.Add(e.NewItems[0] as BE.Food);
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                //הסרה
                BE.Food f = e.OldItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listDinner.Remove(f);
                }

            }
        }

        /// <summary>
        /// add or remove food to list of lunch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foods_CollectionChangedLunch(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //הוספה
                BE.Food f = e.NewItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listLunch.Add(e.NewItems[0] as BE.Food);
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                //הסרה
                BE.Food f = e.OldItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listLunch.Remove(f);
                }

            }
        }

        /// <summary>
        /// add or remove food to list of snack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Foods_CollectionChangedSnack(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                //הוספה
                BE.Food f = e.NewItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listSnack.Add(e.NewItems[0] as BE.Food);
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                //הסרה
                BE.Food f = e.OldItems[0] as BE.Food;
                if (f.ID == Id)
                {
                    modelFoods.listSnack.Remove(f);
                }

            }
        }
        /// <summary>
        /// add food to database
        /// </summary>
        /// <param name="food"></param>
        public void FoodFunc(BE.Food food)
        {
            modelFoods.AddFood(food);
        }
        /// <summary>
        /// return list of food according to date, id, meal to view the list
        /// </summary>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <param name="meal"></param>
        /// <returns></returns>
        public List<BE.Food> ListOfFoodsInDate(DateTime date,String id,String meal)
        {
            return modelFoods.ListOfFoodsInDate( date,  id,  meal);
        }
        
        /// <summary>
        /// add food to list in view and database of breakfast
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void AddFoodBreakfast(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            VMFoods vM = d as VMFoods;
            BE.Food food = new BE.Food();
            food.Description = (String) e.NewValue;
            food.Date = DateTime.Parse(vM.Date);
            food.ID = vM.Id;
            food.ndbo = "0";
            food.Amount = "1";
            food.Meal = "Breakfast";
            if (food.Description != "" && food.Description != null)
            {
                vM.FoodsBreakfast.Add(food);
                vM.FoodFunc(food);

            }
            vM.initAllListsOfFood();
        }

        /// <summary>
        /// add food to list in view and database of dinner
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void AddFoodDinner(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VMFoods vM = d as VMFoods;
            BE.Food food = new BE.Food();
            food.Description = (String)e.NewValue;
            food.Date = DateTime.Parse(vM.Date);
            food.ID = vM.Id;
            food.ndbo = "0";
            food.Amount = "1";
            food.Meal = "Dinner";
            if (food.Description != "" && food.Description != null)
            {
                vM.FoodsDinner.Add(food);
                vM.FoodFunc(food);
            }
            vM.initAllListsOfFood();

        }

        /// <summary>
        /// add food to list in view and database of lunch
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void AddFoodLunch(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VMFoods vM = d as VMFoods;
            BE.Food food = new BE.Food();
            food.Description = (String)e.NewValue;
            food.Date = DateTime.Parse(vM.Date);
            food.ID = vM.Id;
            food.ndbo = "0";
            food.Amount = "1";
            food.Meal = "Lunch";
            if (food.Description != "" && food.Description != null)
            {
                vM.FoodsLunch.Add(food);
                vM.FoodFunc(food);
            }
            vM.initAllListsOfFood();
        }

        /// <summary>
        /// add food to list in view and database of snack
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void AddFoodSnack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VMFoods vM = d as VMFoods;
            BE.Food food = new BE.Food();
            food.Description = (String)e.NewValue;
            food.Date = DateTime.Parse(vM.Date);
            food.ID = vM.Id;
            food.ndbo = "0";
            food.Amount = "1";
            food.Meal = "Snack";
            if (food.Description != "" && food.Description != null)
            {
                vM.FoodsSnack.Add(food);
                vM.FoodFunc(food);
            }
            vM.initAllListsOfFood();
        }

        /// <summary>
        /// intialization and add all food in new date 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="lst"></param>
        public void addToCollection(ObservableCollection<BE.Food> collection, List<BE.Food> lst)
        {
            int counter = collection.Count;
            for (int i = counter; i > 0; i--)
            {
                collection.Remove(collection[i - 1]);
            }
            if (lst.Count != 0)
            {
                foreach (BE.Food Item in lst)
                {
                    collection.Add(Item);
                }
            }
        }

        /// <summary>
        /// when the date update initialization all lists of observerable
        /// </summary>
        public void initAllListsOfFood()
        {

            List<BE.Food> foodExist = new List<BE.Food>();
            foodExist = ListOfFoodsInDate(DateTime.Parse(Date), Id, "Breakfast");
            addToCollection(FoodsBreakfast, foodExist);

            foodExist = ListOfFoodsInDate(DateTime.Parse(Date), Id, "Dinner");
            addToCollection(FoodsDinner, foodExist);

            foodExist = ListOfFoodsInDate(DateTime.Parse(Date), Id, "Lunch");
            addToCollection(FoodsLunch, foodExist);

            foodExist = ListOfFoodsInDate(DateTime.Parse(Date), Id, "Snack");
            addToCollection(FoodsSnack, foodExist);
        }
    }
}
