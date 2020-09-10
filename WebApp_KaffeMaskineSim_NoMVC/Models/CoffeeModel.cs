using System.Collections.Generic;

namespace WebApp_KaffeMaskineSim_NoMVC.Models
{
    public class CoffeeModel
    {
        public string CoffeeName { get; set; }
        public Temperature Temperature { get; set; }
        public Season Season { get; set; }
        public bool Alchoholic { get; set; }
        public List<string> Extra { get; set; }
    }

    public enum Temperature
    {
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
