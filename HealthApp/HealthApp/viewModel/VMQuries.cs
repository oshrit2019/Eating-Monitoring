using HealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthApp.viewModel
{
    //view model of qury user control
    public class VMQuries : DependencyObject
    {
        public ModelQuries model;
        /// <summary>
        /// constructor
        /// </summary>
        public VMQuries()
        {
            model = new ModelQuries();
            // ImageUri = "C:\\Users\\owner\\Desktop\\לימודים\\שנה ג\\סמסטר ב\\חלונות\\healthApp\\HealthApp_23\\HealthApp\\HealthApp\\images\\fruit2.jpg";
            filterComponent("a ");

        }

        private String filter;
        public String Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                filterComponent(Filter);
            }
        }
        public String food { get; set; }
        //dependecy property of the food that select from usercontrol auto complate
        public String DescriptionFood
        {
            get { return (String)GetValue(DescriptionFoodProperty); }
            set { SetValue(DescriptionFoodProperty, value); }
        }
        public static readonly DependencyProperty DescriptionFoodProperty =
           DependencyProperty.Register("DescriptionFood", typeof(String), typeof(VMQuries), new UIPropertyMetadata(new PropertyChangedCallback(updateFood)));
        //depedency property of the text that say how many have from someone component that selected from combobox
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(String), typeof(VMQuries), new PropertyMetadata(""));
        //dependecy property to text to write Remarks
        public String TextRemarks
        {
            get { return (String)GetValue(TextRemarksProperty); }
            set { SetValue(TextRemarksProperty, value); }
        }
        public static readonly DependencyProperty TextRemarksProperty =
           DependencyProperty.Register("TextRemarks", typeof(String), typeof(VMQuries), new PropertyMetadata(""));
        //dependency property to Source of image\
        public String ImageUri
        {
            get { return (String)GetValue(ImageUriProperty); }
            set { SetValue(ImageUriProperty, value); }
        }
        public static readonly DependencyProperty ImageUriProperty =
           DependencyProperty.Register("ImageUri", typeof(String), typeof(VMQuries), new PropertyMetadata(""));

        public String Image2
        {
            get { return (String)GetValue(Image2Property); }
            set { SetValue(Image2Property, value); }
        }
        public static readonly DependencyProperty Image2Property =
           DependencyProperty.Register("Image2", typeof(String), typeof(VMQuries), new PropertyMetadata(""));


        /// <summary>
        /// filtering Component and change text
        /// </summary>
        /// <param name="filter"></param>
        private void filterComponent(String filter)
        {
            string[] _Component = filter.Split(' ');
            String compomnent = _Component[1];
            BE.Component c = new BE.Component();
            String food1 = food;
            if (food1 != "" && food1 != null)//when the text in user auto complate is null or empty
            {
                c = model.ReturnComponent(food1);
            }
            //action that doing according to component that choose
            switch (compomnent)
            {
                case "Energy":
                    Text = "The amount of energy is " + c.Energy;
                    ImageUri = "/images/אנרגיה.jpg";
                    TextRemarks = "If you have burned calories during the day, energy supplementation should be appropriate.";
                    Image2 = "/images/סימןשאלה.png";

                    break;
                case "Water":
                    Text = "The amount of water is " + c.Water;
                    ImageUri = "/images/מים1.jpg";
                    TextRemarks = "Water is important for the body and the most basic.";
                    Image2 = "/images/סימןשאלה.png";
                    break;
                case "Protien":
                    Text = "The amount of Protein is " + c.Protien;
                    ImageUri = "/images/חלבונים1.jpg";
                    TextRemarks = "Protein contributes a lot to building cells and tissues, eating foods with protein!!";
                    Image2 = "/images/סימןשאלה.png";

                    break;
                case "Fats":
                    Text = "The amount of Fats is " + c.Fats;
                    ImageUri = "/images/fats1.jpg";
                    TextRemarks = "fats!?, It's fattening.!!";
                    Image2 = "/images/סימןשאלה.png";

                    break;
                case "Fiber":
                    Text = "The amount of Fiber is " + c.Fiber;
                    ImageUri = "/images/סיבים1.jpg";
                    TextRemarks = "Dietary fiber is essential for preventing disease and reducing or maintaining normal weight";
                    Image2 = "/images/סימןשאלה.png";

                    break;
                case "Carbohydrate":
                    Text = "The amount of Carbohydrate is " + c.Carbohydrate;
                    ImageUri ="/images/פחמימות1.jpg";
                    TextRemarks = "The word carbohydrate means sugar, meaning the word sugar is synonymous with carbohydrate.";
                    Image2 = "/images/סימןשאלה.png";
                    break;
                case "Sugars":
                    Text = "The amount of Sugars is " + c.Sugar;
                    ImageUri ="/images/סוכר.jpg";
                    TextRemarks = "Be careful, Consuming excessive sugar can be harmful!!";
                    Image2 = "/images/סימןשאלה.png";

                    break;
                case "Vitamins":
                    Text = "The amount of Vitamins is " + c.Vitamins;
                    ImageUri = "/images/ויטמינים1.jpg";
                    TextRemarks = "Vitamins are essential for preventing diseases such as anemia, and reducing the risk of contracting diseases such as cancer and heart disease. Many of the vitamins are antioxidants.";
                    Image2 = "/images/סימןשאלה.png";

                    break;
                default:
                    Text = "";
                    ImageUri = "/images/פירות1.jpg";
                    TextRemarks = "";
                    Image2 = "";

                    break;

            }
            // c = model.SumOfComponents(Id, DateTime.Now, time);

        }
        /// <summary>
        /// when the user choose food we update the food property
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void updateFood(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            VMQuries vm = d as VMQuries;
            String food1 = (String)e.NewValue;
            vm.Text = "";
            vm.ImageUri = "/images/פירות1.jpg";
            vm.TextRemarks = "";
            vm.Image2 = "";

            if (food1 != null && food1 != "")
            {
                vm.food = food1;
            }

        }
    }
}
