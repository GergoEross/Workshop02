using Microsoft.AspNetCore.Mvc.ModelBinding;
using Workshop02.Models;

namespace Workshop02.Helpers
{
    public class FoodModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));

            Food food = new Food();
            food.Name = bindingContext.ValueProvider.GetValue("name").FirstValue;
            food.Calories = int.Parse(bindingContext.ValueProvider.GetValue("calories").FirstValue);
            food.Category = bindingContext.ValueProvider.GetValue("category").FirstValue;
            food.Price = int.Parse(bindingContext.ValueProvider.GetValue("price").FirstValue);

            if(bindingContext.HttpContext.Request.Form.Files.Count > 0)
            {
                var file = bindingContext.HttpContext.Request.Form.Files[0];
                using(var stream = file.OpenReadStream())
                {
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    food.Data = data;
                    food.ContentType= file.ContentType;
                }
            }

            bindingContext.Result = ModelBindingResult.Success(food);
            return Task.CompletedTask;
        }
    }
}
