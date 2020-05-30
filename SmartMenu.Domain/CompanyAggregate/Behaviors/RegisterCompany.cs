using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.CompanyAggregate.Messages;
using SmartMenu.Domain.CompanyAggregate.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.CompanyAggregate.Behaviors
{
    public class RegisterCompany : CommandHandler<Company, RegisterCompanyCommand>
    {
        public Company Handle(Company state, RegisterCompanyCommand command)
        {
            return new Company(
                            command.CompanyId,
                            command.Name,
                            command.PhoneNumber,
                            command.Email,
                            command.PhotoUrl
                       );
        }
    }
}
