using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceDrones
{
    class Customer
    {
        private string customerID;
        private string name;
        private string city;
        private string country;

        public Customer()
        {

        }

        // Constructor for No data input
        public Customer(string cId, string n, string c, string co)
        {
            if (string.IsNullOrEmpty(cId))
            {
                customerID = "C999";
            }
            else
            {
                customerID = cId;
            }
            if (string.IsNullOrEmpty(n))
            {
                name = "unknown";
            }
            else
            {
                name = n;
            }
            if (string.IsNullOrEmpty(c))
            {
                city = "unknown";
            }
            else
            {
                city = c;
            }
            if (string.IsNullOrEmpty(co))
            {
                country = "unknown";
            }
            else
            {
                country = co;
            }
        }

        public string CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
    }
}
