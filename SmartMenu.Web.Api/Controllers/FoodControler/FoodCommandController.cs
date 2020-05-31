using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMenu.DbContext;
using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.FoodsAggregate.Behaviors;
using SmartMenu.Domain.FoodsAggregate.Message;
using SmartMenu.Domain.FoodsAggregate.Scenarios;
using SmartMenu.Domain.FoodsAggregate.State;
using SmartMenu.Web.Api.Controllers.FoodControler.Commands;

namespace SmartMenu.Web.Api.Controllers.FoodControler
{
    public partial class FoodController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateFood(FoodRequest createFoodCommand)
        {
            new Handler<Food, CreateFoodCommand>(
                 new CreateFoodScenario(
                        new CreateFood()
                        ),
                 new EntityRepository(_dbContext)
                ).Handle(
                    new Food(), 
                    createFoodCommand.Result()
                );

            return Ok();
        }
    }
}
