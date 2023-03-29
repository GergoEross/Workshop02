

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Workshop02.Helpers;

namespace Workshop02.Models
{
    [ModelBinder(BinderType = typeof(FoodModelBinder))]
    public class Food
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        [ShowTable]
        public string Name { get; set; }
        [Required]
        [Range(10, 2000)]
        [ShowTable]
        public int Calories { get; set; }
        [Required]
        [ShowTable]
        public string Category { get; set; }
        [Required]
        [Range(100, int.MaxValue)]
        [ShowTable]
        public int Price { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Data { get; set; }
        public Food()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
