namespace pavel_sorokin_kt_41_21.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int GroupId { get; set; }

        public int DisciplineId { get; set; }

        public Group Group { get; set; }
        public Discipline Discipline { get; set; }
    }
}
