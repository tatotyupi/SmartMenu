using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.DbContext.Infrastructure
{
    public class SmartMenuDbContextFactory : Factory<SmartMenuDbContext>
    {
        private readonly string _connectionString;

        public SmartMenuDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SmartMenuDbContext Make()
        {
            return new SmartMenuDbContext(_connectionString);
        }
    }
}
