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

        public ReservationReadDTO Map(Reservation value)
        {
            return new ReservationReadDTO
            {
                Id = value.Id,
                Name = value.Name,
                Date = value.Date,
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

        public Reservation Map(ReservationCreateDTO value)
        {
            return new Reservation
            {
                Name = value.Name,
                Date = value.Date,
            };
        }
    }
}
