namespace Kundalik.Uz.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Class_id { get; set; }
        public virtual Class? Class { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType? role { get; set; }

        public Subject Subject { get; set; }

    }
}
