using RestaurantApp.Models;
using System.Collections.Generic;

namespace RestaurantApp.Data.Interfaces
{
    public interface IMenuItemRepo
    {
        public List<MenuItem> GetAll();

    }
}
