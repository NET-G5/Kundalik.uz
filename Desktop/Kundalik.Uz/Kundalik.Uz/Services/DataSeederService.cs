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
            CreateStudents(context);
            CreateTeachers(context);
            AddStudentToClass(context);
            AddSubjectToTeacher(context);
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

            for (int i = 0; i < 1; i++)
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

                context.Teachers.Add(teacher);
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

        private static void AddSubjectToTeacher(KundalikDbContext context)
        {
            var teachers = context.Teachers.ToList();

            foreach(var subject in context.Subjects)
            {
                var teacher = teachers.FirstOrDefault(t => t.Subject is null);

                if(teacher is not null)
                {
                    subject.TeacherId = teacher.Id;
                    teacher.Subject = subject;
                    
                }
            }
            context.SaveChanges();
        }

        private static void AddStudentToClass(KundalikDbContext context)
        {
            var studentIds = context.Students.Select(x => x.Id).ToArray();
            var classIds = context.Classes.Select(x => x.Id).ToList();
            int counter = 0;

            foreach (var student in context.Students)
            {
                if (counter == 22)
                {
                    classIds.Remove(student.Class_id);
                    counter = 0;
                }
                student.Class_id = classIds[0];
                counter++;
            }
        }

        private static Bogus.DataSets.Name.Gender GetRandomGender()
        {
            var randomNum = faker.Random.Number(min: 1, max: 9);

            return randomNum % 2 == 0 ? Bogus.DataSets.Name.Gender.Male : Bogus.DataSets.Name.Gender.Female;
        }
    }
}
