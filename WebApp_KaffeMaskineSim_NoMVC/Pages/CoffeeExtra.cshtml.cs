using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_KaffeMaskineSim_NoMVC.Helpers;
using WebApp_KaffeMaskineSim_NoMVC.Models;
using System;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages
{
    public class CoffeeExtraModel : PageModel
    {
        public void OnGet()
        {
            var Coffee = TempData.Get<CoffeeModel>("PassedCoffee");

            Console.WriteLine(Coffee.CoffeeName);
        }
    }
}