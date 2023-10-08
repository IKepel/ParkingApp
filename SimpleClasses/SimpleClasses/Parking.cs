using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ParkingApp.SimpleClasses
{
    public class Parking
    {
        private List<Car> _cars = new();

        private List<int> _check = new();

        public int AvailableSpots => Capacity - _check.Count;

        public int ParkingId { get; private set; }

        public string ParkingName { get; private set; }

        public string ParkingAddress { get; private set; }

        public int Capacity { get; private set; }

        public Parking(int parkingId, string name, string address, int capacity)
        {
            ParkingId = parkingId;
            ParkingName = name;
            ParkingAddress = address;
            Capacity = capacity;
            
        }

        public void AddCar (Car car)
        {
            if (AvailableSpots > 0) 
            {
                _cars.Add(car);
                car.ArrivalTime = DateTime.Now;

                var random = new Random();
                var randomNumber = random.Next(1, Capacity + 1);

                while (true)
                {
                    if(!_check.Contains(randomNumber))
                    {
                        _check.Add(randomNumber);
                        car.TicketNumber = randomNumber;
                        break;
                    }
                    else
                    {
                        randomNumber = random.Next(1, Capacity + 1);
                    }
                }

                Console.WriteLine($"Car {car.Brand} {car.Model} with the number {car.TicketNumber} is parked.");
            }
            else Console.WriteLine("There are not free seats");
        }

        public void RemoveCar (int number) 
        {
            var carToRemove = _cars.Find(car => car.TicketNumber == number);
            if (carToRemove != null)
            {
                _cars.Remove(carToRemove);
                _check.Remove(number);
                carToRemove.DepartureTime = DateTime.Now;
                Console.WriteLine($"Car {carToRemove.Brand} {carToRemove.Model} with license plate number {carToRemove.TicketNumber} has left the parking lot");

                int availableSpots = AvailableSpots;
                Console.WriteLine($"Available parking spots at Parking {ParkingName}: {availableSpots}");
            }
            else Console.WriteLine($"The car with license plate {number} was not found in the parking lot.");
        }

        public void DisplayCars()
        {
            Console.WriteLine("Cars in the parking lot:");
            foreach (Car car in _cars)
            {
                Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}, Color: {car.Color}, number: {car.TicketNumber}, Time of arrival: {car.ArrivalTime}");
            }
        }

        public string GetStateMessage()
        {
            return $"Available places: {AvailableSpots}, Occupied places: {_check.Count}";
        }
    }
}
