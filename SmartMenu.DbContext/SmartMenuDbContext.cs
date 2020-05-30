using Microsoft.EntityFrameworkCore;
using SmartMenu.DbContext.Infrastructure;
using SmartMenu.Domain.CompanyAggregate.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.DbContext
{
    public partial class SmartMenuDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public SmartMenuDbContext(string connectionString)
            : this(new DbContextOptionsBuilder<SmartMenuDbContext>().UseSqlServer(connectionString).Options)
        {

        }
        public SmartMenuDbContext(DbContextOptions<SmartMenuDbContext> options) :base(options)
        {

        }
        public DbSet<Aggregate> Aggregates { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
