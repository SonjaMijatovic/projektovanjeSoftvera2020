using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Recepie
    {
        public User Patient { get; set; }
        public Medicine Medicine { get; set; }
        public double Amount { get; set; }
    }
}
