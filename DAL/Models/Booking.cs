using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public int NumberOfGuests { get; set; }
        public User User { get; set; }
        public Table Table { get; set; }
    }
}
