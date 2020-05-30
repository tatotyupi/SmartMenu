using SmartMenu.Domain.CompanyAggregate.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Web.Api.Model
{
    public class RegisterCompanyRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string CompanyId { get; set; }
        public string PhoneNumber { get; set; }

        public RegisterCompanyScenarionCommand Result()
        {
            return new RegisterCompanyScenarionCommand
            {
                Name = Name,
                Email = Email,
                PhotoUrl = PhotoUrl,
                CompanyId = CompanyId,
                PhoneNumber = PhoneNumber
            };
        }
    }
}
