using Workshop02.Models;

namespace Workshop02.Data
{
    public interface IFoodRepository
    {
        void Create(Food food);
        void Delete(string id);
        FoodIndexViewModel Read();
        Food? Read(string id);
        FoodIndexViewModel ReadFilter(string filter);
        void Update(Food food);
    }
}