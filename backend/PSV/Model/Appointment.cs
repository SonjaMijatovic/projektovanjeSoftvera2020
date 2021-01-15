using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Appointment : Entity
    {
        public User Patient { get; set; }
        public User Doctor { get; set; }
        public bool IsFree { get; set; }
        public DateTime Date { get; set; }
    }
}
