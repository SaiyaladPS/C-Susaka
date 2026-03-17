using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassConvert;
using ClassConveretMileToKilomat;
using ClassConvertWeight;

namespace Use_DLL_FILE
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionConvert fc = new FunctionConvert();
            MileToKilomat mk = new MileToKilomat();
            WeightConvert wc = new WeightConvert();
            int choice;
            Console.WriteLine("=====-MENU-=====");
            Console.WriteLine("1. To convert celsius to fahrenheit");
            Console.WriteLine("2. To convert fahrenheit to celsius");
            Console.WriteLine("3. To convert mile to kilomat");
            Console.WriteLine("4. To convert kilomat to mile");
            Console.WriteLine("5. To convert Pounds to Kilograms");
            Console.WriteLine("6. To convert Kilograms to Pounds");
            Console.WriteLine("7. To convert Ounces to Grams");
            Console.WriteLine("8. To convert Grams to Ounces");
            Console.WriteLine("0. To Exit");
            do
            {
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Enter Degrees celsius(c): ");
                    double c = double.Parse(Console.ReadLine());
                    fc.C2F(c);
                } else if (choice == 2)
                {
                    Console.Write("Enter Degrees fahrenheit(f): ");
                    double f = double.Parse(Console.ReadLine());
                    fc.F2C(f);
                }else if(choice == 3)
                {
                    Console.Write("Enter Mile(m): ");
                    double mile = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:N2} Mile = {1:N2} Kilomat", mile, mk.M2K(mile));
                }else if(choice == 4)
                {
                    Console.Write("Enter Kilomat(k): ");
                    double kilomat = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:N2} Kilomat = {1:N2} mile", kilomat, mk.K2M(kilomat));
                }else if(choice == 5)
                {
                    Console.Write("Enter Pounds(lb): ");
                    double pound = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:N2} Pounds = {1:N2} Kilograms", pound, wc.P2K(pound));
                }else if(choice == 6)
                {
                    Console.Write("Enter Kilograms(kg): ");
                    double kg = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:N2} Kilograms = {1:N2} Pounds", kg, wc.K2P(kg));
                }else if (choice == 7)
                {
                    Console.Write("Enter Ounces(oz): ");
                    double oz = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:N2} Ounces = {1:N2} Grams", oz, wc.O2G(oz));
                }
                else if (choice == 8)
                {
                    Console.Write("Enter Grams(g): ");
                    double g = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:N2} Grams = {1:N2} Ounces", g, wc.G2O(g));
                }
            } while (choice != 0);
        }
    }
}
