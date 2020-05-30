using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartMenu.DbContext.Infrastructure
{
    public class Aggregate
    {
        [Key]
        public int Id { get;  set; }
        public string EntityKey { get;  set; }
        public string Name { get;  set; }
        public string State { get;  set; }
    }
}
