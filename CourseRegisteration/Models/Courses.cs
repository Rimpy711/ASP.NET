using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegisteration.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public int CourseNumber { get; set; }

        public string CourseName { get; set; }
        [Required]
        public string Description { get; set; }
       

    }
}
