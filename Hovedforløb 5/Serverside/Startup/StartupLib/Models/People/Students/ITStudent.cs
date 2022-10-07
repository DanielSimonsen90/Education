namespace StartupLib.Models.People.Students
{
    public class ITStudent : Student
    {
        public ITStudent(string name, School school, DateTime startTime, Employee mainTeacher) : 
            base(name, school, startTime, mainTeacher)
        {
        }

        public bool HasCiscoCertificate { get; set; }
    }
}
