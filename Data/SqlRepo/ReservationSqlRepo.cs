using RestaurantApp.Data.Interfaces;
using RestaurantApp.ModelDTO;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Data.SqlRepo
{
    public class ReservationSqlRepo : IReservationRepo
    {
        private readonly AppDbContext context;
        private readonly Mapper mapper = new();

        public ReservationSqlRepo(AppDbContext context)
        {
            this.context = context;
        }
        public List<ReservationReadDTO> GetAll()
        {
            var res = context.Reservations
                .Select(o => mapper.Map(o))
                .ToList();

            var rm = context.ReservationMenuItems.ToList();
            var menuitem = context.MenuItems.ToList();

            foreach (var item in res)
            {
                List<MenuItemReadDTO> menuItemsToAdd = 
                    new List<MenuItemReadDTO>();

                foreach (var reservation in rm)
                {
                    if(reservation.Id == item.Id)
                    {
                        MenuItemReadDTO mitem =
                            mapper.Map( menuitem.FirstOrDefault(m => m.Id == reservation.Id) );
                        menuItemsToAdd.Add(mitem);
                    }
                }

                item.MenuItems = menuItemsToAdd;
            }

            return res;

        }
    }
}
