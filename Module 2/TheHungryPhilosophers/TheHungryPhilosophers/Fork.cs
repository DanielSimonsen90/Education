using System;
using System.Collections.Generic;
using System.Text;

namespace TheHungryPhilosophers
{
    class Fork
    {
        public bool Occupied { get; set; }
        public string OccupiedByName { get; set; }
        public Fork() => Occupied = false;
        public bool OccupiedBy(Philosopher p) => OccupiedByName == p.Name;
        public override string ToString() => Occupied.ToString();
    }
}
