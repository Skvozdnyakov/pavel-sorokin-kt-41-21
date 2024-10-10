namespace pavel_sorokin_kt_41_21.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
