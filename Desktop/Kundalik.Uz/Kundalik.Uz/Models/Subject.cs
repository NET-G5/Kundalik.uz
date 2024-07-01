namespace Kundalik.Uz.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Grades> Grades { get; set; }
        public Subject()
        {
            Grades = new List<Grades>();
        }
    }
}
