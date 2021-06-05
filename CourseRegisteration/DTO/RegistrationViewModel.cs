using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegisteration.ViewModel
{
    public class RegistrationViewModel
    {
       
        public int RegistrationId { get; set; }

        [Required]
        public string Type { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }



    }
}
