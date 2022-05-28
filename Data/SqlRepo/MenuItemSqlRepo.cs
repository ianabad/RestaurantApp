using RestaurantApp.Data.Interfaces;
using RestaurantApp.Data;
using RestaurantApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Data.SqlRepo
{
    public class MenuItemSqlRepo : IMenuItemRepo
    {
        private readonly AppDbContext context;
        public MenuItemSqlRepo(AppDbContext context)
        {
            this.context = context;
        }
        public List<MenuItem> GetAll()
        {
            return context.MenuItems.ToList();
        }
    }
}
