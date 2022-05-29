using System;
using System.Collections.Generic;

namespace RestaurantApp.ModelDTO
{
    public class ReservationReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<MenuItemReadDTO> MenuItems { get; set; }
    }
}
