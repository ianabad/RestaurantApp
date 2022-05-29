using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data.Interfaces;
using RestaurantApp.ModelDTO;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo repo;

        public ReservationsController (IReservationRepo repo)
        {
            this.repo = repo;
        }

        // GET: api/<ReservationsController>
        [HttpGet]
        public IEnumerable<ReservationReadDTO> Get()
        {
            return repo.GetAll();
        }

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public ActionResult<ReservationReadDTO> Get(int id)
        {
            var result = repo.GetById(id);

            if (result != null)
            {
                return result;
            }
            return NotFound();
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public void Post([FromBody] ReservationCreateDTO value)
        {
            repo.Create(value);
        }

        // PUT api/<ReservationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ReservationCreateDTO value)
        {
            repo.Update(id, value);
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
