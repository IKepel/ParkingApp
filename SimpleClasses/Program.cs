using ParkingApp.SimpleClasses;

using var parking = new Parking(1, "MyParking", "123 Main St", 4);

var newColor = new Color(0, 0, 255, 100);

var car1 = new Car(1 ,"Audi", "A6", "AB123CV");
var car2 = new Car(2, "BMW", "X5", new Color(0, 255, 0, 100), "DC456RE");
var car3 = new Car(3, "Toyota", "Camry", new Color(255, 255, 255, 100), "ES789PI");

Console.WriteLine(parking.GetStateMessage(true));
Console.WriteLine();

parking.AddCar(car1);
parking.AddCar(car2);
parking.AddCar(car3);
parking.AddCar();

Console.WriteLine();
parking.DisplayCars();

car2.ChangeColor(newColor);

Console.WriteLine();
Console.WriteLine(parking.GetStateMessage(true));

Console.WriteLine();
parking.RemoveCar(1);
Console.WriteLine();
parking.RemoveCar("Toyota", "Camry");

Console.WriteLine();
parking.DisplayCars(false);
Console.WriteLine();