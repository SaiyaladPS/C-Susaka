using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation_Exchange
{
    class Program
    {
        class Exchage
        {
            public void BathToKip(int bath, int rate)
            {
                int kip;
                kip = bath * rate;
                Console.WriteLine("bath={0:N0} ; rate={1:N0} => kip={2:N0}", bath, rate, kip);
                Console.WriteLine("bath=" + bath.ToString("#,###") + "; rate=" + rate + " => kip" + kip.ToString("#,###"));
            }
        }
        static void Main(string[] args)
        {
            Exchage ex = new Exchage(); // ປະກາດແລະສ້າງອອບເຈັກຊື່ວ່າ ex
            int b, r;
            Console.Write("Enter bath: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("Enter rate: ");
            r = int.Parse(Console.ReadLine());
            ex.BathToKip(b, r);
            Console.ReadLine();
        }
    }
}
