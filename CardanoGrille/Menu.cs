using System;
using System.Text;

namespace CardanoGrille
{
    class Menu
    {
        private readonly string[] ITEMS_MENU_CODING =
        {
            "1.Закодувати текст",
            "2.Розкодувати текст",
            "3.Декодувати текст",
            "0.Вихiд"
        };
        private readonly string[] KEYS =
        {
            "1. " +
            "\n\r 0 1 0 0 ," +
            "\r\n 1 0 0 0 ," +
            "\n\r 0 0 1 0 ," +
            "\n\r 0 0 0 1",
            "2. " +
            "\n\r 0 0 1 0 ," +
            "\n\r 0 0 0 1 ," +
            "\n\r 0 1 0 0 ," +
            "\n\r 1 0 0 0",
            "3. " +
            "\n\r 1 0 0 0 ," +
            "\n\r 0 1 0 0 ," +
            "\n\r 0 0 0 1 ," +
            "\n\r 0 0 1 0",
            "4. " +
            "\n\r 0 0 0 1 ," +
            "\n\r 0 0 1 0 ," +
            "\n\r 1 0 0 0 ," +
            "\n\r 0 1 0 0",
            "0.Вихiд"
        };

        private readonly string[] ITEMS_MENU_READING_TEXT =
        {
            "1.Зчитати текст з файлу",
            "2.Зчитати текст з консолi",
            "0.Вихiд в головне меню"
        };

        private readonly string[] ITEMS_MENU_WRITE_TEXT =
        {
            "1.Записати отриманий текст у файлу",
            "2.Вивiд отриманий тексту на консолi",
            "0.Вихiд в головне меню"
        };

        private const int ENCODE_TEXT_REQUEST = 1;
        private const int DECODE_TEXT_REQUEST = 2;
        private const int DECODEWITHOUTKEY_TEXT_REQUEST = 3;
        private const int EXIT_OR_BACK_REQUEST = 0;

        private const int READ_FILE_REQUEST = 1;
        private const int READ_CONSOLE_REQUEST = 2;

        private const int WRITE_FILE_REQUEST = 1;
        private const int WRITE_CONSOLE_REQUEST = 2;

        private const string _messageWelcom = "Виберiть дiю";
        private const string _messageError = "Неправильно введенi данi. Попробуйте ще раз";
        private const string _messageFilePath = "Введiть шлях до файлу";
        private const string _messageFileError = "Шлях до файлу некоректний або файлу не iснує";
        private const string _messageSuccesfullFile = "Дiю виконано";
        private const string _messageKey = "Введiть ключ шифрування";
        private const string _messageReadFile = " зчитування з файлу";
        private const string _messageWriteFile = " зчитування з файлу";
        private const string _message = "*******************************************";

        public void Show(){
            WelcomMenu();
        }

        private void WelcomMenu(){
            while (true)
            {
                Console.WriteLine(_message);
                Console.WriteLine(_messageWelcom);
                foreach (string item in ITEMS_MENU_CODING)
                {
                    Console.WriteLine(item);
                }

                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (IsCorrect(number, ITEMS_MENU_CODING.Length))
                    {
                        bool isExit = false;
                        switch (number)
                        {
                            case ENCODE_TEXT_REQUEST:
                                EncodingItem();
                                break;
                            case DECODE_TEXT_REQUEST:
                                DecodingItem();
                                break;
                            case DECODEWITHOUTKEY_TEXT_REQUEST:
                                DecodingWithoutKeyItem();
                                break;
                            case EXIT_OR_BACK_REQUEST:
                                isExit = true;
                                break;
                        }

                        if (isExit)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(_messageError);
                }
            }
        }

        private void EncodingItem(){
            CodingItem(TypeCoding.ENCODING);
        }

        private void DecodingItem(){
            CodingItem(TypeCoding.DECODING);
        }

        private void CodingItem(TypeCoding typeCoding){
            StringBuilder resultMenuFile = ReadDataMenu();
            if (resultMenuFile != null)
            {
                CardanoGrille cardanoGrille = new CardanoGrille();
                int? num = GetKeyMenu();
                if (num != null)
                {
                    StringBuilder result = null;
                    if (typeCoding == TypeCoding.ENCODING)
                    {
                        result = cardanoGrille.EncodingUA(resultMenuFile, GrilleKeys.Keys[((int)num-1)]);
                    }
                    else
                    {
                        result = cardanoGrille.DecodingUA(resultMenuFile, GrilleKeys.Keys[((int)num - 1)]);
                    }

                    if (result != null)
                    {
                        WriteDataMenu(result);
                    }
                    else
                    {
                        Console.WriteLine(_messageError);
                    }
                }
                else
                {
                    Console.WriteLine(_messageError);
                }
            }
        }

        private void DecodingWithoutKeyItem(){
            StringBuilder resultMenuFile = ReadDataMenu();
            if (resultMenuFile != null)
            {
                CardanoGrille cardanoGrille = new CardanoGrille();
                StringBuilder result = cardanoGrille.DecodingWithoutKey(resultMenuFile);
                if (result != null)
                {
                    WriteDataMenu(result);
                }
                else
                {
                    Console.WriteLine(_messageError);
                }
            }
        }

        private int? GetKeyMenu(){
            Console.WriteLine(_message);

            Console.WriteLine(_messageKey);
            foreach (string key in KEYS)
            {
                Console.WriteLine(key);
            }
            try
            {
                int number = Int32.Parse(Console.ReadLine());
                if (IsCorrect(number, 4))
                {
                    return number;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine(_messageError);
                return null;
            }
        }

        private StringBuilder ReadDataMenu(){
            while (true)
            {
                Console.WriteLine(_message);
                Console.WriteLine(_messageWelcom);
                foreach (string item in ITEMS_MENU_READING_TEXT)
                {
                    Console.WriteLine(item);
                }

                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (IsCorrect(number, ITEMS_MENU_READING_TEXT.Length))
                    {
                        bool isExit = false;
                        switch (number)
                        {
                            case READ_FILE_REQUEST:
                                return ReadFileItem();
                            case READ_CONSOLE_REQUEST:
                                return DataHelper.ReadConsole();
                            case EXIT_OR_BACK_REQUEST:
                                isExit = true;
                                break;
                        }

                        if (isExit)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(_messageError);
                }
            }

            return null;
        }

        private StringBuilder ReadFileItem(){
            Console.WriteLine(_message);

            Console.WriteLine(_messageFilePath);
            try
            {
                string filePath = Console.ReadLine();
                StringBuilder resultText = DataHelper.ReadFile(filePath);

                Console.WriteLine(_messageSuccesfullFile + _messageReadFile);
                return resultText;
            }
            catch
            {
                Console.WriteLine(_messageFileError);
                return null;
            }
        }

        private void WriteFileItem(StringBuilder inputString){
            Console.WriteLine(_message);

            Console.WriteLine(_messageFilePath);
            try
            {
                string filePath = Console.ReadLine();
                DataHelper.WriteFile(filePath, inputString);
                Console.WriteLine(_messageSuccesfullFile + _messageWriteFile);
            }
            catch
            {
                Console.WriteLine(_messageFileError);
            }
        }

        private void WriteDataMenu(StringBuilder inputText){
            while (true)
            {
                Console.WriteLine(_message);
                Console.WriteLine(_messageWelcom);
                foreach (string item in ITEMS_MENU_WRITE_TEXT)
                {
                    Console.WriteLine(item);
                }

                try
                {
                    int number = Int32.Parse(Console.ReadLine());
                    if (IsCorrect(number, ITEMS_MENU_WRITE_TEXT.Length))
                    {
                        bool isExit = false;
                        switch (number)
                        {
                            case WRITE_FILE_REQUEST:
                                WriteFileItem(inputText);
                                isExit = true;
                                break;
                            case WRITE_CONSOLE_REQUEST:
                                DataHelper.WriteConsole(inputText);
                                break;
                            case EXIT_OR_BACK_REQUEST:
                                isExit = true;
                                break;
                        }

                        if (isExit)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(_messageError);
                }
            }
        }

        private bool IsCorrect(int number, int maxValue){
            if (number >= 0 && number <= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}