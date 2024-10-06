using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
