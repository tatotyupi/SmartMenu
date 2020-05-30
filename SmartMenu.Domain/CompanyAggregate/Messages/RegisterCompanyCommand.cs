using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.CompanyAggregate.Messages
{
    public class RegisterCompanyCommand
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string PhoneNumber { get; set; }
    }
}
