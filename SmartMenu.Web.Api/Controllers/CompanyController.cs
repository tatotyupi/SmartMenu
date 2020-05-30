using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmartMenu.Web.Api.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            [HttpPost]
            public IActionResult Register(RegisterCompanyRequest registerCompanyRequest)
            {
                return Ok(
                          new Handler<Company, RegisterCompanyScenarionCommand>(
                              new RegisterCompanyScenario(
                                  new RegisterCompany(),
                                  new CreateEmployee()
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
}
