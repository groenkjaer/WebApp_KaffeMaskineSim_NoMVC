using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using WebApp_KaffeMaskineSim_NoMVC.Models;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private string path = Path.Combine(Environment.CurrentDirectory, "JSON");
        public List<CoffeeModel> Coffees { get; set; } = new List<CoffeeModel>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string[] files = Directory.GetFiles(path);

            foreach (var file  in files)
            {
                CoffeeModel coffeeJson = JsonSerializer.Deserialize<CoffeeModel>(System.IO.File.ReadAllText(file));
                Coffees.Add(coffeeJson);
            }
        }

        public void OnPost()
        {
            Console.WriteLine("OnPost Hit");
        }

        public IActionResult OnPostKaffe()
        {
            return RedirectToPage("CoffeeMaker");
        }

        public void OnPostId(string Id)
        {
            Console.WriteLine(Id);
        }
    }
}
