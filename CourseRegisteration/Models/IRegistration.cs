using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegisteration.ViewModel;

namespace CourseRegisteration.Models
{
    public interface IRegistration
    {

        IEnumerable<Students> GetAllStudents();
        Students GetStudent(int StudentId);
        void AddStudent(Students student);
        void DeleteStudent(int Id);
        Students  UpdateStudent(Students studentChange);



        IEnumerable<Courses> GetAllCourse();
        Courses GetCourse(int CourseId);
     
        void AddCourse(Courses course);
        void DeleteCourse(int Id);
        Courses UpdateCourse(Courses courseChanges);
        IEnumerable<Students> StudentListById(int id);


        //Instructor
        IEnumerable<Instructors> GetAllInstructors();
        Instructors GetInstructor(int InstructorId);
        void AddInstructor(Instructors instructor);
        void DeleteInstructor(int Id);
        Instructors UpdateInstructor(Instructors instructorChanges);


        //Registration

        void AddNewRegistration(Registration registration);
        void DeleteRegistration(int Id);
        void  UpdateRegistration(Registration registrationChanges);

        IEnumerable<Registration> GetAllRegistrations();
        Registration GetRegistration(int Id);
        IEnumerable<RegistrationViewModel> test();
       
    }
}

