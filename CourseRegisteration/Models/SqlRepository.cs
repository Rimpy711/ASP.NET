using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegisteration.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CourseRegisteration.Models
{
    public class SqlRepository : IRegistration
    {
        private readonly AppDbContext context;
        public SqlRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void AddCourse(Courses course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));
            Courses newCourse = new Courses();
            newCourse.CourseId = course.CourseId;
            newCourse.CourseNumber = course.CourseNumber;
            newCourse.CourseName = course.CourseName;
            newCourse.Description = course.Description;
            context.Courses.Add(newCourse);
            context.SaveChanges();
            //return newCourse;
        }


       

        public void AddInstructor(Instructors instructor)
        {
            if (instructor == null)
                throw new ArgumentNullException(nameof(instructor));
            Instructors newInstructor = new Instructors();
            newInstructor.InstructorId = instructor.InstructorId;
            newInstructor.FirstName = instructor.FirstName;
            newInstructor.LastName= instructor.LastName;
            newInstructor.Email= instructor.Email;
            newInstructor.Course = instructor.Course;
            context.Instructors.Add(newInstructor);
            context.SaveChanges();
            

        }

        public void AddNewRegistration(Registration registration)
        {
            if (registration == null)
                throw new ArgumentNullException(nameof(registration));
            Registration newReg = new Registration();
            newReg.RegistrationId = registration.RegistrationId;
            newReg.StudentId = registration.StudentId;
            newReg.CourseId = registration.CourseId;
            newReg.InstructorId = registration.InstructorId;
            newReg.Type = registration.Type;
            context.Registration.Add(newReg);
            context.SaveChanges();
            

        }

        public void AddStudent(Students student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));
            Students newStudent = new Students();
            newStudent.StudentId = student.StudentId;
            newStudent.FirstName = student.FirstName;
            newStudent.LastName = student.LastName;
            newStudent.Phone = student.Phone;
            newStudent.Email = student.Email;
            context.Students.Add(newStudent);
            context.SaveChanges();
           

        }

        public void DeleteCourse(int Id)
        {

            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            Courses ob = context.Courses.Find(Id);
            context.Courses.Remove(ob);
            context.SaveChanges();
            
        }

        public void DeleteInstructor(int Id)
        {

            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            Instructors ob = context.Instructors.Find(Id);
            context.Instructors.Remove(ob);
            context.SaveChanges();

        }

        public void DeleteRegistration(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));
            Registration ob = context.Registration.Find(Id);
            context.Registration.Remove(ob);
            context.SaveChanges();

        }

        public void DeleteStudent(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            Students ob = context.Students.Find(Id);
            context.Students.Remove(ob);
            context.SaveChanges();

        }


        public IEnumerable<Courses> GetAllCourse()
        {
            return context.Courses.ToList();

        }

        public IEnumerable<Instructors> GetAllInstructors()
        {
            return context.Instructors.ToList();

        }

        public IEnumerable<Registration> GetAllRegistrations()
        {
            return context.Registration.ToList();
        }

        public IEnumerable<Students> GetAllStudents()
        {
            return context.Students.ToList();
        }

        public Courses GetCourse(int CourseId)
        {
            return context.Courses.Find(CourseId);

        }

        public Instructors GetInstructor(int InstructorId)
        {
            return context.Instructors.Find(InstructorId);
        }

        public Registration GetRegistration(int Id)
        {
            return context.Registration.Find(Id);
        }

        public Students GetStudent(int StudentId)
        {
            return context.Students.Find(StudentId);

        }

        public IEnumerable<Students> StudentList(int Id)
        {
            throw new NotImplementedException();
        }


        public Courses UpdateCourse(Courses courseChanges)
        {
            var updatecourse = context.Courses.Attach(courseChanges);
            updatecourse.State = EntityState.Modified;

            context.SaveChanges();
            return courseChanges;

        }

        public Instructors UpdateInstructor(Instructors instructorChanges)
        {
            var updateinstructor = context.Instructors.Attach(instructorChanges);
            updateinstructor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return instructorChanges;

        }

        public void UpdateRegistration(Registration registrationChanges)
        {
            var updateregistration = context.Registration.Attach(registrationChanges);
            updateregistration.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            //  return registrationChanges;

        }

        public Students UpdateStudent(Students studentChanges)
        {
            var updatestudent = context.Students.Attach(studentChanges);
            updatestudent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentChanges;

        }

        public IEnumerable<Students> StudentListById(int id)
        {
            
          //1,2 srtduentId 
            var result = context.Registration.Where(x => x.CourseId == id).Select(m => m.StudentId);
           
            List<Students> countlist = new List<Students>();
            
            foreach(var item in result)
            { 
                
                Students newstudent=GetStudent(item);//2
                countlist.Add(newstudent);
            }
          
            return countlist;
        }
        public IEnumerable<RegistrationViewModel> test()
        {
            List<RegistrationViewModel> RegistrationList = new List<RegistrationViewModel>();

            var result = (from reg1 in context.Registration
                         join stu in context.Students on reg1.StudentId equals stu.StudentId
                         join cr in context.Courses on reg1.CourseId equals cr.CourseId
                         join ins in context.Instructors on reg1.InstructorId equals ins.InstructorId
                         select new RegistrationViewModel
                         {
                             RegistrationId = reg1.RegistrationId,
                             Type = reg1.Type,
                             StudentName = stu.FirstName,
                             CourseName = cr.CourseName,
                             InstructorName = ins.FirstName
                         }).ToList();
                    foreach (var item in result)
                    {
                      RegistrationViewModel obj = new RegistrationViewModel(); // ViewModel
                      obj.RegistrationId = item.RegistrationId;
                      obj.Type = item.Type;
                      obj.StudentName = item.StudentName;
                      obj.CourseName = item.CourseName;
                      obj.InstructorName = item.InstructorName;
                      RegistrationList.Add(obj);

                    }

            return RegistrationList;
        }


    }
}

       