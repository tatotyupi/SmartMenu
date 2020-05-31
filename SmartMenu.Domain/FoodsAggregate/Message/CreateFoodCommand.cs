using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.FoodsAggregate.State;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SmartMenu.Domain.FoodsAggregate.Message
{
    public class CreateFoodCommand : ICommand<Food>
    {
        public FoodType FoodType { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string MakingTime { get; set; }
        public string PhotoName { get; set; }
        public IEnumerable<FoodIngredients> FoodIngredients { get; set; }

        public object EntityId()
        {
            throw new NotImplementedException();
        }
    }
}
