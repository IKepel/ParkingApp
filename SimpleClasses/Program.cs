using ParkingApp.SimpleClasses;

var parking = new Parking(1, "MyParking", "123 Main St", 3);

var newColor = new Color(0, 0, 255, 100);

var car1 = new Car("Audi", "A6", new Color(0, 0, 0 , 100), "AB123CV");
var car2 = new Car("BMW", "X5", new Color(0, 255, 0, 100), "DC456RE");
var car3 = new Car("Toyota", "Camry", new Color(255, 255, 255, 100), "ES789PI");

parking.AddCar(car1);
parking.AddCar(car2);
parking.AddCar(car3);

Console.WriteLine();
parking.DisplayCars();

car2.ChangeColor(newColor);

Console.WriteLine();
Console.WriteLine(parking.GetStateMessage());

Console.WriteLine();
parking.RemoveCar(1);

Console.WriteLine();
parking.DisplayCars();

Console.WriteLine();
Console.WriteLine(parking.GetStateMessage());