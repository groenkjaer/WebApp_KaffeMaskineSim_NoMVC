using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_KaffeMaskineSim_NoMVC.Helpers;
using WebApp_KaffeMaskineSim_NoMVC.Models;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages
{
    public class CoffeeDeliveryModel : PageModel
    {
        public CoffeeModel Coffee { get; set; }
        public IActionResult OnGet()
        {
            if (!TempData.ContainsKey("Coffee"))
                return RedirectToPage("Index");
            Coffee = TempData.Get<CoffeeModel>("Coffee");
            return Page();
        }
    }
}