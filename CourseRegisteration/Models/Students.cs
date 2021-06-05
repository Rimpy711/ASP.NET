 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegisteration.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Student Name cannot be greater than 50 characters")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone{ get; set; }


    }
}
