using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace ProductsApi.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal  Price { get; set; }
    }
    
}
