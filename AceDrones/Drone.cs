using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceDrones
{
    class Drone
    {
        private int serialNumber;
        static int staticSN = 100;
        private string model;
        private string engineConfiguration;
        private string range;
        private string accessories;
        private int price;
        private DateTime purchaseDate = new DateTime();

        public Drone()
        {

        }

        // Constructor
        public Drone(int s, string m, string e, string r, string a, int p, DateTime d)
        {
            if (s == 0)
            {
                serialNumber = staticSN;
                staticSN += 10;
            }
            else
            {
                serialNumber = s;
                staticSN += 10;
            }
            model = m;
            engineConfiguration = e;
            range = r;
            accessories = a;
            price = p;
            purchaseDate = d;
        }

        public int SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Model { get => model; set => model = value; }
        public string EngineConfiguration { get => engineConfiguration; set => engineConfiguration = value; }
        public string Range { get => range; set => range = value; }
        public string Accessories { get => accessories; set => accessories = value; }
        public int Price { get => price; set => price = value; }
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
    }
}
