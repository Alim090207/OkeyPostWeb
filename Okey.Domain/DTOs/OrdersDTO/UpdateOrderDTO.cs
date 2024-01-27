using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Okey.Domain.DTOs.OrdersDTO
{
    public class UpdateOrderDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; } = string.Empty;

        public int ProductId { get; set; }
    }
}
