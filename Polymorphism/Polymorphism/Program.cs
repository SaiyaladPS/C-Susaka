using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        class CalculateArea
        {
            double s;

            
            public void Area(double r)
            {
                s = Math.PI * Math.Pow(r, 2);
                Console.WriteLine("Area of circle = {0:N2}", s);
            }

            
            public void Area(int a, int h)
            {
                s = (a * h) / 2.0;
                Console.WriteLine("Area of Triangle = {0:N2}", s);
            }

            
            public void Area(double l, double w)
            {
                s = l * w;
                Console.WriteLine("Area of Retriangle = {0:N2}", s);
            }

            
            public void Area(float a)
            {
                s = Math.Pow(a, 2);
                Console.WriteLine("Area of Square = {0:N2}", s);
            }

           
            public void Area(double l1, double l2, double h)
            {
                s = ((l1 + l2) * h) / 2.0;
                Console.WriteLine("Area of Trapzone = {0:N2}", s);
            }
        }

        static void Main(string[] args)
        {
            CalculateArea Ca = new CalculateArea();
            int choice;

            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Calculate Area of Circle");
                Console.WriteLine("2. Calculate Area of Triangle");
                Console.WriteLine("3. Calculate Area of Retriangle");
                Console.WriteLine("4. Calculate Area of Square");
                Console.WriteLine("5. Calculate Area of Trapzone");
                Console.WriteLine("0. Exit");
                Console.WriteLine("--------------------------");
                Console.Write("Enter choice: ");

                
                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                if (choice == 1)
                {
                    Console.Write("Enter radian: ");
                    double radian = double.Parse(Console.ReadLine());
                    Ca.Area(radian);
                }
                else if (choice == 2)
                {
                    Console.Write("Enter base (a): ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Enter height (h): ");
                    int h = int.Parse(Console.ReadLine());
                    Ca.Area(a, h);
                }
                else if (choice == 3)
                {
                    Console.Write("Enter length (l): ");
                    double l = double.Parse(Console.ReadLine());
                    Console.Write("Enter width (w): ");
                    double w = double.Parse(Console.ReadLine());
                    Ca.Area(l, w);
                }
                else if (choice == 4)
                {
                    Console.Write("Enter side length (a): ");
                    float a = float.Parse(Console.ReadLine());
                    Ca.Area(a);
                }
                else if (choice == 5)
                {
                    Console.Write("Enter parallel side 1 (l1): ");
                    double l1 = double.Parse(Console.ReadLine());
                    Console.Write("Enter parallel side 2 (l2): ");
                    double l2 = double.Parse(Console.ReadLine());
                    Console.Write("Enter height (h): ");
                    double h = double.Parse(Console.ReadLine());
                    Ca.Area(l1, l2, h);
                }

            } while (choice != 0);

            Console.WriteLine("Goodbye!");
        }
    }
}