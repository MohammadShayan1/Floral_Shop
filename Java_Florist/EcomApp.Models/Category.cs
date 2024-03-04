
using System.ComponentModel.DataAnnotations;

namespace EcomApp.Models
{
    public class Category
    {
        [Key]
        public int C_Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string C_Name { get; set; }

        [Required]
        [Display(Name = "Display Order")]
        public int Display_Order { get; set; }

        public DateTime CategoryAdded { get; set; } = DateTime.Now;

    }
}
