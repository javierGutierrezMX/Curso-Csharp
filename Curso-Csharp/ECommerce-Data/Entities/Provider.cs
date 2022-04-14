using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Data.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }

        public Provider(int id, string name, string emailAddress)
        {
            Id = id;
            Name = name == null ? throw new InvalidOperationException(" Null value in  \"Name\"") : name;
            EmailAddress = new System.Net.Mail.MailAddress(emailAddress).Address;
        }

        public void SetAddres(string address, string city)
        {
            Address = address == null ? throw new InvalidOperationException(" Null value in  \"address\"") : address;
            City = city == null ? throw new InvalidOperationException(" Null value in  \"city\"") : city;
        }
        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = (phoneNumber == null) || (phoneNumber.Length < 10) ? throw new InvalidOperationException(" Problem value in  \"phoneNumber\"") : phoneNumber;
        }
    }
}
