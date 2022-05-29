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

        public void Create(ReservationCreateDTO input)
        {
            context.Reservations.Add(mapper.Map(input));
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var res = context.Reservations
                .FirstOrDefault(x => x.Id == id);

            context.Remove(res);
            context.SaveChanges();
        }

        public List<ReservationReadDTO> GetAll()
        {
            var res = context.Reservations
                .Select(o => mapper.Map(o))
                .ToList();

            var rm = context.ReservationMenuItems
                .ToList();
            var menuitem = context.MenuItems
                .Select(m => mapper.Map(m))
                .ToList();

            // include the many to many relationship to API

            foreach (var item in res)
            {

                var mitemstoAdd = (from rs in res
                                  join resmenu in rm on rs.Id equals resmenu.ReservationId
                                  join mitem in menuitem on resmenu.MenuItemId equals mitem.Id
                                  where item.Id == rs.Id
                                  select mitem).ToList();

                item.MenuItems = mitemstoAdd;
            }

            return res;

        }

        public ReservationReadDTO GetById(int id)
        {
            var result = mapper.Map(context.Reservations
                .FirstOrDefault(p => p.Id == id));

            var rm = context.ReservationMenuItems
                .ToList();

            var menuitem = context.MenuItems
                .Select(m => mapper.Map(m))
                .ToList();

            // include the many to many relationship to API

            var mitemtoAdd = (from rs in rm
                             join mi in menuitem on rs.MenuItemId equals mi.Id
                             where rs.ReservationId == id
                             select mi).ToList();

            if (result != null)
            {
                result.MenuItems = mitemtoAdd;
                return result;
            }
            return null;
        }

        public void Update(int id, ReservationCreateDTO input)
        {
            var res = context.Reservations
                .FirstOrDefault(p => p.Id == id);

            if (res != null)
            {
                res.Name = input.Name;
                res.Date = input.Date;

                context.SaveChanges();
            }
        }
    }
}
