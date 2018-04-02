using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardanoGrille
{
    static class TextAnalyser
    {
        private const string Space = " ";

        private struct LetterWithFrequensy
        {
            public char Letter { get; set; }
            public int Count { get; set; }

            public LetterWithFrequensy(char letter, int count){
                this.Letter = letter;
                this.Count = count;
            }
        };

        public static char GetOffenLetter(StringBuilder text){
            string textToString = text.ToString();

            List<char> textList = textToString.ToList();

            List<LetterWithFrequensy> letterFrequency = GetLetterFrequency(textList);
            letterFrequency.Sort((p, g) => p.Count.CompareTo(g.Count));

            return letterFrequency.Last().Letter;
        }

        private static int GetRepeatCount(char letter, List<char> text){
            int count = 0;
            for (int i = 0; i < text.Count; i++)
            {
                if (text[i].Equals(letter))
                {
                    count++;
                    text.RemoveAt(i);
                }
            }

            return count;
        }

        private static List<LetterWithFrequensy> GetLetterFrequency(List<char> text){
            List<char> currenttext = new List<char>(text);

            List<LetterWithFrequensy> resFreq = new List<LetterWithFrequensy>();
            for (int i = 0; i < currenttext.Count; i++)
            {
                resFreq.Add(new LetterWithFrequensy(currenttext[i], GetRepeatCount(currenttext[i], currenttext)));
            }

            return resFreq;
        }

        public static StringBuilder RemoveSpace(StringBuilder inputText){
            return inputText.Replace(Space, string.Empty);
        }

        public static StringBuilder RemovePunctuation(StringBuilder inputText){
            for (int i = 0; i < inputText.Length; i++)
            {
                if (Char.IsPunctuation(inputText[i]))
                {
                    inputText.Replace(inputText[i].ToString(), string.Empty);
                }
            }

            return inputText;
        }

        public static List<StringBuilder> SplitToSize(StringBuilder inputText, int size){
            List<StringBuilder> res =new List<StringBuilder>();
            int lastIndex = 0;
            for (int i = 1; i < inputText.Length; i++)
            {
                if (i % (size) == 0)
                {
                    StringBuilder temp = new StringBuilder(inputText.ToString(i - (size), size));
                    res.Add(temp);
                    lastIndex = i;
                }
            }

            res.Add(new StringBuilder(inputText.ToString(lastIndex, inputText.Length - lastIndex)));

            return res;
        }
    }
}