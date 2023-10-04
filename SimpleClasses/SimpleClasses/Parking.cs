using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.SimpleClasses
{
    public class Parking
    {
        private List<Car> cars = new List<Car>();

        private List<int> check = new List<int>();

        public void AddCar (Car car)
        {
            cars.Add(car);
            car.ArrivalTime = DateTime.Now;

            var random = new Random();
            var randomNumber = random.Next(1, 4);

            while (true)
            {
                if(!check.Contains(randomNumber))
                {
                    check.Add(randomNumber);
                    car.Number = randomNumber;
                    break;
                }
                else
                {
                    randomNumber = random.Next(1, 4);
                }
            }

            Console.WriteLine($"Car {car.Brand} {car.Model} with the number {car.Number} is parked.");
        }

        public void RemoveCar (int number) 
        {
            var carToRemove = cars.Find(car => car.Number == number);
            if (carToRemove != null)
            {
                cars.Remove(carToRemove);
                check.Remove(number);
                carToRemove.DepartureTime = DateTime.Now;
                Console.WriteLine($"Car {carToRemove.Brand} {carToRemove.Model} with license plate number {carToRemove.Number} has left the parking lot");
            }
            else Console.WriteLine($"The car with license plate {number} was not found in the parking lot.");
        }

        public void DisplayCars()
        {
            Console.WriteLine("Cars in the parking lot:");
            foreach (Car car in cars)
            {
                Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}, number: {car.Number}, Time of arrival: {car.ArrivalTime}");
            }
        }
    }
}