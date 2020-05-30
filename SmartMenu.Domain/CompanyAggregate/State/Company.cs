using MMenu.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMenu.Domain.CompanyAggregate.State
{
    public class Company : Entity
    {
        public Company() { }

        public Company(
                   string companyId,
                   string name,
                   string phoneNumber,
                   string email,
                   string photoUrl
               ) : this(
                     companyId,
                     name,
                     phoneNumber,
                     email,
                     photoUrl,
                     DateTime.Now
                   )
        {

        }

        public Company(
                   string companyId,
                   string name,
                   string phoneNumber,
                   string email,
                   string photoUrl,
                   DateTime registerDate
               )
        {
            CompanyId = companyId;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            PhotoUrl = photoUrl;
            RegisterDate = registerDate;
        }

        [DomainKey]
        public string CompanyId { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string PhotoUrl { get; private set; }
        public DateTime RegisterDate { get; private set; }
    }
}
