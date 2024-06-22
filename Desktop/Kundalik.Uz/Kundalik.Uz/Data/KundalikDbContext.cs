using Kundalik.Uz.Models;
using Microsoft.EntityFrameworkCore;

namespace Kundalik.Uz.Data
{
    internal class KundalikDbContext : DbContext
    {

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<TeacherSubject> TeachersSubjects { get; set; }
        public KundalikDbContext()
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VLH642J;Initial Catalog=KundalikCom;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
               .ToTable(nameof(Student));
            modelBuilder.Entity<Student>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Student>()
                .HasMany(g => g.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(k => k.StudentId);

            modelBuilder.Entity<Teacher>()
               .ToTable(nameof(Teacher));
            modelBuilder.Entity<Teacher>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Subject>()
                .ToTable(nameof(Subject));
            modelBuilder.Entity<Subject>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<TeacherSubject>()
                .ToTable(nameof(TeacherSubject));
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId});
            modelBuilder.Entity<TeacherSubject>()
                .HasMany(m => m.Grades)
                .WithOne(m => m.TeacherSubject)
                .HasForeignKey(k => k.TeacherSubjectId);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.TeacherId);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.SubjectId);

            modelBuilder.Entity<Class>()
                .ToTable(nameof(Class));
            modelBuilder.Entity<Class>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Class>()
                .HasMany(x => x.Students)
                .WithOne(c => c.Class)
                .HasForeignKey(p => p.Class_id);

           modelBuilder.Entity<Grades>()
                .ToTable(nameof(Grades));
            modelBuilder.Entity<Grades>()
                .HasKey(x => x.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
