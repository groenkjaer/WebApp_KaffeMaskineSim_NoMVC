using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using WebApp_KaffeMaskineSim_NoMVC.Models;
using WebApp_KaffeMaskineSim_NoMVC.Helpers;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private string path = Path.Combine(Environment.CurrentDirectory, "JSON");
        public List<CoffeeModel> Coffees { get; set; } = new List<CoffeeModel>();
        public bool CleanHands { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            GetCoffeeFiles();
            _logger = logger;

            CleanHands = false; //TESTING
        }

        public void OnGet()
        {
        }

        private void GetCoffeeFiles()
        {
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
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

        public void OnGetUnsanitized()
        {
            Console.WriteLine("pleeease");
        }

        public IActionResult OnPostId(string id)
        {
            if (CleanHands)
            {
                TempData["jsonString"] = id;
                return RedirectToPage("CoffeeExtra");
            }
            else
            {
                return RedirectToPage("Index", "Unsanitized");
            }
            
        }


        //public bool Sanitized()
        //{
        //    bool clean;

        //    try
        //    {
        //        clean = (bool)TempData["Sanitised"];
        //    }
        //    catch
        //    {
        //        clean = false;
        //    }
            
        //    return clean;
        //}
    }
}
