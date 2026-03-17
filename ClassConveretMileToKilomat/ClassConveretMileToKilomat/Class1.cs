using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassConveretMileToKilomat
{
    public class MileToKilomat
    {
        public double M2K(double mile)
        {
            return mile / 0.621371;
        }
        public double K2M(double km)
        {
            return km * 0.621371;
        }
    }
}
