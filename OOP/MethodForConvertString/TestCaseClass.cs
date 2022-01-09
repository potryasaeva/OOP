using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodForConvertString
{
    public class TestCaseClass
    {

        private readonly string _value;
        private readonly string _expectedValue;
        private readonly Exception _expectedException;

        public string Value 
        {
            get { return _value; }
                
         }

        public string ExpectedValue
        {
            get { return _expectedValue; }

        }

        public Exception ExpectedException
        {
            get { return _expectedException; }

        }
        
        public TestCaseClass(string value, string expectedValue) : this(value, expectedValue, null)
        {
            
        }

        public TestCaseClass(string value, string expectedValue, Exception expectedException)
        {
            _value = value;
            _expectedValue = expectedValue;
            _expectedException = expectedException;
        }

        public void TestReverseString()
        {
            try
            {
                var actual = Reverse(Value);

                if (actual == ExpectedValue)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (ArgumentException ex)
            {
                if (ExpectedException != null & ex.GetType() == ExpectedException.GetType())
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("INVALID TEST");
            }
        }

        public string Reverse(string stringForReverse)
        {
            char[] charArray = stringForReverse.ToCharArray();
            string reverse = String.Empty;
            for (int i = charArray.Length - 1; i > -1; i--)
            {
                reverse += charArray[i];
            }
            return reverse;
        }
    }
}
