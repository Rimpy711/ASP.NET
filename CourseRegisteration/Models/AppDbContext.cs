using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CourseRegisteration.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Registration> Registration { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Students>().HasData(
                 new Students()
                 {
                     StudentId = 1,
                     FirstName = "Peter",
                     LastName = "Smith",
                     Email = "Peter@Gmail.com",
                    Phone = "+4339003456"
                 },
                new Students()
                {
                    StudentId = 2,
                    FirstName = "Josh",
                    LastName = "Gaby",
                    Email = "Josh@yahoo.com",
                    Phone = "+204567988"
                },
                new Students()
                {
                    StudentId = 3,
                    FirstName = "Nancy",
                    LastName = "Maria",
                    Email = "Nancy@yahoo.com",
                    Phone = "+204987900"
                },
                new Students()
                {
                    StudentId = 4,
                    FirstName = "Hazel",
                    LastName = "Abc",
                    Email = "Hazel@yahoo.com",
                    Phone = "+2567899455"
                }

                );

            modelBuilder.Entity<Courses>().HasData(
                new Courses()
                {
                    CourseId = 1,
                    CourseNumber = 101,
                    CourseName = "Java",
                    Description = "Introduction to JVM and OOPs concept"

                },
                new Courses()
                {
                    CourseId = 2,
                    CourseNumber = 102,
                    CourseName = "Digital Marketing",
                    Description = "Learn more about using online marketing to drive traffic."
                }
                );
            modelBuilder.Entity<Instructors>().HasData(
               new Instructors()
               {
                   InstructorId = 1,
                   FirstName = "Kelsy",
                   LastName = "Anderson",
                   Email = "Kelsy@yahoo.com",
                   Course = "Java"
               },
               new Instructors()
               {
                   InstructorId = 2,
                   FirstName = "Lucy",
                   LastName = "Smith",
                   Email = "Lucy@yahoo.com",
                   Course = "Java"
               }
               );

            modelBuilder.Entity<Registration>().HasData(
                new Registration()
                {
                    RegistrationId = 1,
                    Type = "Fulltime",
                    StudentId = 1,
                    CourseId = 2,
                    InstructorId = 2
                },

                new Registration()
                {
                    RegistrationId = 2,
                    Type = "Parttime",
                    StudentId = 2,
                    CourseId = 2,
                    InstructorId = 2
                },
                new Registration()
                {
                    RegistrationId = 3,
                    Type = "Fulltime",
                    StudentId = 3,
                    CourseId = 1,
                    InstructorId = 1
                },
                new Registration()
                 {
                     RegistrationId = 4,
                     Type = "Fulltime",
                     StudentId = 4,
                     CourseId = 2,
                     InstructorId = 1
                 });
            base.OnModelCreating(modelBuilder);

        }
    }
}

