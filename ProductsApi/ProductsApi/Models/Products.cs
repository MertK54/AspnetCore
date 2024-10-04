using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace ProductsApi.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal  Price { get; set; }
        public bool IsActive {get;set;}
    }
    
}
