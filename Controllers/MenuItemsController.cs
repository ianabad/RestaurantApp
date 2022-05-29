using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data.Interfaces;
using RestaurantApp.ModelDTO;
using RestaurantApp.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemRepo menuitemrepo;

        public MenuItemsController (IMenuItemRepo menuitemrepo)
        {
            this.menuitemrepo = menuitemrepo;
        }

        // GET: api/<MenuItemsController>
        [HttpGet]
        public IEnumerable<MenuItemReadDTO> Get()
        {
            return menuitemrepo.GetAll();
        }

        // GET api/<MenuItemsController>/5
        [HttpGet("{id}")]
        public ActionResult<MenuItemReadDTO> Get(int id)
        {
            var result = menuitemrepo.GetById(id);

            if (result != null)
            {
                return result;
            }

            return NotFound();
        }

        // POST api/<MenuItemsController>
        [HttpPost]
        public void Post([FromBody] MenuItemCreateDTO value)
        {
            menuitemrepo.Create(value);
        }

        // PUT api/<MenuItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MenuItemCreateDTO value)
        {
            menuitemrepo.Update(id, value);
        }

        // DELETE api/<MenuItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            menuitemrepo.Delete(id);
        }
    }
}
