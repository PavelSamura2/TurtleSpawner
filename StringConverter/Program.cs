using System;

namespace StringConverter
{
    //Интерфейс, на случай если нужно будет реализовать несколько разных конвертеров
    internal interface IConverter
    { 
        void PerformConvertJob(ref string inputString);
    }

    //Конвертер, который заменяет символ на '(', если символ встречается 1 раз, на ')', если несколько
    internal class StringConverterClass : IConverter
    {
        //Метод, производящий конвертацию строки и пишет результат в outString. Асимптотически работает за O(L)
        //где L - длина строки. Достигается такая быстрота использованием таблицы вхождений по ASCII символам
        public void PerformConvertJob(ref string outString)
        {
            //Объявляем массив размером с алфавит (500 хватит на цифры, буквы, специальные символы с запасом. 
            //Этот массив будет использоваться как счетчик-таблица, где по номеру символа ASCII можно получить 
            //количество вхождений символа с таким ASCII кодом
            var symbolCountArray = new int[500];
            
            //Создаем строку для работы внутри функции. Такое использование добавляет безопасности
            var internalUserString = outString.ToLower();
            //Выходная строка
            var resultString = "";

            //Делаем инкремент к каждому ASCII символу в таблицу symbolContArray. Конвертация от char к int происходит
            //автоматически
            foreach (char c in internalUserString)
            {
                symbolCountArray[c]++;
            }

            //Проходимся по всей строке и делаем конкатенацию нужной скобочки в зависимости от количества вхождений
            //символа в таблицу
            foreach (char c in internalUserString)
            {
                if (symbolCountArray[c] > 1)
                    resultString += ')';
                else
                    resultString += '(';
            }

            //Записываем в выходной аргумент нашу строку
            outString = resultString;
        }
    }


    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Считываем количество строк, которые потребуем ввести у пользователя
            Console.WriteLine("Enter strings count: ");
            var inputStringsCount  = Convert.ToInt32(Console.ReadLine());
            
            //Создаем конвертер строк
            var converter = new StringConverterClass();

            for (int queryIndex = 0; queryIndex < inputStringsCount; ++queryIndex)
            {
                //Считываем пользовательскую строку
                Console.WriteLine("Press enter input string: ");
                var userString = Console.ReadLine();
            
                //Делаем конвертацию строки
                converter.PerformConvertJob(ref userString);
            
                //Выводим результат конвертации
                Console.WriteLine($"Formatted string: {userString}");
            }
        }
    }
}