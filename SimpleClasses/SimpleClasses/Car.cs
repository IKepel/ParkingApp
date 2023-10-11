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

        public int Id { get; set; }

        public string CarNumber { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepartureTime  { get; set; }

        /// <summary>
        /// Object Car with default params
        /// </summary>
        public Car()
        {
            Id = 0;
            Brand = "Unknown";
            Model = "Unknown";
            Color = new Color();
            CarNumber = "Unknown";
            DepartureTime = DateTime.MinValue;
        }

        /// <summary>
        /// Object Car
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="carNumber"></param>
        public Car(int id, string brand, string model, Color color, string carNumber) 
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            CarNumber = carNumber;
            DepartureTime = DateTime.MinValue;
        }

        /// <summary>
        /// Object Car with default color
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="carNumber"></param>
        public Car(int id, string brand, string model, string carNumber)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = new Color();
            CarNumber = carNumber;
            DepartureTime = DateTime.MinValue;
        }

        /// <summary>
        /// Changes the color of the object to the specified new color.
        /// </summary>
        /// <param name="newColor"></param>
        public void ChangeColor(Color newColor) => Color = newColor;
    }
}