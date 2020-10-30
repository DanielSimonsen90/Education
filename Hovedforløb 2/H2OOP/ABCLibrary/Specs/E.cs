namespace ABCLibrary.Specs
{
    public abstract class E : Interfaces.ITeamMember
    {
        protected string[] Stages;
        protected int Stage = 0;
        public string Name => Stages[Stage];

        public override string ToString() => Name;
    }
}
