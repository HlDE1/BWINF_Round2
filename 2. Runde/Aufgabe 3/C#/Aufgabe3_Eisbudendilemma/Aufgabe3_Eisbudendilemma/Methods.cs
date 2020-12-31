using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

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
        public static void Kombinations(int Umfang)
        {
            int num = 0;
            string Begin = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            for (int a = 0; a < 7; a++)
            {
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
            }

            Console.WriteLine($"{num}");
            string End = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            Console.WriteLine($"{Begin} - {End}");
        }


        public static void Check_NearestDistanceFront(List<int> Entered_Addresses, int Umfang) // Soll abchecken ob die näheste Bude, der erste Wert ist
        {
            int sum = 0;
            int[] min_tmp = new int[4];
            int sum_LastNum = 0;
            string Begin = string.Format("{0:HH:mm:ss tt}", DateTime.Now);

            List<string> sum_all = new List<string>();
            for (int i = 0; i < Umfang; i++)
            {
                for (int j = i; j < Umfang; j++)
                {
                    for (int k = j; k < Umfang; k++)
                    {
                        if (i != k && i != j && k != j)
                        {
                            for (int a = 0; a < Entered_Addresses.Count; a++)
                            {

                                sum_LastNum = (Umfang - Entered_Addresses[a]) + i + 1;
                                min_tmp[0] = Math.Abs(Entered_Addresses[a] - i);
                                min_tmp[1] = Math.Abs(Entered_Addresses[a] - k);
                                min_tmp[2] = Math.Abs(Entered_Addresses[a] - j);
                                min_tmp[3] = sum_LastNum;

                                //Console.WriteLine($"{Entered_Addresses[a]} - {i}= {Math.Abs(Entered_Addresses[a] - i)}| {Entered_Addresses[a]} - {j}= {Math.Abs(Entered_Addresses[a] - j)}| {Entered_Addresses[a]} - {k}= {Math.Abs(Entered_Addresses[a] - k)} | {sum_LastNum} {Array1D_GetMinNum(min_tmp)}| {i} {j} {k}");
                                sum += Array1D_GetMinNum(min_tmp);
                            }
                            // Console.WriteLine("Sum:" + sum);
                            // Console.WriteLine("------------------------------------------------------------- ");
                            sum_all.Add($"{sum}| {i} {j} {k}");
                            sum = 0;
                        }
                    }
                }
            }
            foreach (var items in sum_all)
            {
                // Console.WriteLine(items);
                File.AppendAllText(Directory.GetCurrentDirectory() + "/Text.txt", items+Environment.NewLine);
            }

            Console.WriteLine("Min: " + sum_all.Min());
            string End = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            Console.WriteLine($"{Begin} - {End}");
        }
    }
}