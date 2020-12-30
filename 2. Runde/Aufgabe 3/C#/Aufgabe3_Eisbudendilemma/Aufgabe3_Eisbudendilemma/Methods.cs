using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public static int GetClosestNumber(List<int> List, int number)
        {
            return List.Aggregate((x, y) => Math.Abs(x - number) < Math.Abs(y - number) ? x : y);
        }

        public static void Kombinations(int Umfang)
        {
            int num = 0;
            string Begin = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            for (int i = 0; i < Umfang; i++)
            {
                for (int j = i; j < Umfang; j++)
                {
                    for (int k = j; k < Umfang; k++)
                    {
                        if (i != k && i != j && k != j)
                        {
                            num++;
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }

            Console.WriteLine($"{num}");
            string End = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            Console.WriteLine($"{Begin} - {End}");
        }
    }
}
