using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthApp
{
    /// <summary>
    /// Interaction logic for UserControlAutoComplete.xaml
    /// </summary>
    public partial class UserControlAutoComplete : UserControl
    {
        public UserControlAutoComplete()
        {
            InitializeComponent();
            textInput.DataContext = this;
            bl = new BL.BL_Imp();
        }
        public BL.IBL bl { get; set; }
        /// <summary>
        /// Defiend Dependency Property Text that selected
        /// </summary>
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(String), typeof(UserControlAutoComplete), new PropertyMetadata(""));

        public String ItemSelectedFood
        {
            get { return (String)GetValue(ItemSelectedFoodProperty); }
            set { SetValue(ItemSelectedFoodProperty, value); }
        }

        public static readonly DependencyProperty ItemSelectedFoodProperty =
           DependencyProperty.Register("ItemSelectedFood", typeof(String), typeof(UserControlAutoComplete), new PropertyMetadata(""));


        /// <summary>
        /// doing thread
        /// </summary>
        /// <param name="text"></param>
        void run(object text)
        {
            if (text != null)
            {
                try
                {
                    String address = bl.XmlFood(text.ToString());
                    List<String> result = bl.GetAllFood(address); //= BL.FactoryBl.GetBL().GetPlaceAutoComplete(text.ToString());
                    Action<List<String>> action = setListInvok;//point to function
                    Dispatcher.BeginInvoke(action, new object[] { result }); //The dispatcher wants to use BeginInvok to perform an action function
                }
                catch (Exception  ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        /// <summary>
        /// Updating the list in comboBox
        /// </summary>
        /// <param name="list"></param>
        private void setListInvok(List<String> list)
        {
            this.textComboBox.ItemsSource = null;

            if (list.Count > 0 && list[0].CompareTo(Text) != 0)
            //when list not is empty and the first element in the list is equal to  the selection Text
            {
                this.textComboBox.ItemsSource = list;
                textComboBox.IsDropDownOpen = true;//open the comoboBox
            }
            else
            {
                textComboBox.IsDropDownOpen = false;
            }
        }
        /// <summary>
        ///When the text changes, you start the thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thread thread = new Thread(run);
            thread.Start(Text);
        }
        /// <summary>
        /// When you select an address you will display it in text and close the comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = textComboBox.SelectedItem;
            if (item != null)//when the text not is empty
            {
                this.Text = item.ToString();
                textComboBox.IsDropDownOpen = false;
            }
        }

        /// <summary>
        /// Attempts to set focus to text ComboBox element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textInput_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            // When the key to the bottom is pressed 
            {
                this.textComboBox.Focus();
            }
        }
        /// <summary>
        /// Attempts to set focus to text Input element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textComboBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)
                //When the key to the up is pressed
                if (this.textComboBox.SelectedIndex == 0)
                    this.textInput.Focus();
        }
       
        }
    }
