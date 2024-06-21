namespace Kundalik.Uz.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public string GradeValue { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }


    }
}
