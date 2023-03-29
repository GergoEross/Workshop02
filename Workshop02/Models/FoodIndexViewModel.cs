namespace Workshop02.Models
{
    public class FoodIndexViewModel
    {
        public FoodIndexViewModel()
        {
            Selected = "all";
        }
        public IEnumerable<Food> Foods { get; set; }
        public List<string> Categories { get; set; }
        public string Selected { get; set; }
    }
}
