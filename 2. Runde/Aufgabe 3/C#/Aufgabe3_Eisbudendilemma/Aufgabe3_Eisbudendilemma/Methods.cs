using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3_Eisbudendilemma
{
    class Methods
    {
        public static int GetMaxNum(int[,] arr, int col)
        {
            int max = arr[col, 0];
            for (int i = 0; i < arr.GetLength(col); i++)
            {
                if (arr[col, i] > max)
                {
                    max = arr[col, i];
                }
            }
            return max;
        }
        public static int GetMaxNum_index(int[,] arr, int col)
        {
            int max = arr[col, 0];
            int index = 0;
            for (int i = 0; i < arr.GetLength(col); i++)
            {
                if (arr[col, i] > max)
                {
                    index = i;
                    max = arr[col, i];
                }
            }
            return index;
        }
    }
}
