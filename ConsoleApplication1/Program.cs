using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LR2

{
    class Program

    {
        public static void getArray<T>(T[,] arrA, T[] arrb, int a = -4)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0,-6}", "|" + arrA[i, j]);
                }

                Console.Write("|");
                Console.WriteLine("    |" + arrb[i] + "|");
            }

            Console.WriteLine();
        }

        public static void getArray<T>(T[,] arrEnd, int count)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                    Console.Write("{0,-5}", "K");
                else if (i < 5)
                    Console.Write("{0,-16}", "|" + "X" + i + " ");
                else
                {
                    Console.Write("{0,-16}", "|" + "e" + (i - 4) + " ");
                }
            }

            Console.WriteLine("|");
            for (int i = 0; i < count; i++)
            {
                Console.Write("{0,-5}", "i" + i + ": ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,-16}", "|" + arrEnd[i, j]);
                }


                Console.WriteLine("|");
            }
        }


        public static void Main(string[] args)
        {
            var rd = new Random();
            double[,] arrA =
            {
                {10, -1, 2, -3},
                {1, 10, -1, 2},
                {2, 3, 20, -1},
                {3, 2, 1, 20}
            };
            double[] arrB = {0, 5, -10, 15};
            double[] arrW = new double[4];

            getArray(arrA, arrB);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (i == j)
                        arrB[i] = arrB[i] / arrA[i, i];
                    else
                        arrA[i, j] = -(arrA[i, j] / arrA[i, i]);
                }

                arrA[i, i] = 0;
            }

            getArray(arrA, arrB);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arrW[i] += Math.Abs(arrA[i, j]);
                }
            }

            double maxA = arrW.Max();
            double maxB = 0;
            for (int i = 0; i < arrB.Length; i++)
            {
                if (Math.Abs(arrB[i]) > maxB)
                    maxB = arrB[i];
            }

            Console.WriteLine("||A||=" + maxA + "\n||b||=" + maxB);
            int k = (int) Math.Round(Math.Log(0.0001 * (1 - maxA) / maxB, maxA));
            Console.WriteLine("K=" + k + "\n\n");
            double[,] arrEnd = new double[k, 8];

           

            /*
            double arrMax = 0;
            for (int i = 4; i < 8; i++)
            {
                if (Math.Abs(arrEnd[k - 1, i]) > arrMax)
                    arrMax = arrEnd[k - 1, i];
            }

            getArray(arrEnd, k);
            Console.WriteLine(
                "Априорная оценка погрешности: " + Math.Round((Math.Pow(maxA, k) / (1 - maxA) * maxB), 12));
            Console.WriteLine("Апостериорная оценка погрешности: " + Math.Round(maxA * (1 - maxA) * arrMax, 12));*/
        }
    }
}