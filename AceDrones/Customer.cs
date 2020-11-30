using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceDrones
{
    class Customer
    {
        private int customerID;
        static int staticID = 900;
        private string name;
        private string city;
        private string country;

        public Customer()
        {

        }

        // Constructor for No data input
        public Customer(int cId, string n, string c, string co)
        {
            
            if (string.IsNullOrEmpty(n) && string.IsNullOrEmpty(c) && string.IsNullOrEmpty(co))
            {
                customerID = 999;
                name = "unknown";
                city = "unknown";
                country = "unknown";
            }
            else
            {
                if (cId == 0)
                {
                    customerID = staticID;
                    staticID++;
                }
                else
                {
                    customerID = cId;
                    if (!(cId == 0))
                    {
                        staticID++;
                    }
                }
                name = n;
                city = c;
                country = co;
            }
        }

        public int CustomerID { get => customerID; set => customerID = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
    }
}
