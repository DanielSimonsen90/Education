namespace StartupLib.Models.People
{
    public abstract class Person : Base
    {
        public int SchoolId { get; set; } = -1;
        public School? School { get; set; }
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        public DateTime StartTime { get; set; } = DateTime.Now;

        public Person() {}
        public Person(string name, School school, DateTime? startTime = default, params Subject[] subjects)
        {
            Name = name;
            
            School = school;
            SchoolId = school.Id;
            StartTime = startTime ?? DateTime.Now;
            Subjects = subjects;
        }
    }
}
