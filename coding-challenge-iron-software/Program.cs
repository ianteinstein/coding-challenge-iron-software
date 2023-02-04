using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLogic;

namespace coding_challenge_iron_software
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = true;
            do
            {
                Console.WriteLine("Please input phone pad");
                var input = Console.ReadLine();
                Console.WriteLine("===========================");
                try
                {
                    var resultInfo = OldPhonePad(input);
                    Console.WriteLine(resultInfo.IsValid ? "Result is valid" : "Result is invalid");
                    Console.WriteLine(resultInfo.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Internal Error: {ex.Message}");
                }
                
                Console.WriteLine();
                Console.WriteLine("Try again? Please input y/Y or n/N and Press Enter");
                var tryAgain = Console.ReadLine();
                start = tryAgain.Equals("y", StringComparison.InvariantCultureIgnoreCase);
                Console.WriteLine();
            } while (start);
            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine("Good bye !!!");

            Console.ReadKey();
        }

        public static ResultInfo OldPhonePad(string input)
        {
            var coreEngie = new StringEngine(new PhonePadDictionary());
            return coreEngie.GetResultString(input);
        }
    }
}
