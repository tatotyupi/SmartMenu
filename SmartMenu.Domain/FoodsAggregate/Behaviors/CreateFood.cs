using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.FoodsAggregate.Message;
using SmartMenu.Domain.FoodsAggregate.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.FoodsAggregate.Behaviors
{
    public class CreateFood : CommandHandler<Food, CreateFoodCommand>
    {
        public Food Handle(Food state, CreateFoodCommand command)
        {
            return new Food(
                        command.FoodType,
                        command.Name,
                        command.Price,
                        command.Description,
                        command.MakingTime,
                        command.PhotoName,
                        command.FoodIngredients
                        );
        }

    }
}
