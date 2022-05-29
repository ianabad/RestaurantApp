using RestaurantApp.Data.Interfaces;
using RestaurantApp.Data;
using RestaurantApp.Models;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.ModelDTO;

namespace RestaurantApp.Data.SqlRepo
{
    public class MenuItemSqlRepo : IMenuItemRepo
    {
        private readonly AppDbContext context;
        private readonly Mapper mapper = new();
        public MenuItemSqlRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(MenuItemCreateDTO input)
        {
            context.MenuItems.Add ( mapper.Map(input) );
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var res = context.MenuItems
                .FirstOrDefault(x => x.Id == id);

            context.Remove(res);
            context.SaveChanges();
        }

        public List<MenuItemReadDTO> GetAll()
        {
            return context.MenuItems
                .Select(p => mapper.Map(p))
                .ToList();
        }

        public MenuItemReadDTO GetById(int id)
        {
            var result = context.MenuItems
                .FirstOrDefault(p => p.Id == id);

            if (result != null)
            {
                return mapper.Map(result);
            }
            return null;

        }

        public void Update(int id, MenuItemCreateDTO input)
        {
            var res = context.MenuItems
                .FirstOrDefault(p => p.Id == id);

            if (res != null)
            {
                res.Name = input.Name;
                res.Price = input.Price;

                context.SaveChanges();
            }
        }

        
    }
}
