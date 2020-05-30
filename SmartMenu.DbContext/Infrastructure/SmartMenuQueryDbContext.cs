using Microsoft.EntityFrameworkCore;
using SmartMenu.DbContext.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.DbContext
{
    public partial class SmartMenuDbContext
    {
        public DbSet<SmartMenus> SmartMenus { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
             .Entity<SmartMenus>(eb =>
             {
                 eb.HasNoKey();
                 eb.ToView(nameof(Views.SmartMenus));
             });
        }
    }
}
