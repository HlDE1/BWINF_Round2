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
        public static int Array2D_GetMaxNum(int[,] arr, int col)
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
        public static int Array2D_GetMaxNum_index(int[,] arr, int col)
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

        public static int Array1D_GetMinNum(int[] arr)
        {
            int Min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < Min)
                {
                    Min = arr[i];
                }
            }
            return Min;
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

        public static int Check_NearestDistanceFront(List<int> Entered_Addresses, int i, int j) // Soll abchecken ob die näheste Bude, der erste Wert ist
        {
            int val_j = j;
            int j_endloop = val_j + 3;

            int start = i;
            int sum = 0;
            int[] min_tmp = new int[3];
            int sum_LastNum = 0;
            //List<int> min_tmp = new List<int>();
            //TODO: Rückwärts suchen | Eisbude posi zur nächstgelegenden zusammen rechnen 

            for (i = 0; i < Entered_Addresses.Count; i++)
            {
                for (j = val_j; j < j_endloop; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (Entered_Addresses[i] >= j)
                        {

                            sum = Entered_Addresses[i] - j;
                            min_tmp[k] = sum;
                            Console.WriteLine($"{Entered_Addresses[i]} + {j}= {Entered_Addresses[i] - j} ");


                            //Console.WriteLine($"{Entered_Addresses[i]} = {start}");
                            sum_LastNum = Entered_Addresses[i] - Entered_Addresses[i - 1];
                            min_tmp[k] = Entered_Addresses[i] - (Entered_Addresses[i] - j);
                            if (sum_LastNum < Methods.Array1D_GetMinNum(min_tmp))
                                Console.WriteLine($"{Entered_Addresses[i]}. {Entered_Addresses[i - 1]}");
                            else
                                Console.WriteLine($"{Entered_Addresses[i]}. {start}");
                        }
                    }
                }
            }
            return 0;
        }
    }
}