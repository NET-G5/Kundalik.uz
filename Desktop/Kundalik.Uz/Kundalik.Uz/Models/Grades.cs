namespace Kundalik.Uz.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public string GradeValue { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        public virtual TeacherSubject TeacherSubject { get; set; }

    }
}
