using Kundalik.Uz.Data;
using Kundalik.Uz.Models;
using Kundalik.Uz.Services;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Kundalik.Uz.View_models
{
    public class StudentsViewModel : BaseViewModel
    {
        private readonly KundalikDbContext _context;
        private readonly StudentsService _studentsService;

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

        private List<Student> studentsList;
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Class> Classes { get; set; }

        public StudentsViewModel()
        {
            _studentsService = new StudentsService();
            Students = new ObservableCollection<Student>();
            Classes = new ObservableCollection<Class>();
            studentsList = new List<Student>();
            _context = new KundalikDbContext();

            Load();
        }

        private void Load()
        {
            var students = _studentsService.GetStudents();
            var classes = _context.Classes.ToList();

            foreach (var student in students)
            {
                Students.Add(student);
                studentsList.Add(student);
            }

            foreach(var clazz in classes)
            {
                Classes.Add(clazz);
            }
        }

        private void SearchStudents(int id)
        {
            var students = studentsList.Where(student => student.Class_id == id).ToList();

            Students.Clear();

            foreach (var student in students)
            {
                Students.Add(student);
            }
        }


    }
}
