using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspClientApp.Models;
using System.Text.Json;

namespace AspClientApp.Controllers;

public class HomeController : Controller
{
    

    public async Task<IActionResult> Index()
    {
        var products = new List<ProductDTO>();
        using (var httpClient = new HttpClient())
        {
            using( var response = await httpClient.GetAsync("http://localhost:5233/api/products/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
            }
        };
         return View(products);
    }

}
