using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LR3

{
    class Program
    {
        public static void GetRad(double[] arr)
        {
            for (int i = 0;
                i < arr.Length;
                i++)
            {
                arr[i] = Math.Round(arr[i] * Math.PI / 180, 12);
            }
        }

        public static void GetL1(double[] arrX, double[] arrY, int[] startPos,double[] arrXpoint)
        {
            for (int i = 0; i < startPos.Length; i++)
            {
                if (startPos[i]!=arrX.Length-1)
                {
                    double l1 =Math.Round(
                        ((arrXpoint[i] - arrX[startPos[i]]) / (arrX[startPos[i] + 1] - arrX[startPos[i]]) *
                         arrY[startPos[i] + 1] 
                         - ((arrXpoint[i] - arrX[startPos[i] + 1]) /
                             (arrX[startPos[i] + 1] - arrX[startPos[i]]) * arrY[startPos[i]])),12);
                    Console.WriteLine($"L1({arrXpoint[i]})={l1}");
                }
                else
                {
                    double l1 = Math.Round(((arrXpoint[i] - arrX[startPos[i] - 1]) /
                                            (arrX[startPos[i]] - arrX[startPos[i] - 1]) *
                                            arrY[startPos[i]]
                                            - ((arrXpoint[i] - arrX[startPos[i]]) /
                                                (arrX[startPos[i]] - arrX[startPos[i] - 1]) * arrY[startPos[i] - 1])),
                        12);
                    Console.WriteLine($"L1({arrXpoint[i]})={l1}");
                }
            }
        }

        public static void GetL2(double[] arrX, double[] arrY, int[] startPos,double[] arrXpoint)
        {
            for (int i = 0; i < startPos.Length; i++)
            {
                if (startPos[i]!=arrX.Length-1)
                {
                    double l2 =Math.Round((arrXpoint[i]-arrX[startPos[i]-1])*(arrXpoint[i]-arrX[startPos[i]+1])/((arrX[startPos[i]]-arrX[startPos[i]-1])*(arrX[startPos[i]]-arrX[startPos[i]+1]))*arrY[startPos[i]]
                                          +(arrXpoint[i]-arrX[startPos[i]])*(arrXpoint[i]-arrX[startPos[i]+1])/((arrX[startPos[i]-1]-arrX[startPos[i]])*(arrX[startPos[i]-1]-arrX[startPos[i]+1]))*arrY[startPos[i]-1]
                                          +(arrXpoint[i]-arrX[startPos[i]-1])*(arrXpoint[i]-arrX[startPos[i]])/((arrX[startPos[i]+1]-arrX[startPos[i]-1])*(arrX[startPos[i]+1]-arrX[startPos[i]]))*arrY[startPos[i]+1]
                        ,12);
                    Console.WriteLine($"L2({arrXpoint[i]})={l2}");
                }
                else
                {
                    double l2 =Math.Round((arrXpoint[i]-arrX[startPos[i]-2])*(arrXpoint[i]-arrX[startPos[i]])/((arrX[startPos[i]-1]-arrX[startPos[i]-2])*(arrX[startPos[i]-1]-arrX[startPos[i]]))*arrY[startPos[i]-1]
                                          +(arrXpoint[i]-arrX[startPos[i]-1])*(arrXpoint[i]-arrX[startPos[i]])/((arrX[startPos[i]-2]-arrX[startPos[i]-1])*(arrX[startPos[i]-2]-arrX[startPos[i]]))*arrY[startPos[i]-2]
                                          +(arrXpoint[i]-arrX[startPos[i]-2])*(arrXpoint[i]-arrX[startPos[i]-1])/((arrX[startPos[i]]-arrX[startPos[i]-2])*(arrX[startPos[i]]-arrX[startPos[i]-1]))*arrY[startPos[i]]
                        ,12);
                    Console.WriteLine($"L2({arrXpoint[i]})={l2}");
                }
            }
        }

        public static void PrintSceme(double[,] arr,int statPos)
        {
            Console.Write("\n     ");
            for (int i = 1; i < 8; i++)
            {
                Console.Write("{0,-16}",i);
            }

            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0,-3}",$"i{i}:");
                for (int j = 0; j < 7; j++)
                {
                    if(arr[i,j]!=0)
                    Console.Write("{0,-16}","|"+arr[i,j]);
                    else
                        Console.Write("{0,-16}","|");
                }

                Console.WriteLine("|");
                
            }

            Console.WriteLine();
            if(statPos!=7)
            for (int i = 0; i <6-statPos+1; i++)
            {
                Console.Write("{0,-18}",$"\u0394{i+1}="+Math.Abs(Math.Round(arr[statPos, i + 1] - arr[statPos, i], 12)));
                if(Math.Abs(arr[statPos, i + 2] - arr[statPos, i+1])>Math.Abs(arr[statPos, i + 1] - arr[statPos, i]))
                    break;
                    
            }
            else
            {
                for (int i = 0; i <6-4; i++)
                {
                    Console.Write("{0,-18}",$"\u0394{i+1}="+Math.Abs(Math.Round(arr[4, i + 1] - arr[4, i], 12)));
                }
            }

            Console.WriteLine("\n\n\n");
        }
        /*public static void GetEitkinScheme(double[] arrX, double[] arrY, int[] startPos, double[] arrXpoint)
        {
            double[,] scemeEitkin = new double[7, 7];
            for (int j = 0; j < 7; j++)
            {
                if(j==0)
                for (int i = 0; i <7; i++)
                {
                scemeEitkin[i,j]=Math.Round(
                    ((arrXpoint[0] - arrX[i]) / (arrX[i+1] - arrX[i]) *
                     arrY[i + 1] 
                     - ((arrXpoint[0] - arrX[i + 1]) /
                         (arrX[i + 1] - arrX[i]) * arrY[i])),12);
                }
                else
                {
                    for (int i = 0; i < 7-j; i++)
                    {
                        scemeEitkin[i,j]=Math.Round(1/(arrX[i+2]-arrX[i])*Math.Abs((arrXpoint[0]-arrX[i])*scemeEitkin[i+1,j-1]-(arrXpoint[0]-arrX[i+2])*scemeEitkin[i,j-1]),12);
                    }
                }
            } */
        
        public static void GetEitkinScheme(double[] arrX, double[] arrY, int startPos,double arrXpoint)
        {
            double[,] scemeEitkin = new double[7, 7];
            if(startPos!=7)
            for (int j = 0; j < 7; j++)
            {
                if(j==0)
                    for (int i = startPos-1; i <7; i++)
                    {
                        scemeEitkin[i,j]=Math.Round(
                            ((arrXpoint - arrX[i]) / (arrX[i+1] - arrX[i]) *
                             arrY[i + 1] 
                             - ((arrXpoint - arrX[i + 1]) /
                                 (arrX[i + 1] - arrX[i]) * arrY[i])),12);
                    }
                else
                {
                    for (int i = startPos-1; i < 7-j; i++)
                    {
                        scemeEitkin[i,j]=Math.Round(1/(arrX[i+2]-arrX[i])*Math.Abs((arrXpoint-arrX[i])*scemeEitkin[i+1,j-1]-(arrXpoint-arrX[i+2])*scemeEitkin[i,j-1]),12);
                    }
                }
            }
            else
            {
                for (int j = 0; j < 7; j++)
                {
                    if(j==0)
                        for (int i = 4; i <7; i++)
                        {
                            scemeEitkin[i,j]=Math.Round(
                                ((arrXpoint - arrX[i]) / (arrX[i+1] - arrX[i]) *
                                 arrY[i + 1] 
                                 - ((arrXpoint - arrX[i + 1]) /
                                     (arrX[i + 1] - arrX[i]) * arrY[i])),12);
                        }
                    else
                    {
                        for (int i = 4; i < 7-j; i++)
                        {
                            scemeEitkin[i,j]=Math.Round(1/(arrX[i+2]-arrX[i])*Math.Abs((arrXpoint-arrX[i])*scemeEitkin[i+1,j-1]-(arrXpoint-arrX[i+2])*scemeEitkin[i,j-1]),12);
                        }
                    }
                } 
            }
            
            PrintSceme(scemeEitkin,startPos);

        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double[] arrX = new double[] {5, 10, 15, 20, 25, 30, 35, 40};
            double[] arrY = new double[] {0.996, 0.985, 0.966, 0.94, 0.906, 0.866, 0.819, 0.766};
            double[] arrXPoint = new Double[] {12, 26, 42};
            GetRad(arrXPoint);
            GetRad(arrX);
            foreach (var VARIABLE in arrX)
            {
                Console.Write(VARIABLE + " ");
            }

            Console.WriteLine();
            foreach (var VARIABLE in arrXPoint)
            {
                Console.Write(VARIABLE + " ");
            }

            int[] startPos = new int[3];
            for (int i = 0; i <startPos.Length; i++)
            {
                for (int j = 0; j < arrX.Length; j++)
                {
                    if (arrX[j]<arrXPoint[i])
                    {
                        startPos[i] = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            /*Console.Write("\nstartPosX:");

            foreach (var VARIABLE in startPos)
            {
                Console.Write(VARIABLE+" ");
            }*/
            Console.WriteLine();
            /*Lafrang*/
            GetL1(arrX,arrY,startPos,arrXPoint);
            GetL2(arrX,arrY,startPos,arrXPoint);
            
            /*Eitkin*/

            for (int i = 0; i < 3; i++)
            {
                GetEitkinScheme(arrX,arrY,startPos[i],arrXPoint[i]);
            }
            
        }
    }
}