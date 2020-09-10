using System.Collections.Generic;

namespace WebApp_KaffeMaskineSim_NoMVC.Models
{
    public class CoffeeModel
    {
        public string CoffeeName { get; set; }
        public Temperature Temperature { get; set; }
        public Season Season { get; set; }
        public bool Alcoholic { get; set; }
        public bool Sugar { get; set; }
        public bool Milk { get; set; }
        public bool Cream { get; set; }
        public bool Syrup { get; set; }
    }

    public enum Temperature
    {
        Frozen,
        Cold,
        Medium,
        Warm
    }
    public enum Season
    {
        Spring,
        Summer,
        Fall,
        Winter
    }
}
