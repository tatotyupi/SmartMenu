using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartMenu.Domain.FoodsAggregate.State
{
    public class Food : Entity
    {
        public Food() { }
        public Food(
            FoodType foodType,
            string name,
            decimal price,
            string description,
            string makingTime,
            string photoName,
            IEnumerable<FoodIngredients> foodIngredients
            )
            : this(
                 Guid.NewGuid(),
                 foodType,
                 name,
                 price,
                 description,
                 makingTime,
                 photoName,
                 new CustomJsonSerializer().SerializeObject(foodIngredients)
                 )
        {

        }
        public Food(
            Guid EntityKey,
            FoodType foodType,
            string name,
            decimal price,
            string description,
            string makingTime,
            string photoName,
            string foodIngredients
            )
        {
            this.EntityKey = EntityKey;
            FoodType = foodType;
            Name = name;
            Price = price;
            Description = description;
            MakingTime = makingTime;
            PhotoName = photoName;
            FoodIngredients = foodIngredients;
        }
        [DomainKey]
        public Guid EntityKey { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public FoodType FoodType { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; private set; }
        public string Description { get; set; }
        public string MakingTime { get; set; }
        public string PhotoName { get; set; }
        public string FoodIngredients { get; set; }
    }
}
