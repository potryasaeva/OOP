using System;

namespace Building
{
    class Program
    {
        static void Main()
        {

            BuildingClass building = new BuildingClass(963, 3, 60, 5);
            Console.WriteLine(building.UniqueNumber);
            Console.WriteLine($"Floors height is {building.CalculateFloorHigh()}");
            Console.WriteLine($"Quantity of apartments in entrance is {building.CalculateQuantityOfApartmentsInEntrance()}");
            Console.WriteLine($"Quantity of apartments on the floor is {building.CalculateQuantityOfApartmentsOnFloor()}");

            //проверка уникальности номера
            BuildingClass building1 = new BuildingClass(963, 3, 60, 5);
            Console.WriteLine(building1.UniqueNumber);

            BuildingClass building2 = new BuildingClass(963, 3, 60, 5);
            Console.WriteLine(building2.UniqueNumber);

            BuildingClass building3 = new BuildingClass(963, 3, 60, 5);
            Console.WriteLine(building3.UniqueNumber);

        }
    }
}
