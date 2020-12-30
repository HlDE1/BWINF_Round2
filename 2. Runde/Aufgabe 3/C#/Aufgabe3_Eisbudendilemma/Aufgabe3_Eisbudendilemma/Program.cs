using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Aufgabe3_Eisbudendilemma
{
    class Program
    {
        /*
        Wenn es seinen Weg zur nächstgelegenen Bude verkürzt = für die verlegung | ansonsten dagegen 
        3 Standort für die Eisbuden finden    
        */


        static List<string> input_txt = File.ReadAllLines(@"C:\Users\HlDE1\source\repos\BWINF_Round2\2. Runde\Aufgabe 3\eisbuden1.txt").ToList();
        static string Umfang = input_txt[0].Split(' ')[0].ToString();
        static string Amount_Haus = input_txt[0].Split(' ')[1].ToString();
        static List<int> Entered_Addresses = new List<int>();

        static int[] Place_Check = new int[Convert.ToInt32(Umfang) + 1]; // [0= not a house| 1=house]

        static int firstBude = Convert.ToInt32(Convert.ToInt32(Umfang) / 2);
        static int SecondBude = Convert.ToInt32(firstBude / 2);
        static int thirdBude = (Convert.ToInt32(Umfang) / 2) + SecondBude;

        static void Main(string[] args)
        {
            foreach (var Address in input_txt[1].Split(' ')) //Split Addresses by space and add it into Entered_Addresses
            {
                Entered_Addresses.Add(Convert.ToInt32(Address));
            }

            //DistanceSub();
            Console.WriteLine(Methods.Check_NearestDistanceFront(Entered_Addresses, 0, 0));

            //Methods.Kombinations(20);
            //Houses();
            //GetBiggestDistance();
            // GetAllDistances();
            Console.ReadKey();
        }

        public static void Check()
        {
            for (int i = 0; i < Place_Check.Length; i++)
            {
                if (Place_Check[i] == 0 && i == firstBude)
                {
                    Console.WriteLine(firstBude);
                }
                if (Place_Check[i] == 0 && i == SecondBude)
                {
                    Console.WriteLine(SecondBude);
                }

                if (Place_Check[i] == 0 && i == thirdBude)
                {
                    Console.WriteLine(thirdBude);
                }
                else
                {
                    while (Place_Check[thirdBude] < 20)
                    {
                        if (Place_Check[thirdBude] == 0)
                        {
                            Console.WriteLine($"{thirdBude}");
                            break;
                        }
                        thirdBude++;
                    }
                }
            }
        }
        public static void Houses()
        {
            int j = 0;

            for (int i = 0; i <= Convert.ToInt32(Umfang); i++)
            {
                if (j < Entered_Addresses.Count)
                {
                    if (i == Entered_Addresses[j])
                    {
                        Place_Check[i] = 1;
                        // Console.WriteLine($"{i},  Pos={Entered_Addresses[j]}  =Haus");
                        j++;

                    }
                    else
                    {
                        Place_Check[i] = 0;
                        //Console.WriteLine($"{i}");
                    }
                }
                else
                {
                    Place_Check[i] = 0;
                    //Console.WriteLine($"{i}");
                }
            }
        }

        public static int GetBiggestDistance()
        {
            int sum = 0;
            int[,] Bude_Pos = new int[Convert.ToInt32(Amount_Haus), Convert.ToInt32(Amount_Haus)];
            for (int i = 1; i < Convert.ToInt32(Amount_Haus); i++)
            {
                sum = Convert.ToInt32((Entered_Addresses[i] - Entered_Addresses[i - 1]) / 2);
                Bude_Pos[0, i] = Entered_Addresses[i] - Entered_Addresses[i - 1];
                Bude_Pos[1, i] = Entered_Addresses[i - 1] + sum;

                //Console.WriteLine($"Calc: {Entered_Addresses[i]} {Entered_Addresses[i - 1]}= {Entered_Addresses[i] - Entered_Addresses[i - 1]}, Pos={Entered_Addresses[i - 1] + sum}");
            }



            /*Console.WriteLine($"{Bude_Pos[0, 0]}, Pos:{Bude_Pos[1, 0]}");
            Console.WriteLine($"{Bude_Pos[0, 1]}, Pos:{Bude_Pos[1, 1]}");
            Console.WriteLine($"{Bude_Pos[0, 2]}, Pos:{Bude_Pos[1, 2]}");
            Console.WriteLine($"{Bude_Pos[0, 3]}, Pos:{Bude_Pos[1, 3]}");
            Console.WriteLine($"{Bude_Pos[0, 4]}, Pos:{Bude_Pos[1, 4]}");
            Console.WriteLine($"{Bude_Pos[0, 5]}, Pos:{Bude_Pos[1, 5]}");
            Console.WriteLine($"{Bude_Pos[0, 6]}, Pos:{Bude_Pos[1, 6]}");
            */
            for (int i = 0; i < 3; i++)
            {

                //Console.WriteLine(Methods.GetMaxNum(Bude_Pos, 0));
                Console.WriteLine("House Pos= " + Bude_Pos[1, Methods.Array2D_GetMaxNum_index(Bude_Pos, 0)]);
                Bude_Pos[0, Methods.Array2D_GetMaxNum_index(Bude_Pos, 0)] = 0;
            }
            //Console.WriteLine(max_nums[0]);
            //Console.WriteLine(max_nums[1]);
            //Console.WriteLine(max_nums[2]);

            return 0;
        }

        public static int GetAllDistances()
        {
            for (int i = 1; i < Entered_Addresses.Count; i++)
            {
                if (Entered_Addresses[i - 1] > Entered_Addresses[i])
                {
                    Console.WriteLine(Entered_Addresses[i - 1] - Entered_Addresses[i]);
                    //return Entered_Addresses[i - 1] - Entered_Addresses[i];
                }
                else
                {
                    Console.WriteLine(Entered_Addresses[i] - Entered_Addresses[i - 1]);
                    //return Entered_Addresses[i] - Entered_Addresses[i - 1];
                }
            }
            return 0;
        }


        public static void DistanceSub()
        {
            int i = 0;
            int val_j = 0;
            int j_endloop = val_j + 3;

            int start = i;
            int sum = 0;
            int[] min_tmp = new int[3];
            int sum_LastNum = 0;
            //List<int> min_tmp = new List<int>();
            //TODO: Rückwärts suchen | Eisbude posi zur nächstgelegenden zusammen rechnen 

            for (i = 0; i < Entered_Addresses.Count; i++)
            {
                for (int j = val_j; j < j_endloop; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (Entered_Addresses[i] >= j)
                        {
                            if (i != Entered_Addresses.Count - 1)
                            {
                                sum = Entered_Addresses[i] - j;
                                min_tmp[k] = sum;
                                Console.WriteLine($"{Entered_Addresses[i]} - {j}= {Entered_Addresses[i] - j} ");

                            }
                            else
                            {
                                //Console.WriteLine($"{Entered_Addresses[i]} = {start}");
                                sum_LastNum = Entered_Addresses[i] - Entered_Addresses[i - 1];
                                min_tmp[k] = Entered_Addresses[i] - (Entered_Addresses[i] - j);
                                if (sum_LastNum < Methods.Array1D_GetMinNum(min_tmp))
                                    Console.WriteLine($"{Entered_Addresses[i]}. {Entered_Addresses[i - 1]}");
                                else
                                    Console.WriteLine($"{Entered_Addresses[i]}. {start}");

                                //Console.WriteLine($"{Entered_Addresses[i]}. sum_LastNum={sum_LastNum} | min_tmp={min_tmp[j]}");
                            }
                        }

                    }
                }
            }
        }


        public static void CheckAllKombinations() // Kombination von den Häuser und den Buden 
        {
            for (int i = 0; i < Convert.ToInt32(Umfang); i++)
            {
                for (int j = i; j < Convert.ToInt32(Umfang); j++)
                {
                    for (int k = j; k < Convert.ToInt32(Umfang); k++)
                    {
                        if (i != k && i != j && k != j)
                        {

                        }
                    }
                }
            }
        }
    }
}