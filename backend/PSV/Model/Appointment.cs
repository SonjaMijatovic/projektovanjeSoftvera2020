using System;

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