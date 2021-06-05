using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegisteration.Models
{
    public class Registration
    {

        [Key]
        public int RegistrationId { get; set; }

        [Required]
        public string Type { get; set; }

        [ForeignKey("StudentId")]
        public Students student { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("CourseId")]
        public Courses course { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("InstructorId")]
        public Instructors instructor { get; set; }
        public int InstructorId { get; set; }
     
    }
}
