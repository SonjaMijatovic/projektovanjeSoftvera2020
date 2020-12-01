using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Model
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        // Doctro

        public DoctorType DoctorType { get; set; }

        // Patient

        public User Doctor { get; set; }
        public bool IsFirstTime { get; set; }
        public bool Blocked { get; set; }

    }
}
