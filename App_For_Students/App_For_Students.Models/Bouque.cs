
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_For_Students.Models
{
    public class Bouque
    {
        [Key]
        public int BoqId { get; set; }
        [Required]
        public string BoqName { get; set;}
        [ValidateNever]
        public string ImageURL { get; set; }
        [Required]
        public int Price { get; set; }

    }
}

namespace App_For_Students.Models
{
    class ValidateNeverAttribute : Attribute
    {
    }
}