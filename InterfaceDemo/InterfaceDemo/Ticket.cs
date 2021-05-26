using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemo
{
    class Ticket : IEquatable<Ticket>
    {
        public int DurationInHours { get; set; }

        // simple constructor
        public Ticket(int durationInHours)
        {
            DurationInHours = durationInHours;
        }

        public bool Equals(Ticket other)
        {
            return this.DurationInHours == other.DurationInHours;
        }
    }
}
