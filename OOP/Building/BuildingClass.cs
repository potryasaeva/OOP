using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    public class BuildingClass
    {
        static int number = 123456;
        private int _uniqueNumber;
        private int _height;
        private short _floorsQuantity;
        private int _apartmantsQuantity;
        private int _entranceQuantity;

        public int UniqueNumber
        {
            get
            {
                return _uniqueNumber;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public short FloorsQuantity
        {
            get
            {
                return _floorsQuantity;
            }
            set
            {
                _floorsQuantity = value;
            }
        }

        public int ApartmantsQuantity
        {
            get
            {
                return _apartmantsQuantity;
            }
            set
            {
                _apartmantsQuantity = value;
            }
        }

        public int EntranceQuantity
        {
            get
            {
                return _entranceQuantity;
            }
            set
            {
                _entranceQuantity = value;
            }
        }

        public BuildingClass(int height, short floorsQuantity, int apartmantsQuantity, int entranceQuantity)
        {
            _uniqueNumber = number + 1;
            number = _uniqueNumber;
            _height = height;
            _floorsQuantity = floorsQuantity;
            _apartmantsQuantity = apartmantsQuantity;
            _entranceQuantity = entranceQuantity;
        }

        public int CalculateFloorHigh()
        {
            return _height / _floorsQuantity;
        }

        public int CalculateQuantityOfApartmentsInEntrance()
        {
            return _apartmantsQuantity / _entranceQuantity;

        }

        public int CalculateQuantityOfApartmentsOnFloor()
        {
            return CalculateQuantityOfApartmentsInEntrance() / _floorsQuantity;

        }
    }
}
