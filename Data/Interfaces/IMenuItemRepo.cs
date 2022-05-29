using RestaurantApp.ModelDTO;
using RestaurantApp.Models;
using System.Collections.Generic;

namespace RestaurantApp.Data.Interfaces
{
    public interface IMenuItemRepo
    {
        public List<MenuItemReadDTO> GetAll();
        public MenuItemReadDTO GetById(int id);
        public void Create(MenuItemCreateDTO input);
        public void Update(int id, MenuItemCreateDTO input);
        public void Delete(int id);

    }
}
