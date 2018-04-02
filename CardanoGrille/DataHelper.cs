using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoGrille
{
    static class DataHelper
    {
        private const string _message = "*******************************************";
        private const string _messageError = "Некоректне введення!!!";
        private const string _messageEnterText = "Введiть текст!!!";
        private const string _messageHowLine = "Скiльки рядкiв тексту ви хочете ввести?";

        public static StringBuilder ReadFile(string fileName){
            return new StringBuilder(System.IO.File.ReadAllText(fileName));
        }

        public static void WriteFile(string fileName, StringBuilder text){
            System.IO.File.WriteAllText(fileName, text.ToString());
        }

        public static StringBuilder ReadConsole(){
            Console.WriteLine(_message);
            Console.WriteLine(_messageHowLine);
            int countLine = 0;
            try
            {
                countLine = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine();
                return new StringBuilder(_messageError);
            }

            Console.WriteLine(_message);
            Console.WriteLine(_messageEnterText);
            StringBuilder result = new StringBuilder("");
            try
            {
                for (int i = 0; i < countLine; i++)
                {
                    result.Append(Console.ReadLine());
                }
            }
            catch
            {
                Console.WriteLine(_messageError);
                return new StringBuilder("");
            }

            return result;
        }

        public static void WriteConsole(StringBuilder text){
            Console.WriteLine(_message);
            Console.WriteLine(text.ToString());
        }
    }
}