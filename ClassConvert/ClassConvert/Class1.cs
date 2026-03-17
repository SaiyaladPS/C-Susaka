using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassConvert
{
    public class FunctionConvert
    {
        public void C2F(double C)
        {
            double F;
            F = C * 9 / 5 + 32;
            Console.WriteLine("{0:N0} = C = {1:N0} F", C, F);
        }
        public void F2C(double F)
        {
            double C;
            C = (F - 32) * 5 / 9;
            Console.WriteLine("{0:N0} = F = {1:N0} C", F, C);
        }
    }
}
