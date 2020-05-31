using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.FoodsAggregate.Message;
using SmartMenu.Domain.FoodsAggregate.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.FoodsAggregate.Scenarios
{
    public class CreateFoodScenario : CommandsHandler<Food, CreateFoodCommand>
    {
        private readonly CommandHandler<Food, CreateFoodCommand> _food;

        public CreateFoodScenario(CommandHandler<Food,CreateFoodCommand> food)
        {
            _food = food;
        }
        public IEnumerable<Entity> Handle(Food state, CreateFoodCommand command)
        {
            var createFoodState = _food
                                .Handle(
                                    state,
                                    command
                                    );

            return new List<Entity> { createFoodState };
        }
    }
}
