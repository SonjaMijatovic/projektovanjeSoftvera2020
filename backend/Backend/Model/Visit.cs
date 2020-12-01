using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Model
{
    public class Visit : Entity
    {
        public User Patient { get; set; }
        public User Doctor { get; set; }
        public Appointment Appointment { get; set; }
        public string Content { get; set; }        
    }
}
