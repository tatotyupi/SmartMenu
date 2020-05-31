using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartMenu.DbContext;
using SmartMenu.DbContext.Infrastructure;

namespace SmartMenu.Web.Api.Controllers.FoodControler
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public partial class FoodController : ControllerBase
    {
        private readonly SmartMenuDbContextFactory _dbContext;

        public FoodController(SmartMenuDbContextFactory dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
