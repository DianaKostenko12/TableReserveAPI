using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Bookings
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBookings();
        IEnumerable<Booking> GetByUserId(string userId);
        IEnumerable<Booking> GetBookingsByDateAndUser(DateTime date, string userId);
        Booking GetById(int id);
        bool AddBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int id);
        bool Save();
    }
}
