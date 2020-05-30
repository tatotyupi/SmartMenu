using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MMenu.DbContext;
using MMenu.Domain.Infrastructure;
using SmartMenu.DbContext.Infrastructure;
using SmartMenu.Domain.CompanyAggregate.Behaviors;
using SmartMenu.Domain.CompanyAggregate.Messages;
using SmartMenu.Domain.CompanyAggregate.Scenarios;
using SmartMenu.Domain.CompanyAggregate.State;
using SmartMenu.Web.Api.Model;

namespace SmartMenu.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class CompanyController : Controller
    {
        private readonly SmartMenuDbContextFactory _dbContext;

        public CompanyController(
                      SmartMenuDbContextFactory dbContext
               )
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Register(RegisterCompanyRequest registerCompanyRequest)
        {
            return Ok(
                      new Handler<Company, RegisterCompanyScenarionCommand>(
                          new RegisterCompanyScenario(
                              new RegisterCompany()
                            ),
                            new EntityRepository(_dbContext),
                            "Default"
                          )
                          .Handle(
                              new Company(),
                              registerCompanyRequest.Result()
                          )
                    );
        }
    }
}
