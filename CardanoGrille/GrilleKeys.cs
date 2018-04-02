using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoGrille
{
    static class GrilleKeys
    {
        private static readonly GrilleKey Key1 = new GrilleKey()
        {
            Key = new List<List<int>>()
            {
                new List<int>() {0, 1, 0, 0},
                new List<int>() {1, 0, 0, 0},
                new List<int>() {0, 0, 1, 0},
                new List<int>() {0, 0, 0, 1}
            }
        };
        private static readonly GrilleKey Key2 = new GrilleKey()
        {
            Key = new List<List<int>>()
            {
                new List<int>() {0, 0, 1, 0},
                new List<int>() {0, 0, 0, 1},
                new List<int>() {0, 1, 0, 0},
                new List<int>() {1, 0, 0, 0}
            }
        };
        private static readonly GrilleKey Key3 = new GrilleKey()
        {
            Key = new List<List<int>>()
            {
                new List<int>() {1, 0, 0, 0},
                new List<int>() {0, 1, 0, 0},
                new List<int>() {0, 0, 0, 1},
                new List<int>() {0, 0, 1, 0},
            }
        };
        private static readonly GrilleKey Key4 = new GrilleKey()
        {
            Key = new List<List<int>>()
            {
                new List<int>() {0, 0, 0, 1},
                new List<int>() {0, 0, 1, 0},
                new List<int>() {1, 0, 0, 0},
                new List<int>() {0, 1, 0, 0},
            } 
        };

        public static List<GrilleKey> Keys = new List<GrilleKey>(){Key1, Key2, Key3, Key4};
    }
}