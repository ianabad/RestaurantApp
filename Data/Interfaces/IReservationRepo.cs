using RestaurantApp.ModelDTO;
using System.Collections.Generic;

namespace RestaurantApp.Data.Interfaces
{
    public interface IReservationRepo
    {
        public List<ReservationReadDTO> GetAll();
    }
}
