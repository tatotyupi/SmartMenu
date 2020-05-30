using MMenu.Domain.Infrastructure;
using SmartMenu.Domain.CompanyAggregate.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.CompanyAggregate.Messages
{
    public class RegisterCompanyScenarionCommand : ICommand<Company>
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string PhoneNumber { get; set; }

        public object EntityId()
        {
            throw new NotImplementedException();
        }
    }
}
