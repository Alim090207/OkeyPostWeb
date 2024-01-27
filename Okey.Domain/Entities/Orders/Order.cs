using Okey.Domain.Entities.Products;
using Okey.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Okey.Domain.Entities.Orders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
