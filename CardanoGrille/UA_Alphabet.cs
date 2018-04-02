using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoGrille
{
    static class UA_Alphabet
    {
        private static readonly List<char> UA_AlphabetChars = new List<char>()
        {
            'а',
            'б',
            'в',
            'г',
            'ґ',
            'д',
            'е',
            'є',
            'ж',
            'з',
            'и',
            'і',
            'ї',
            'й',
            'к',
            'л',
            'м',
            'н',
            'о',
            'п',
            'р',
            'с',
            'т',
            'у',
            'ф',
            'х',
            'ц',
            'ч',
            'ш',
            'щ',
            'ь',
            'ю',
            'я',
            'А',
            'Б',
            'В',
            'Г',
            'Ґ',
            'Д',
            'Е',
            'Є',
            'Ж',
            'З',
            'И',
            'І',
            'Ї',
            'Й',
            'К',
            'Л',
            'М',
            'Н',
            'О',
            'П',
            'Р',
            'С',
            'Т',
            'У',
            'Ф',
            'Х',
            'Ц',
            'Ч',
            'Ш',
            'Щ',
            'Ь',
            'Ю',
            'Я'
        };

        private static readonly List<char> UA_LoudLetter = new List<char>()
            {'о', 'а', 'и', 'і', 'у'};

        public static int LoudLetterLenght = UA_LoudLetter.Count;

        public static int AlphabetLength = UA_AlphabetChars.Count;

        public static int GetNumber(char inputChar){
            return UA_AlphabetChars.IndexOf(inputChar);
        }

        public static Char GetChar(int inputInt){
            return UA_AlphabetChars[inputInt];
        }

        public static char GetLoudLetter(int inputNumber){
            return UA_LoudLetter[inputNumber];
        }

        public static int GetNumBetweenLetter(char letterFirst, char letterSecond){
            int numFirstLetter = GetNumber(letterFirst);
            int numSecondLetter = GetNumber(letterSecond);
            return Math.Abs(numFirstLetter - numSecondLetter);
        }
    }
}