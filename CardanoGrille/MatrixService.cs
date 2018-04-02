using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoGrille
{
    static class MatrixService
    {
        public static List<List<int>> Multiply(List<List<int>> matrixFirst, List<List<int>> matrixSecond){
            List<List<int>> res = new List<List<int>>()
            {
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0}
            };

            for (int i = 0; i < matrixFirst.Count; i++)
            {
                for (int j = 0; j < matrixFirst.Count; j++)
                {
                    res[i][j] = 0;
                    for (int k = 0; k < matrixFirst.Count; k++)
                        res[i][j] = res[i][j] + matrixFirst[i][k] * matrixSecond[k][j];
                }
            }

            return res;
        }

        public static List<List<int>> Addition(List<List<int>> matrixFirst, List<List<int>> matrixSecond){
            List<List<int>> res = new List<List<int>>()
            {
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0}
            };

            for (int i = 0; i < matrixFirst.Count; i++)
            {
                for (int j = 0; j < matrixFirst.Count; j++)
                {
                    res[i][j] = matrixFirst[i][j] + matrixSecond[i][j];
                }
            }

            return res;
        }

        public static List<List<int>> VectorInMatrix(List<List<int>> matrixFirst, List<int> vector){
            List<List<int>> res = new List<List<int>>()
            {
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0}
            };

            for (int i = 0; i < matrixFirst.Count; i++)
            {
                for (int j = 0; j < matrixFirst.Count; j++)
                {
                    if (matrixFirst[i][j] != 0)
                    {
                        matrixFirst[i][j] = vector[i];
                    }
                }
            }

            return res;
        }

        public static List<int> ToVector(List<List<int>> matrixFirst){
            List<int> res = new List<int>();

            for (int i = 0; i < matrixFirst.Count; i++)
            {
                for (int j = 0; j < matrixFirst.Count; j++)
                {
                    res.Add(matrixFirst[i][j]);
                }
            }

            return res;
        }
    }
}