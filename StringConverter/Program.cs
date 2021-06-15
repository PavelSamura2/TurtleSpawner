using System;
using System.Collections.Generic;
using System.Linq;


namespace StringConverter
{
    internal interface IConverter
    {
        bool FindElementCondition(IEnumerable<char> primitiveArray, char primitiveSymbol);
    }

    internal class StringConverterClass : IConverter
    {
        public bool FindElementCondition(IEnumerable<char> primitiveArray, char primitiveSymbol)
        {
            int counterPrimitiveCondition = 0;
            foreach (var value in primitiveArray)
            {
                if (value == primitiveSymbol) 
                    counterPrimitiveCondition++;
            }

            if (counterPrimitiveCondition > 1)
                return true;
            else
                return false;
        }

        public string PerformConvertationJob(String inputString)
        {
            string outFormattedString = "";
            var stringMem = inputString.ToUpper().ToList();
            
            foreach (var currentPrimitive in stringMem)
            {
                if (FindElementCondition(stringMem, currentPrimitive))
                    outFormattedString += ")";
                else
                    outFormattedString += "(";
            }
            return outFormattedString;
            
        }
    }


class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter input string: ");
            var inputString = Console.ReadLine();
            
            var converter = new StringConverterClass();
            Console.WriteLine("Formatted string: " + converter.PerformConvertationJob(inputString));
        }
    }
}
