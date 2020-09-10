using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_KaffeMaskineSim_NoMVC.Models;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages.JSON
{
    public class CoffeeMakerModel : PageModel
    {
        [BindProperty]
        public CoffeeModel Coffee { get; set; }

        public void OnGet()
        {

        }
    }
}