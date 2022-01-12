using System;

namespace BuildingProject
{
    class Program
    {
        static void Main()
        {

            Creator.CreateBuilding(963,3,12,4);
            Creator.CreateBuilding(1025, 5, 10, 2);
            Creator.CreateBuilding(3560, 10, 25, 3);
            Creator.CreateBuilding(256, 2, 3, 6);
            Creator.BuildingsInfo();
            Console.WriteLine();

            Creator.DeleteBuilding(123460);
            Creator.BuildingsInfo();

        }
    }
}
