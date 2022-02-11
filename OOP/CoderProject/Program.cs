using System;

namespace CoderProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter string line for encode/decode");
            var inputString = Console.ReadLine();

            var ACoder = new ACoder(inputString);

            Console.WriteLine($"ACoder.Encode = {ACoder.Encode()}");
            Console.WriteLine($"ACoder.Decode = {ACoder.Decode()}");


            var BCoder = new BCoder(inputString);

            Console.WriteLine($"BCoder.Encode = {BCoder.Encode()}");
            Console.WriteLine($"BCoder.Decode = {BCoder.Decode()}");

            Console.ReadKey();
        }
    }
}
