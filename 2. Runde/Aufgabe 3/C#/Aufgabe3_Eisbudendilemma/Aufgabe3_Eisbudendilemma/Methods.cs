﻿using System;
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

        public static int Check_NearestDistanceFront(List<int> Entered_Addresses, int i, int j, int k, int Umfang) // Soll abchecken ob die näheste Bude, der erste Wert ist
        {
            int val_j = j;
            int j_endloop = val_j + 3;

            int start = i;
            int sum = 0;
            int[] min_tmp = new int[20];
            int sum_LastNum = 0;
            int sum_i = 0;
            int sum_j = 0;
            int sum_k = 0;
            for (int a = 0; a < Entered_Addresses.Count; a++)
            {
                for (i = 0; i < Umfang; i++)
                {
                    for (j = i; j < Umfang; j++)
                    {
                        for (k = j; k < Umfang; k++)
                        {
                            if ((i != k && i != j && k != j)) //&& sum_i >= 0)// && sum_j >= 0 && sum_k >= 0) //&& Entered_Addresses[a] >= i)
                            {
                                sum_i = Entered_Addresses[a] - i;
                                sum_j = Entered_Addresses[a] - j;
                                sum_k = Entered_Addresses[a] - k;
                                //sum = Entered_Addresses[a] - k;
                                //min_tmp[i] = sum;
                                Console.WriteLine($"{sum_i}");
                                //Console.WriteLine($"{Entered_Addresses[a]} - {i}= {Entered_Addresses[a] - i}| {Entered_Addresses[a]} - {j}= {Entered_Addresses[a] - j}| {Entered_Addresses[a]} - {k}= {Entered_Addresses[a] - k}| {i} {j} {k}");
                                //Console.WriteLine($"{Entered_Addresses[i]} - {j}= {Entered_Addresses[i] - j} ");
                                //Console.WriteLine($"{i} {j} {k}");
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}