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

            List<StringBuilder> blockStringBuilders = TextPreparation(inputText);
            foreach (StringBuilder blockStringBuilder in blockStringBuilders)
            {
                res.Append(FullString(inputText, InitialTemplateMatrix(key)));
            }

            return res;
        }

        public StringBuilder DecodingUA(StringBuilder inputText, GrilleKey key){
            StringBuilder res = new StringBuilder();

            return res;
        }

        public StringBuilder DecodingWithoutKey(StringBuilder inputText){
            StringBuilder res = new StringBuilder();

            return res;
        }

        private List<StringBuilder> TextPreparation(StringBuilder inputText){
            List<StringBuilder> res = new List<StringBuilder>();

            inputText = TextAnalyser.RemoveSpace(inputText);
            inputText = TextAnalyser.RemovePunctuation(inputText);

            for (int i = 0; i < inputText.Length; i++)
            {
                if (i == GrilleKeys.Keys[0].Key.Count)
                {
                    StringBuilder temp = inputText.Remove(0, i);
                    res.Add(temp);
                    i = 0;
                }
            }

            res.Add(inputText);

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

                rotateMatrix = MatrixService.Multiply(rotateMatrix, MatrixHelpCardoneAlgoritm.InvertingMatrix);
            }

            return MatrixService.ToVector(res);
        }
        private StringBuilder FullString(StringBuilder inputText, List<int> vectorNumber)
        {
            StringBuilder res = new StringBuilder(vectorNumber.Count);
           
            for (int i = 0; i < vectorNumber.Count; i++)
            {
                res[i] = inputText[vectorNumber[i]-1];
            }

            return res;
        }
    }
}