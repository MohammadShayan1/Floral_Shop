using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Students.Models
{
    public class Customer
    {
        [Key]
        public int custid { get; set; }

        [Required]
        public string F_Name { get; set; }
        [Required]
        public string L_Name { get; set;}
        [Required]
        [Display(Name ="Date of birth")]
        public  DateOnly DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Personal Number")]
        public int C_Number { get; set; }
        [Required]
        public string Address { get; set; }
    }

}
