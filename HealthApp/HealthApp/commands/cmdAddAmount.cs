using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthApp.commands
{
    //command - when click button + add to amuont
    public class cmdAddAmount : ICommand
    {
        public VMFoods vm;
        public String Id { get; set; }
        public cmdAddAmount(VMFoods Avm, String id)
        {
            vm = Avm;
            Id = id;
        }
        public event EventHandler CanExecuteChanged
        {

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (Object[])parameter;
            BE.Food food = new BE.Food();
            food.ID = Id;
            food.key = 0;
            food.Meal = values[0].ToString();
            food.Description = values[1].ToString();
            food.Date = DateTime.Parse(values[2].ToString());
            food.ndbo = "0";
            food.Amount = "0";
            vm.addAmountFood(food);//call to function in vm that add 1 to amount to this food
        }
    }
}
