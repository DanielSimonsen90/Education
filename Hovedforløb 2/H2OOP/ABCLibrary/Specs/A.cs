namespace ABCLibrary.Specs
{
    public abstract class A : Interfaces.ITeamMember
    {
        public string Name { get; }
        public A(string name) => Name = name;
    }
}
