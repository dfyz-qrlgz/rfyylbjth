using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRR8888
{
    internal class TimeS
    {
        public string Name;
        public double SpeedMin;
        public double SpeedSec;
        public TimeS(string name, double speedmin, double speedsec)
        {
            Name = name;
            SpeedSec = speedsec;
            SpeedMin = speedmin;
        }
    }
}