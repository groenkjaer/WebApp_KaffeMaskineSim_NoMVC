using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_KaffeMaskineSim_NoMVC.Helpers;
using WebApp_KaffeMaskineSim_NoMVC.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages
{
    public class CoffeeExtraModel : PageModel
    {
        [BindProperty]
        public CoffeeModel Coffee { get; set; }

        public IActionResult OnGet()
        {
            Coffee = TempData.Get<CoffeeModel>("jsonString");
            if (Coffee != null)
                return new PageResult();
            else
                return RedirectToPage("Index");
        }

        public void OnPostPay(string id)
        {
            var secondCoffee = JsonSerializer.Deserialize<CoffeeModel>(id);
            Coffee.CoffeeName = secondCoffee.CoffeeName;
            Coffee.Alcoholic = secondCoffee.Alcoholic;
            Coffee.Season = secondCoffee.Season;
        }
    }
}