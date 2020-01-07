using HealthApp.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthApp.commands
{
    //command - when click button - substract 
    public class cmdMinusAmount : ICommand
    {
        public VMFoods vm { get; set; }
        public cmdMinusAmount(VMFoods Avm)
        {
            vm = Avm;
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
            food.ID = vm.Id;
            food.key = 0;
            food.Meal = values[0].ToString();
            food.Description = values[1].ToString();
            food.Date = DateTime.Parse(values[2].ToString());
            food.ndbo = "0";
            food.Amount = "0";
            vm.minusAmountFood(food);// call to function in vm that sub 1 from amount
        }
    }
}
