using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_KaffeMaskineSim_NoMVC.Models;
using System.Text.Json;
using System.IO;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages.JSON
{
    public class CoffeeMakerModel : PageModel
    {
        [BindProperty]
        public CoffeeModel Coffee { get; set; }

        public void OnGet()
        {
        }

        public void OnPostCoffee()
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, @"JSON", Coffee.CoffeeName + ".json");
            string jsonString;
            jsonString = JsonSerializer.Serialize(Coffee);
            System.IO.File.WriteAllText(fileName, jsonString);
        }
    }
}