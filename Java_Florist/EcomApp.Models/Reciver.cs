using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomApp.Models
{
    public class Reciver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public int Ph_Nu { get; set; }

        [Required]
        [Display(Name = "Ocassion Name")]
        public string Oc_Name { get; set; }
        [Required]
        public string Message { get; set; }
    }
}

