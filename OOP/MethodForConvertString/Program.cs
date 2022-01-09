using System;

namespace MethodForConvertString
{
    class Program
    {
        static void Main()
        {   
            var testCase1 = new TestCaseClass("asdfghjkl", "lkjhgfdsa");
            var testCase2 = new TestCaseClass("as dfgh jkl", "lkj hgfd sa");
            var testCase3 = new TestCaseClass(" ty ., io ", " oi ,. yt ");
            var testCase4 = new TestCaseClass("", "");
            var testCase5 = new TestCaseClass(string.Empty, string.Empty);

            testCase1.TestReverseString();
            testCase2.TestReverseString();
            testCase3.TestReverseString();
            testCase4.TestReverseString();
            testCase5.TestReverseString();



            /*Console.WriteLine("Please enter string which you want to convert");
            var stringForReverse = Console.ReadLine();
            TestCaseClass a = new TestCaseClass(stringForReverse, stringForReverse);
            Console.WriteLine(a.Reverse(stringForReverse));*/

            

        }
    }
}
