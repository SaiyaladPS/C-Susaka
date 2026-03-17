using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassConvertWeight
{
    public class WeightConvert
    {
        public double K2P(double kilo)
        {
            return kilo * 2.20462;
        }
        public double P2K(double pound)
        {
            return pound / 2.20462;
        }
        public double O2G(double ounce)
        {
            return ounce * 28.35;
        }
        public double G2O(double gram)
        {
            return gram / 28.35;
        }
    }
}