using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okey.Domain.DTOs.ProductsDTO
{
    public class CreateProductDTO
    {

        public string? Description { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
    }
}
