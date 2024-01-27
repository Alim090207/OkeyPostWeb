using Okey.Domain.Entities.Orders;
using Okey.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Okey.Domain.Entities.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; }
    }
}
