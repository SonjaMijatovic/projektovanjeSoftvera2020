using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Medicine : Entity
    {
        public string Name { get; set; }

        public double Amount { get; set; }
    }
}
