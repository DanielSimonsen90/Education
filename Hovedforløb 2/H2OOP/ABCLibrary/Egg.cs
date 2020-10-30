using System;
using System.Linq;
using System.Timers;

namespace ABCLibrary
{
    public delegate void EggHatching(Egg caller);
    public class Egg : Specs.E
    {
        #region Egg Timer
        private readonly Timer HatchTimer;
        private void NextStage(object sender, ElapsedEventArgs e)
        {
            Stage++;
            if (Stages[Stage] != "Hatched") return;

            OnEggHatch(this);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            HatchTimer.Stop();
        }
        public bool IsHatching => !HatchTimer.Enabled;
        #endregion

        #region Egg Events
        public event EggHatching OnEggHatch;
        #endregion

        public Egg()
        {
            Stages = new string[] { "Clean", "Cracked", "Moving", "Hatched" };
            HatchTimer = new Timer() { Interval = 10000 };
            HatchTimer.Elapsed += NextStage;
            HatchTimer.Start();
        }
        public Egg(string Name) : this() => Stage = Stages.ToList().IndexOf(Name);

        public override string ToString() => $"Egg stage at: {Stages[Stage]}";
    }
}