using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.SimpleClasses
{
    public class Car
    {
        public string Brand { get; set; }
        
        public string Model { get; set; }

        public Color Color { get; set; }

        public int TicketNumber { get; set; }

        public string CarNumber { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime  { get; set; }
        
        public Car(string brand, string model, Color color, string carNumber) 
        {
            Brand = brand;
            Model = model;
            Color = color;
            CarNumber = carNumber;
            DepartureTime = DateTime.MinValue;
        }

        public void ChangeColor(Color newColor)
        {
            Color = newColor;
        }
    }
}