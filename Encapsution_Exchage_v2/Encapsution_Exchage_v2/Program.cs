using System;

namespace ES1
{
    class Program
    {
        class Exp
        {
            public void BatchToKip(int batch, int rate)
            {
                int kip = batch * rate;
                Console.WriteLine("batch = {0:N0} * rate = {1:N0} => kip = {2:N0}", batch, rate, kip);
            }

            public void KipToBatch(int kip, int rate)
            {
                if (rate == 0)
                {
                    Console.WriteLine("Rate cannot be zero!");
                    return;
                }

                double bath = (double)kip / rate;
                Console.WriteLine("kip = {0:N0} / rate = {1:N0} => batch = {2:N2}", kip, rate, bath);
            }
            public void DollarToKip()
            {
                int dollar, rate, kip;
                Console.Write("Enter dollar: ");
                dollar = int.Parse(Console.ReadLine());
                Console.Write("Enter rate: ");
                rate = int.Parse(Console.ReadLine());
                kip = dollar * rate;
                Console.WriteLine("Dollar={0:N0}; rate={1:N0} => kip={2:N0}", dollar, rate, kip);
            }
            public void KipToDollar()
            {
                double dollar, rate, kip;
                Console.Write("Enter kip: ");
                kip = double.Parse(Console.ReadLine());
                Console.Write("Enter rate: ");
                rate = double.Parse(Console.ReadLine());
                dollar = kip / rate;
                Console.WriteLine("kip={0:N0}; rate={1:N0} => dollar={2:N0}", kip, rate, dollar);
            }
        }

        static void Main(string[] args)
        {
            Exp obj = new Exp();

            while (true)
            {
                Console.WriteLine("-------------MENU-----------");
                Console.WriteLine("1: Batch to Kip");
                Console.WriteLine("2: Kip to Batch");
                Console.WriteLine("3: DollarToKip");
                Console.WriteLine("4: KipToDollar");
                Console.WriteLine("0: Exit");
                Console.Write("Select Program: ");

                int isProgram;
                if (!int.TryParse(Console.ReadLine(), out isProgram))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (isProgram == 0)
                {
                    Console.WriteLine("Program exited.");
                    break;
                }
                else if (isProgram == 1)
                {
                    Console.Write("Enter your batch: ");
                    int bath = int.Parse(Console.ReadLine());

                    Console.Write("Enter your rate: ");
                    int rate = int.Parse(Console.ReadLine());

                    obj.BatchToKip(bath, rate);
                }
                else if (isProgram == 2)
                {
                    Console.Write("Enter your kip: ");
                    int kip = int.Parse(Console.ReadLine());

                    Console.Write("Enter your rate: ");
                    int rate = int.Parse(Console.ReadLine());

                    obj.KipToBatch(kip, rate);
                }
                else if (isProgram == 3)
                {
                    obj.DollarToKip();
                }
                else if (isProgram == 4)
                {
                    obj.KipToDollar();
                }
                else
                {
                    Console.WriteLine("Invalid menu number!");
                }

                Console.WriteLine();
            }
        }
    }
}