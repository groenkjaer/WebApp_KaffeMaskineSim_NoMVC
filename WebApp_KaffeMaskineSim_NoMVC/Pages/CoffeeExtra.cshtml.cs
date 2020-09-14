using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_KaffeMaskineSim_NoMVC.Helpers;
using WebApp_KaffeMaskineSim_NoMVC.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

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

        public IActionResult OnPostPay(string id)
        {
            TempData.Set<CoffeeModel>("Coffee", Coffee);
            return RedirectToPage("CoffeeDelivery");
        }

        private Task<CoffeeModel> GetStuff()
        {
            return null;
        }
    }
}