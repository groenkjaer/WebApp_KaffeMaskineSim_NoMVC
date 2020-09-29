using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using WebApp_KaffeMaskineSim_NoMVC.Models;

namespace WebApp_KaffeMaskineSim_NoMVC.Controllers
{
    public class HomeController : Controller
    {
        private const string Sanitized = "Sanitized";

        public IActionResult Index()
        {
            var model = GetCoffeeFiles();
            return View(model);
        }

        [Route("Coffee/{id?}")]
        public IActionResult Coffee(string id)
        {
            if (HttpContext.Session.GetInt32(Sanitized) == null)
            {
                return View("Error");
            }
            return View(GetCoffee(id));
        }
        [Route("Sprit")]
        public IActionResult Sprit()
        {
            HttpContext.Session.SetInt32(Sanitized, 1);
            return View("Index", GetCoffeeFiles());
        }

        [HttpPost]
        public IActionResult CoffeeServed(CoffeeModel coffee)
        {
            return View(coffee);
        }

        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("Create")]
        public IActionResult Create(CoffeeModel model)
        {
            CreateFile(model);
            return View("Index", GetCoffeeFiles());
        }

        #region Methods
        private void CreateFile(CoffeeModel coffee)
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, @"JSON", coffee.CoffeeName + ".json");
            string jsonString;
            jsonString = JsonSerializer.Serialize(coffee);
            System.IO.File.WriteAllText(fileName, jsonString);
        }
        private CoffeeModel GetCoffee(string coffee)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "JSON", coffee + ".json");
            CoffeeModel result = JsonSerializer.Deserialize<CoffeeModel>(System.IO.File.ReadAllText(path));

            return result;
        }

        private List<CoffeeModel> GetCoffeeFiles()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "JSON");
            string[] files = Directory.GetFiles(path);
            List<CoffeeModel> Coffees = new List<CoffeeModel>();

            foreach (var file in files)
            {
                CoffeeModel coffeeJson = JsonSerializer.Deserialize<CoffeeModel>(System.IO.File.ReadAllText(file));
                Coffees.Add(coffeeJson);
            }
            return Coffees;
        }
        #endregion
    }
}
