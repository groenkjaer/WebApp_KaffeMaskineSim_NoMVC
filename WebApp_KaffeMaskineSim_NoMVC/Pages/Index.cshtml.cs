using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace WebApp_KaffeMaskineSim_NoMVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Console.Write("Current Path");
            Console.WriteLine(Environment.CurrentDirectory);
        }

        public void OnPost(string button)
        {
            Console.WriteLine("OnPost Hit");
        }

        public IActionResult OnPostKaffe()
        {
            return RedirectToPage("CoffeeMaker");
        }
    }
}
