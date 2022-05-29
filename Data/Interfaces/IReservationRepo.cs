using RestaurantApp.ModelDTO;
using System.Collections.Generic;

namespace RestaurantApp.Data.Interfaces
{
    public interface IReservationRepo
    {
        public List<ReservationReadDTO> GetAll();
        public ReservationReadDTO GetById(int id);
        public void Create(ReservationCreateDTO input);
        public void Update(int id, ReservationCreateDTO input);
        public void Delete(int id);
    }
}
