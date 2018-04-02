using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoGrille
{
    enum TypeCoding
    {
        ENCODING,
        DECODING
    }

    class CardanoGrille
    {
        public StringBuilder EncodingUA(StringBuilder inputText, GrilleKey key){
            StringBuilder res = new StringBuilder();

            List<StringBuilder> blockStringBuilders = TextPreparationEncoding(inputText);
            foreach (StringBuilder blockStringBuilder in blockStringBuilders)
            {
                res.Append(FullString(blockStringBuilder, InitialTemplateMatrix(key)));
            }

            return res;
        }

        public StringBuilder DecodingUA(StringBuilder inputText, GrilleKey key){
            StringBuilder res = new StringBuilder();

            List<StringBuilder> blockStringBuilders = TextPreparationDecoding(inputText);
            foreach (StringBuilder blockStringBuilder in blockStringBuilders)
            {
                res.Append(FullStringReverse(blockStringBuilder, InitialTemplateMatrix(key)));
            }

            return res;
        }

        public StringBuilder DecodingWithoutKey(StringBuilder inputText){
            StringBuilder res = new StringBuilder();

            return res;
        }

        private List<StringBuilder> TextPreparationEncoding(StringBuilder inputText){
            List<StringBuilder> res = new List<StringBuilder>();

            inputText = TextAnalyser.RemoveSpace(inputText);
            inputText = TextAnalyser.RemovePunctuation(inputText);

            int size = GrilleKeys.Keys[0].Key.Count* GrilleKeys.Keys[0].Key.Count;

            res = TextAnalyser.SplitToSize(inputText, size);

            return res;
        }
        private List<StringBuilder> TextPreparationDecoding(StringBuilder inputText)
        {
            List<StringBuilder> res = new List<StringBuilder>();

            int size = GrilleKeys.Keys[0].Key.Count * GrilleKeys.Keys[0].Key.Count;

            res = TextAnalyser.SplitToSize(inputText, size);

            return res;
        }

        private List<int> InitialTemplateMatrix(GrilleKey key){
            List<List<int>> res = MatrixHelpCardoneAlgoritm.ZeroMatrix;

            List<List<int>> rotateMatrix = key.Key;
            for (int i = 0; i < res.Count; i++)
            {
                List<List<int>> temp =
                    MatrixService.VectorInMatrix(rotateMatrix, MatrixHelpCardoneAlgoritm.InputTextMatrix[i]);

                res = MatrixService.Addition(temp, res);
                if (i % 2 == 0)
                {
                    rotateMatrix = MatrixService.Multiply(rotateMatrix, MatrixHelpCardoneAlgoritm.InvertingMatrix);
                }
                else
                {
                    rotateMatrix = MatrixService.Multiply(MatrixHelpCardoneAlgoritm.InvertingMatrix,rotateMatrix);
                }
            }

            return MatrixService.ToVector(res);
        }
        private StringBuilder FullString(StringBuilder inputText, List<int> vectorNumber)
        {
            StringBuilder res = new StringBuilder("                ");
           
            for (int i = 0; i < inputText.Length; i++)
            {
                int index = vectorNumber.IndexOf(i + 1);
                res[index] = inputText[i];
            }

            return res;
        }

        private StringBuilder FullStringReverse(StringBuilder inputText, List<int> vectorNumber)
        {
            StringBuilder res = new StringBuilder("                ");

            for (int i = 0; i < inputText.Length; i++)
            {
                int index = vectorNumber.IndexOf(i + 1);
                res[i] = inputText[index];
            }

            return res;
        }
    }
}