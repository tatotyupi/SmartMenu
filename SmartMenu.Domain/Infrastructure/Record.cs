using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MMenu.Domain.Infrastructure
{
    public class DomainKeyAttribute : Attribute
    {

    }

    public class Entity : Record
    {
        public string Key { get; set; }
        public string KeyName { get; set; }
        public void Up()
        {
            var pi = this
                  .GetType()
                  .GetProperties()
                  .Where(prop => Attribute.IsDefined(prop, typeof(DomainKeyAttribute)))
                  .First();

            var value = pi.GetValue(this, null).ToString();

            Key = value;
            KeyName = pi.Name;
        }
    }

    public abstract class Record
    {
        private int _id;

        public bool IsCurrent { get; set; } = true;

        [Key]
        public int ID
        {
            get => 0;
            set => _id = value;
        }
    }
}
