using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderProject
{
    public class ACoder : IСoder
    {
        private readonly char[] _charArray;

        public ACoder(string inputString)
        {
            _charArray = inputString.ToCharArray();
        }

        public string Decode()
        {
            for (int i = 0; i < _charArray.Length; i++)
            {
                _charArray[i] = (char)(_charArray[i] - 1);
            }

            return string.Concat(_charArray);
        }

        public string Encode()
        {
            for (int i = 0; i < _charArray.Length; i++)
            {
                _charArray[i] = (char)(_charArray[i] + 1);
            }

            return string.Concat(_charArray);
        }
    }
}
