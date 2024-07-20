using Kundalik.Uz.Data;
using Kundalik.Uz.Models;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Kundalik.Uz.View_models
{
    public class GradesViewModel : BaseViewModel
    {
        private readonly KundalikDbContext _context;

        private Class _selectedClass;
        public Class SelectedClass
        {
            get => _selectedClass;
            set
            {
                SetProperty(ref _selectedClass, value);
                SearchStudents(_selectedClass.Id);
            }
        }

        private Subject _selectedSubject;
       

        private List<Student> studentsList;
        private List<Grades> gradesList;
        public ObservableCollection<Class> Classes { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Grades> Grades { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }

        public GradesViewModel()
        {
            Classes = new ObservableCollection<Class>();
            Students = new ObservableCollection<Student>();
            Grades = new ObservableCollection<Grades>();
            Subjects = new ObservableCollection<Subject>();
            studentsList = new List<Student>();
            gradesList = new List<Grades>();
            _context = new KundalikDbContext();

            Load();
        }

        private void Load()
        {
            var students = _context.Students.ToList();
            var classes = _context.Classes.ToList();
            var grades = _context.Grades.ToList();
            var subjects = _context.Subjects.ToList();

            foreach (var student in students)
            {
                Students.Add(student);
                studentsList.Add(student);
            }
            foreach (var clazz in classes)
            {
                Classes.Add(clazz);
            }
            foreach (var grade in grades)
            {
                Grades.Add(grade);
                gradesList.Add(grade);
            }
            foreach (var subject in subjects)
            {
                Subjects.Add(subject);
            }
        }

        private void SearchStudents(int id)
        {
            var students = studentsList.Where(students => students.Class_id == id).ToList();

            Students.Clear();

            foreach (var student in students)
            {
                Students.Add(student);
            }
        }
    }
}
