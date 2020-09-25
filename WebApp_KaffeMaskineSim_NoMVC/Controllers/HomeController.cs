﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_KaffeMaskineSim_NoMVC.Models;

namespace WebApp_KaffeMaskineSim_NoMVC.Controllers
{
    public class HomeController : Controller
    {
        public object Coffees { get; private set; }

        public IActionResult Index()
        {
            var model = GetCoffeeFiles();

            return View(model);
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
    }
}
