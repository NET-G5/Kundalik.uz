namespace Kundalik.Uz.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
