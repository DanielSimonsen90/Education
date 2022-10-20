using System.Threading;

namespace TheHungryPhilosophers
{
    class Philosopher
    {
        public static object Lock = new object();
        public string Name { get; private set; }
        public Fork LeftFork, RightFork;
        public string ActivityString { get; private set; }
        public Thread Thread;

        public Philosopher(string name, Fork left, Fork right)
        {
            Name = name;
            LeftFork = left;
            RightFork = right;
            ActivityString = "Thinking";
            Thread = new Thread(Activity);
        }

        private void Activity()
        {
            while (true)
            {
                Check(ref RightFork);
                Check(ref LeftFork);

                if (LeftFork.Occupied && LeftFork.OccupiedByName == Name &&
                    RightFork.Occupied && RightFork.OccupiedByName == Name)
                {
                    lock (Lock)
                    {
                        ActivityString = "Eating";
                        Thread.Sleep(500);
                        ActivityString = "Thinking";
                        LeftFork.Occupied = RightFork.Occupied = false;
                    }
                }
                else ActivityString = "Thinking";
            }
        }
        private void Check(ref Fork fork)
        {
            if (fork.Occupied)
                return;

            lock (Lock)
            {
                fork.Occupied = true;
                fork.OccupiedByName = Name;
            }
        }

        public override string ToString() => $"{Name}: {ActivityString}";
    }
}
