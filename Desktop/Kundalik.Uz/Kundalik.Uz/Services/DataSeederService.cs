using Bogus;
using Kundalik.Uz.Data;
using Kundalik.Uz.Models;

namespace Kundalik.Uz.Services
{
    public class DataSeederService
    {
        private static Faker faker = new();

        public static void SeedDatabase()
        {
            using var context = new KundalikDbContext();

            CreateClases(context);
        }

        private static void CreateStudents(KundalikDbContext context)
        {
            if (context.Students.Any()) return;

            for (int i = 0; i < 1000; i++)
            {
                var student = new Student();
                var gender = GetRandomGender();
                var firstName = faker.Name.FirstName(gender);
                var lastName = faker.Name.LastName(gender);
                var classIds = context.Classes.Select(c => c.Id).ToArray();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Class_id = faker.PickRandom(classIds);
                student.PhoneNumber = faker.Phone.PhoneNumber("+998##-###-##-##");
                student.UserName = faker.Internet.UserName(firstName, lastName);
                student.Password = faker.Internet.Password(8);

                context.Students.Add(student);
            }

            context.SaveChanges();
        }

        private static void CreateTeachers(KundalikDbContext context)
        {
            if (context.Teachers.Any()) return;

            for (int i = 0; i < 100; i++)
            {
                var teacher = new Teacher();
                var gender = GetRandomGender();
                var firstName = faker.Name.FirstName(gender);
                var lastName = faker.Name.LastName(gender);

                teacher.FirstName = firstName;
                teacher.LastName = lastName;
                teacher.PhoneNumber = faker.Phone.PhoneNumber("+998##-###-##-##");
                teacher.UserName = faker.Internet.UserName(firstName, lastName);
                teacher.Password = faker.Internet.Password(8);
            }

            context.SaveChanges();
        }

        private static void CreateClases(KundalikDbContext context)
        {
            if (context.Classes.Any()) return;

            for (int i = 1; i < 12; i++)
            {
                for (char j = 'a'; j < 'e'; j++)
                {
                    var schoolClass = new Class();
                    schoolClass.Name = i.ToString() + j.ToString();
                    context.Classes.Add(schoolClass);
                }
            }
            context.SaveChanges();
        }

        private static void AddClassToTeacher(KundalikDbContext context)
        {
            HashSet<Class> classes = new HashSet<Class>();

            foreach (Class c in context.Classes)
            {
                classes.Add(c);
            }

            foreach (Teacher teacher in context.Teachers)
            {
                var classItem = classes.FirstOrDefault(c => c.Teacher == null);

                if (classItem != null)
                {
                    classItem.Teacher = teacher;
                    teacher.Class_id = classItem.Id;
                }
            }

        }

        private static Bogus.DataSets.Name.Gender GetRandomGender()
        {
            var randomNum = faker.Random.Number(min: 1, max: 9);

            return randomNum % 2 == 0 ? Bogus.DataSets.Name.Gender.Male : Bogus.DataSets.Name.Gender.Female;
        }
    }
}
