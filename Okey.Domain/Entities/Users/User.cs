using Okey.Domain.Entities.Orders;
using Okey.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;

namespace Okey.Domain.Entities.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
