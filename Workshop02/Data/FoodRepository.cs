using Workshop02.Models;

namespace Workshop02.Data
{
    public class FoodRepository : IFoodRepository
    {
        FoodDbContext context;

        public FoodRepository(FoodDbContext context)
        {
            this.context = context;
        }

        public void Create(Food food)
        {
            var foodSameName = context.Foods.FirstOrDefault(f => f.Name == food.Name);
            if (foodSameName != null)
            {
                throw new ArgumentException("Food with same name already exist!");
            }
            context.Foods.Add(food);
            context.SaveChanges();
        }
        public FoodIndexViewModel Read()
        {
            var res = new FoodIndexViewModel();
            res.Foods = context.Foods;
            res.Categories = context.Foods.Select(t => t.Category).Distinct().ToList();
            res.Categories.Add("all");

            return res;
        }
        public Food? Read(string id)
        {
            return context.Foods.FirstOrDefault(t => t.Id == id);
        }
        public Food? ReadFromName(string name)
        {
            return context.Foods.FirstOrDefault(t => t.Name == name);
        }
        public FoodIndexViewModel ReadFilter(string filter)
        {
            var res = new FoodIndexViewModel();
            res.Foods = context.Foods.Where(t => t.Category == filter);
            res.Categories = context.Foods.Select(t => t.Category).Distinct().ToList();
            res.Categories.Add("all");

            return res;
        }
        public void Update(Food food)
        {
            var old = ReadFromName(food.Name);
            old.Price = food.Price;
            old.Calories = food.Calories;
            old.Category = food.Category;
            context.SaveChanges();
        }
        public void Delete(string id)
        {
            var food = Read(id);
            context.Foods.Remove(food);
            context.SaveChanges();
        }
    }
}
