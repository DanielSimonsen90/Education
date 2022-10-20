using ABCLibrary.Interfaces;

namespace ABCLibrary.Specs
{
    public abstract class C
    {
        protected B Team { get; set; }
        public C(B team) => Team = team;
    }
}
