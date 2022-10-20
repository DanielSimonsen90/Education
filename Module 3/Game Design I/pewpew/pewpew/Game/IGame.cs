using pewpew.Characters;

namespace pewpew
{
    interface IGame
    {
        public Heading Heading { get; }
        public Map Map { get; }

        void Start();
        void Pause();
        void Stop();
    }
}
