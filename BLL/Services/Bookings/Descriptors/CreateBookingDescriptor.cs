using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Bookings.Descriptors
{
    public class CreateBookingDescriptor
    {
        public DateTime Date { get; set; }
        public int NumberOfGuests { get; set; }
        public int TableId { get; set; }
        public string Email { get; set; }
    }
}
