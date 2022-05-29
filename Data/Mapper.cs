using RestaurantApp.ModelDTO;
using RestaurantApp.Models;

namespace RestaurantApp.Data
{
    public class Mapper
    {
        public MenuItemReadDTO Map(MenuItem value)
        {
            return new MenuItemReadDTO
            {
                Id = value.Id,
                Name = value.Name,
                Price = value.Price,
            };
        }

        public MenuItem Map(MenuItemCreateDTO value) 
        {
            return new MenuItem
            {
                Name = value.Name,
                Price = value.Price
            };
        }
    }
}
