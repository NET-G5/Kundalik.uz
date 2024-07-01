namespace Kundalik.Uz.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher  { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public Class()
        {
            Students = new List<Student>();
        }

    }
}
