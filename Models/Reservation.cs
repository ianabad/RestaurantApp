using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
