using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.CompanyAggregate.Messages;
using SmartMenu.Domain.CompanyAggregate.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.CompanyAggregate.Scenarios
{
    public class RegisterCompanyScenario : CommandsHandler<Company, RegisterCompanyScenarionCommand>
    {
        private readonly CommandHandler<Company, RegisterCompanyCommand> registerCompany;

        public RegisterCompanyScenario(
                            CommandHandler<Company, RegisterCompanyCommand> registerCompany
               )
        {
            this.registerCompany = registerCompany;
        }


        public IEnumerable<Entity> Handle(Company entity, RegisterCompanyScenarionCommand msg)
        {
            var registerCompanyState = registerCompany
                                               .Handle(
                                                      entity,
                                                      new RegisterCompanyCommand
                                                      {
                                                          CompanyId = msg.CompanyId,
                                                          Email = msg.Email,
                                                          Name = msg.Name,
                                                          PhotoUrl = msg.PhotoUrl,
                                                          PhoneNumber = msg.PhoneNumber
                                                      }
                                               );

            return new List<Entity>()
            {
                registerCompanyState
            };
        }
    }
}
