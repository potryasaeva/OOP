using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingProject
{
    public class Building
    {
        static int number = 123456;

        public int UniqueNumber
        {
            get
            {
                number = number + 1;
                return number;
            }
        }

        public int Height { get; set; }

        public short FloorsQuantity { get; set; }

        public int ApartmantsQuantity { get; set; }

        public int EntranceQuantity { get; set; }

    }
}
