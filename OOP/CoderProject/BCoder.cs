using System;
using System.Collections.Generic;

namespace CoderProject
{
    public class BCoder : IСoder
    {
        private readonly Dictionary<char, Tuple<int, int>> _letters = new Dictionary<char, Tuple<int, int>>();

        private readonly char[] _charArray;

        private const int _ruAlphabetLength = 32;
        private const int _enAlphabetLength = 26;

        public BCoder(string inputString)
        {
            _charArray = inputString.ToCharArray();

            for (int i = 0; i < _ruAlphabetLength; i++)
            {
                _letters.Add((char)(1072 + i), new Tuple<int, int>(1072, 1072 + _ruAlphabetLength - 1));
                _letters.Add((char)(1040 + i), new Tuple<int, int>(1040, 1040 + _ruAlphabetLength - 1));

                if (i < _enAlphabetLength)
                {
                    _letters.Add((char)(97 + i), new Tuple<int, int>(97, 97 + _enAlphabetLength - 1));
                    _letters.Add((char)(65 + i), new Tuple<int, int>(65, 65 + _enAlphabetLength - 1));
                }
            }
        }

        public string Encode()
        {
            for (int i = 0; i < _charArray.Length; i++)
            {
                if (_letters.ContainsKey(_charArray[i]))
                {
                    var letter = _letters[_charArray[i]];
                    _charArray[i] = (char)(letter.Item2 - (_charArray[i] - letter.Item1));
                }
                else
                {
                    _charArray[i] = _charArray[i];
                }
            }
            return string.Concat(_charArray);
        }
        public string Decode()
        {

            for (int i = 0; i < _charArray.Length; i++)
            {
                if (_letters.ContainsKey(_charArray[i]))
                {
                    var letter = _letters[_charArray[i]];
                    _charArray[i] = (char)(letter.Item2 - (_charArray[i] - letter.Item1));
                }
                else
                {
                    _charArray[i] = _charArray[i];
                }

            }
            return string.Concat(_charArray);
        }
    }
}
    
