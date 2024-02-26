using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Students.Models.Models
{
    internal class Messages
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Ocassion Name")]
        public string Oc_Name { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
