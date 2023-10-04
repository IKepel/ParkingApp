using ParkingApp.SimpleClasses;

var parking = new Parking();

var car1 = new Car("Audi", "A6", "Black");
var car2 = new Car("BMW", "X5", "Gray");
var car3 = new Car("Toyota", "Camry", "White");

parking.AddCar(car1);
parking.AddCar(car2);
parking.AddCar(car3);

Console.WriteLine();
parking.DisplayCars();

Console.WriteLine();
parking.RemoveCar(1);

Console.WriteLine();
parking.DisplayCars();