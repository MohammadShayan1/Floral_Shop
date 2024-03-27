using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Occasion { get; set; }
        public string Message { get; set; }
        public string CreditCardNumber { get; set; }
        public decimal TotalPrice { get; set; }

        // This property represents the flower product associated with the order
        public Product Flower { get; set; }
    }
}
