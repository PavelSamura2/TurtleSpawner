using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using StringConverter;

namespace StringConverter
{
    internal interface IConverter
    {
        List<char> StringImp();
        bool FindElementCondition(IEnumerable<char> primitiveArray, char primitiveSymbol);
    }

    internal class StringConverterClass : IConverter
    {
        private readonly string _inputString;
        public StringConverterClass(string inputString)
        {
            this._inputString = inputString;
        }
        public List<char> StringImp()
        {
            var stringToCharArray = _inputString.ToUpper().ToList();
            return stringToCharArray;
        }

        public bool FindElementCondition(IEnumerable<char> primitiveArray, char primitiveSymbol)
        {
            int counterPrimitiveCondition = primitiveArray.Count(value => value == primitiveSymbol);

            if (counterPrimitiveCondition > 1)
                return true;
            else
                return false;
        }

        public string StringFormatted()
        {
            string outFormattedString = "";
            var stringMem = StringImp();
            
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
            
            var converter = new StringConverterClass(inputString);
            Console.WriteLine("Formatted string: " + converter.StringFormatted());
        }
    }
}
