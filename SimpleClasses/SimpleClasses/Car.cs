using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.SimpleClasses
{
    public class Car
    {
        public string Brand { get; set; }
        
        public string Model { get; set; }

        public string Color { get; set; }

        public int Number { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime  { get; set; }
        
        public Car(string brand, string model, string color) 
        {
            Brand = brand;
            Model = model;
            Color = color;
            DepartureTime = DateTime.MinValue;
        }
    }
}