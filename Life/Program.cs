using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Program
    {
        static void Fill(ref int n, ref int m, int[,] mass2)
        {
            Random rand = new Random();

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    mass2[i, j] = rand.Next(0,2);
                }
            }

            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 || i == n-1 || j == 0 || j == m-1)
                    {
                        mass2[i, j] = 2;
                    }
                }
            }            
        }

        static void Output(ref int n, ref int m, int[,] mass2)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mass2[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }

                    if (mass2[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("  ");
                    }

                    if (mass2[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void Work(ref int n, ref int m, int[,] mass, int[,] mass2)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mass[i, j] = mass2[i, j];
                }
            }

            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < m - 1; j++)
                {
                    int count = 0;
                    if (mass[i - 1, j - 1] == 1) { count++; }
                    if (mass[i - 1, j] == 1) { count++; }
                    if (mass[i - 1, j + 1] == 1) { count++; }
                    if (mass[i, j - 1] == 1) { count++; }
                    if (mass[i, j + 1] == 1) { count++; }
                    if (mass[i + 1, j - 1] == 1) { count++; }
                    if (mass[i + 1, j] == 1) { count++; }
                    if (mass[i + 1, j + 1] == 1) { count++; }
                    
                    switch(count)
                    {
                        case 0:
                            mass2[i, j] = 0;
                            count = 0;
                            break; 
                        case 1:
                            mass2[i, j] = 0;
                            count = 0;
                            break; 
                        case 2:
                            mass2[i, j] = 1;
                            count = 0;
                            break; 
                        case 3:
                            mass2[i, j] = 1;
                            count = 0;
                            break; 
                        case 4:
                            mass2[i, j] = 0;
                            count = 0;
                            break; 
                        case 5:
                            mass2[i, j] = 0;
                            count = 0;
                            break; 
                        case 6:
                            mass2[i, j] = 0;
                            count = 0;
                            break; 
                        case 7:
                            mass2[i, j] = 0;
                            count = 0;
                            break; 
                        case 8:
                            mass2[i, j] = 0;
                            count = 0;
                            break;
                    }

                }
            }
        }

        static void Main(string[] args)
        {
            int n = 0, m = 0;

            Console.WriteLine("Введите размерность поля n(больше 4):");
            Console.Write(">>");
            try { n = Convert.ToInt32(Console.ReadLine()); }
            catch { n = 5; }

            Console.WriteLine("Введите размерность поля m(больше 4):");
            Console.Write(">>");
            try { m = Convert.ToInt32(Console.ReadLine()); }
            catch { m = 5; }

            if (n < 5)
                n = 5;
            if (m < 5)
                m = 5;

            Console.Clear();

            int[,] mass = new int[n,m];
            int[,] mass2 = new int[n,m];
            Fill(ref n, ref m, mass2);
            Output(ref n, ref m, mass2);
            while (true)
            {                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("> Следующий шаг - 1");
                Console.WriteLine("> Завершение программы - 2");
                Console.Write(">>");

                int key;
                try { key = Convert.ToInt32(Console.ReadLine()); }
                catch { key = 1; }

                if(key == 1)
                {
                    Work(ref n, ref m, mass, mass2);
                    Console.Clear();
                    Output(ref n, ref m, mass2);
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("Финальный результат:");
            Output(ref n, ref m, mass2);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
