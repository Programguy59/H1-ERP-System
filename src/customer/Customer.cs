using H1_ERP_System.customer;
using H1_ERP_System.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_ERP_System.src.customer
{
    public class Customer : Person
    {
        private string CustomerId { get; }
        private string DateSinceLastPurchase { get; }
        public Customer(string customerId, string date, int id, string personFirstName, string personLastName, Address address, string email, string phoneNumber) 
            : base( id, personFirstName, personLastName, address, email, phoneNumber)
        {
            CustomerId = customerId;
            DateSinceLastPurchase = date;


        }

        public Customer(string customerId, string date, int id, string personFirstName, string personLastName, string email, string phoneNumber, string streetName, string streetNumber, string zipCode, string city, string country) 
            : base( id, personFirstName, personLastName, streetName,  streetNumber,  zipCode,  city,  country, email, phoneNumber)
        {
            CustomerId = customerId;
            DateSinceLastPurchase = date;


        }


    }
}
