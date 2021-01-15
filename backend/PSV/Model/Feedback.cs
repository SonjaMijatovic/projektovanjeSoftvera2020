using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class Feedback : Entity
    {
        public string Content { get; set; }
        public User User { get; set; }
        public bool Visible { get; set; }
    }
}
