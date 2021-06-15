using System;
using System.Collections.Generic;

namespace StringConverter
{
    internal interface IConverter
    {
        bool FindElementCondition(String InputString, char primitiveSymbol);
        string PerformConvertationJob(String inputString);
    }

    internal class StringConverterClass : IConverter
    {
        public bool FindElementCondition(String InputString, char primitiveSymbol)
        {
            int counterPrimitiveCondition = 0;
            foreach (var value in InputString)
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

            foreach (var currentPrimitive in inputString)
            {
                if (FindElementCondition(inputString, currentPrimitive))
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
