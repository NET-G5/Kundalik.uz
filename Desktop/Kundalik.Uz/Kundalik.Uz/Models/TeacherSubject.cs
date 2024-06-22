namespace Kundalik.Uz.Models
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Grades> Grades { get; set; }
    }
}
