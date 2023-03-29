using Microsoft.EntityFrameworkCore;
using Workshop02.Models;

namespace Workshop02.Data
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public FoodDbContext(DbContextOptions<FoodDbContext> opt) : base(opt)
        {

        }
    }
}
