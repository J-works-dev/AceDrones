using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceDrones
{
    class Drone
    {
        private string serialNumber;
        private string model;
        private string engineConfiguration;
        private string range;
        private string accessories;
        private string price;
        private string purchaseDate;

        public Drone()
        {

        }

        // Constructor
        public Drone(string s, string m, string e, string r, string a, string p, string d)
        {
            serialNumber = s;
            model = m;
            engineConfiguration = e;
            range = r;
            accessories = a;
            price = p;
            purchaseDate = d;
        }

        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Model { get => model; set => model = value; }
        public string EngineConfiguration { get => engineConfiguration; set => engineConfiguration = value; }
        public string Range { get => range; set => range = value; }
        public string Accessories { get => accessories; set => accessories = value; }
        public string Price { get => price; set => price = value; }
        public string PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
    }
}
