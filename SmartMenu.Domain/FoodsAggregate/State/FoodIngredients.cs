using MMenu.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.FoodsAggregate.State
{
    public class FoodIngredients
    {
        public FoodIngredients() { }
        public FoodIngredients(
            string name,
            int quantity,
            int calories
            )
        {
            Name = name;
            Quantity = quantity;
            Calories = calories;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Calories { get; set; }
    }
}
