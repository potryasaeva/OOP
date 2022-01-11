using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingProject
{
    public class Creator : Building
    {
        static Hashtable Buildings = new Hashtable();
        static ICollection key = Buildings.Keys;

        private Creator()
        {
        }

        public static void CreateBuilding(int height, short floorsQuantity, int apartmantsQuantity, int entranceQuantity)
        {
            Building building = new Building();
            
            building.Height = height;
            building.FloorsQuantity = floorsQuantity;
            building.ApartmantsQuantity = apartmantsQuantity;
            building.EntranceQuantity = entranceQuantity;

            Buildings.Add(building.UniqueNumber, building);

        }

        public static void DeleteBuilding(int number)
        {
            Buildings.Remove(number);
        }

        public static void BuildingsInfo()
        {
            foreach (var i in key)
            {
                var j = (Building)Buildings[i];

                Console.WriteLine($"Уникальный номер здания: {i}; высота здания: {j.Height}; количество этажей: {j.FloorsQuantity}; количество квартир: {j.ApartmantsQuantity}; количество подъездов: {j.EntranceQuantity};");
            }
        }

        public int CalculateFloorHigh()
        {
            return Height / FloorsQuantity;
        }

        public int CalculateQuantityOfApartmentsInEntrance()
        {
            return ApartmantsQuantity / EntranceQuantity;

        }

        public int CalculateQuantityOfApartmentsOnFloor()
        {
            return CalculateQuantityOfApartmentsInEntrance() / FloorsQuantity;

        }
    }
}
