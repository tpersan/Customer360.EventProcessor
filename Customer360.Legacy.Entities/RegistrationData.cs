using System;
using System.Collections.Generic;

namespace Customer360.Legacy.Entities
{
    public class RegistrationData
    {
        public long CustomerDocument { get; set; }
        public DateTime BornDate { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<Email> Emails { get; set; }
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
        public string StreetAddress { get; set; }
        public string Number { get; set; }
        public string AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}