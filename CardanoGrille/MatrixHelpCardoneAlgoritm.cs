using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoGrille
{
    static class MatrixHelpCardoneAlgoritm
    {
        public static readonly List<List<int>> InvertingMatrix = new List<List<int>>()
        {
            new List<int>() {0, 0, 0, 1},
            new List<int>() {0, 0, 1, 0},
            new List<int>() {0, 1, 0, 0},
            new List<int>() {1, 0, 0, 0}
        };

        public static readonly List<List<int>> InputTextMatrix = new List<List<int>>()
        {
            new List<int>() {1, 2, 3, 4},
            new List<int>() {5, 6, 7, 8},
            new List<int>() {9, 10, 11, 12},
            new List<int>() {13, 14, 15, 16}
        };

        public static readonly List<List<int>> ZeroMatrix = new List<List<int>>()
        {
            new List<int>() {0, 0, 0, 0},
            new List<int>() {0, 0, 0, 0},
            new List<int>() {0, 0, 0, 0},
            new List<int>() {0, 0, 0, 0}
        };
    }
}