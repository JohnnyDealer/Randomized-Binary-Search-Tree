using Randomized_Binary_Search_Tree.Binary_Tree_Sones;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Randomized_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Primer_1();
            Console.ReadLine();
        }


        public static void floyd()
        {
            int[,] A = new int [5,5] {
                {0, 10, 6, 3, 100},
                {100, 0, 4, 10, 6},
                {100, 2, 0, 100, 2},
                {100, 8, 3, 0, 100},
                {4, 100, 100, 4 ,0 }
            };
            for(int k = 0; k < 5; k++)
            {

                for(int i = 0; i < 5; i++)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        A[i, j] = min(A[i, j], A[i, k] + A[k, j]);
                    }
                }   
                for(int n = 0; n < 5; n++)
                {
                    for (int p = 0; p < 5; p++)
                        Console.Write(A[n, p] + "\t");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        public static int min(int a, int b)
        {
            if (a > b)
                return b;
            else
                return a;
        } 
        public static void Test()
        {
            Stopwatch stopwatch = new Stopwatch();
            
            Random rand = new Random();
            int j = rand.Next(1, 100);
            BinaryTree A = new BinaryTree();
            BinaryTree B = new BinaryTree();
            for (int i = 1; i <= 10; i++)
            {
                stopwatch.Start();
                for (int k = 0; k < i * 5; k++)
                    A.Add_Test(rand.Next(1, 100));
                A.Print_First();
                A.Add_Test(j);
                A.Find_Test(j);
                Console.WriteLine();
                Console.WriteLine($"Сложность выполнения O(F(n)) = {Math.Log(i * 5, 2)}");
                stopwatch.Stop();
                Console.WriteLine($"Время выполнения: {(double)stopwatch.ElapsedMilliseconds/1000} секунды");
                Console.WriteLine();
                Console.WriteLine($"N_op = {BinaryTree.N_op}");
                Console.WriteLine();
                Console.WriteLine($"O(F(n))/ T(n) = {(int)Math.Log(i * 5, 2) / ((double)stopwatch.ElapsedMilliseconds / 1000)}");
                Console.WriteLine();
                Console.WriteLine($" O(F(n)) / N_op = {Math.Log(i * 5, 2) / BinaryTree.N_op}");
                

            }
            Console.WriteLine();
          
        }
        public static void Primer_1()
        {
            Tree A = new Tree();
            Tree B = new Tree();
            for (int i = 1; i <= 35; i++)            
                A.Add(i);
            for (int i = 10; i <= 20; i++)
                B.Add(i);
            //A.Show();
            A.Print(true);
            A.Bypass("reverse");
            B.Print(true);
            B.Bypass("symmetric");
            Tree.Execute(A, B);
            Console.WriteLine();
            Console.WriteLine("Операция добавочного пересечения множеств A и B:");
            A.Print(true);
        }
        public static void Primer_2()
        {
            Random rand = new Random();            
            Tree A = new Tree();
            Tree B = new Tree();
            for (int i = 1; i <=30; i++)
                A.Add(rand.Next(1, 30));
            for (int i = 1; i <= 30; i++)
                B.Add(rand.Next(1, 100));
            A.Print(true);
            //A.Bypass();
            B.Print(true);
            //B.Bypass();
            Tree.Execute(A, B);
            Console.WriteLine();
            Console.WriteLine("Операция добавочного пересечения множеств A и B:");
            A.Print(true);
        }
    }
}
