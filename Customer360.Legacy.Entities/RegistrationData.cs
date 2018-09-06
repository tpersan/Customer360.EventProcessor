using System;
using System.Collections.Generic;

namespace Customer360.Legacy.Entities
{
    public class RegistrationData
    {
        public RegistrationData()
        {
            Addresses = new List<Address>();
            Phones = new List<Phone>();
            Emails = new List<Email>();
        }

        public string CustomerName { get; set; }
        public long CustomerDocument { get; set; }
        public DateTime BornDate { get; set; }
        public string RegistrationId { get; set; }
        public string ExternalId { get; set; }

        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
    }

    public class Email
    {
        public string EmailAddress { get; set; }
    }

    public class Phone
    {
        public int ddd { get; set; }
        public long Number { get; set; }
    }

    public class Address
    {
        public long AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string Number { get; set; }
        public string AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}