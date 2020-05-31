using SmartMenu.Domain.FoodsAggregate.Message;
using SmartMenu.Domain.FoodsAggregate.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Web.Api.Controllers.FoodControler.Commands
{
    public class FoodRequest
    {
        public FoodType FoodType { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string MakingTime { get; set; }
        public string PhotoName { get; set; }
        public IEnumerable<FoodIngredients> FoodIngredients { get; set; }

        public CreateFoodCommand Result()
        {
            return new CreateFoodCommand
            {
                FoodType = FoodType,
                Name = Name,
                Price = Price,
                Description = Description,
                MakingTime = MakingTime,
                PhotoName = PhotoName,
                FoodIngredients = FoodIngredients
            };
        }
    }
}
