﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Customer360.Legacy.Entities
{
    public class RegistrationData
    {
        public string CustomerName { get; set; }
        public long CustomerDocument { get; set; }
        public DateTime BornDate { get; set; }
        public string RegistrationId { get; set; }
        public string ExternalId { get; set; }

        public List<Address> Addresses { get; private set; }
        public List<Phone> Phones { get; private set; }
        public List<Email> Emails { get; private set; }

        public void InsertAddress(Address newAddress)
        {
            if (Addresses == null)
                Addresses = new List<Address>();

            if (Addresses.Exists(ad => ad.AddressId == newAddress.AddressId))
                return;

            Addresses.Add(newAddress);
        }

        public void InsertPhone(Phone newPhone)
        {
            if (Phones == null)
                Phones = new List<Phone>();

            if (Phones.Exists(ph => ph.PhoneId == newPhone.PhoneId))
                return;

            Phones.Add(newPhone);
        }

        public void InsertEmail(Email newEmail)
        {
            if (Emails == null)
                Emails = new List<Email>();

            if (Emails.Exists(ph => ph.EmailId == newEmail.EmailId))
                return;

            Emails.Add(newEmail);
        }

    }

    public class Address
    {
        [JsonIgnore]
        public long AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string HomeNumber { get; set; }
        public string AddressComplement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }

    public class Phone
    {
        [JsonIgnore]
        public long PhoneId { get; set; }
        public int Ddd { get; set; }
        public long PhoneNumber { get; set; }
    }


    public class Email
    {
        public long EmailId { get; set; }
        public short EmailType { get; set; }
        public string RemoteAddress { get; set; }
    }

}