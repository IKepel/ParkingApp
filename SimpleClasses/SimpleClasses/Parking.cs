using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ParkingApp.SimpleClasses
{
    public class Parking : IDisposable
    {
        private List<Car> _cars = new();

        private int _availableSpots => Capacity - _cars.Count;

        public int ParkingId { get; private set; }

        public string ParkingName { get; private set; }

        public string ParkingAddress { get; private set; }

        public int Capacity { get; private set; }

        /// <summary>
        /// Object Parking
        /// </summary>
        /// <param name="parkingId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="capacity"></param>
        public Parking(int parkingId, string name, string address, int capacity)
        {
            ParkingId = parkingId;
            ParkingName = name;
            ParkingAddress = address;
            Capacity = capacity;
        }

        /// <summary>
        /// Object Parking with default params
        /// </summary>
        public Parking()
        {
            ParkingId = 0;
            ParkingName = "Unknown";
            ParkingAddress = "Unknown";
            Capacity = 10;
        }

        /// <summary>
        /// Add a car to the collection
        /// </summary>
        /// <param name="car"></param>
        public void AddCar (Car car)
        {
            if (_availableSpots > 0) 
            {
                _cars.Add(car);
                car.ArrivalTime = DateTime.Now;
                Console.WriteLine($"Car {car.Brand} {car.Model} is parked.");
            }
            else Console.WriteLine("There are not free seats");
        }

        /// <summary>
        /// Add a default car to the collection
        /// </summary>
        public void AddCar()
        {  
            var defaultCar = new Car();
            AddCar(defaultCar);
        }

        /// <summary>
        /// Remove a car from the collection by id
        /// </summary>
        /// <param name="number"></param>
        public void RemoveCar (int number) 
        {
            var carToRemove = _cars.Find(car => car.Id == number);
            if (carToRemove != null)
            {
                RemoveCarAndUpdateState(carToRemove);
            }
            else Console.WriteLine($"The car with id = {number} was not found in the parking lot.");
        }

        /// <summary>
        /// Remove a car from the collection by brand and model
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        public void RemoveCar(string brand, string model)
        {
            var carToRemove = _cars.Find(car => car.Brand == brand && car.Model == model);
            if (carToRemove != null)
            {
                RemoveCarAndUpdateState(carToRemove);
            }
            else Console.WriteLine($"The car with brand = {brand} and model = {model} was not found in the parking lot.");
        }

        /// <summary>
        /// Show the machines on the screen 
        /// </summary>
        public void DisplayCars()
        {
            Console.WriteLine("Cars in the parking lot:");
            foreach (var car in _cars)
            {
                Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}, Color: {car.Color}, Time of arrival: {car.ArrivalTime}");
            }
        }

        /// <summary>
        /// Show the machines on the screen with ArrivalTime or without
        /// </summary>
        /// <param name="showArrivalTime"></param>
        public void DisplayCars(bool showArrivalTime)
        {
            Console.WriteLine("Cars in the parking lot:");
            foreach (var car in _cars)
            {
                if (showArrivalTime)
                {
                    Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}, Color: {car.Color}, Time of arrival: {car.ArrivalTime}");
                }
                else
                {
                    Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}, Color: {car.Color}");
                }
            }
        }

        /// <summary>
        /// Show available, occupied seats
        /// </summary>
        /// <returns></returns>
        public string GetStateMessage() => $"Available places: {_availableSpots}, Occupied places: {_cars.Count}";

        /// <summary>
        /// Show available, occupied seats and capasity or without
        /// </summary>
        /// <param name="includeCapacity"></param>
        /// <returns></returns>
        public string GetStateMessage(bool includeCapacity)
        {
            if (includeCapacity)
            {
                return $"Available places: {_availableSpots}, Occupied places: {_cars.Count}, Total capacity: {Capacity}";
            }
            else return $"Available places: {_availableSpots}, Occupied places: {_cars.Count}";
        }

        /// <summary>
        /// Clears the collection of cars and updates their departure times, making the parking free for the night.
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine("Parking has been made free for the night");
            foreach (var car in _cars)
            {
                car.DepartureTime = DateTime.Now;
            }
            _cars.Clear();
        }

        /// <summary>
        /// The method performs a vehicle removal operation and updates the parking status information
        /// </summary>
        /// <param name="carToRemove"></param>
        private void RemoveCarAndUpdateState(Car carToRemove)
        {
            _cars.Remove(carToRemove);
            carToRemove.DepartureTime = DateTime.Now;
            Console.WriteLine($"Car {carToRemove.Brand} {carToRemove.Model} has left the parking lot");
            Console.WriteLine(GetStateMessage());
        }
    }
}