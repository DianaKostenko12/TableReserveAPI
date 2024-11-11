using BLL.Services.Bookings.Descriptors;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Bookings
{
    public interface IBookingService
    {
        Task AddBookingAsync(CreateBookingDescriptor descriptor);
        Task DeleteBookingAsync(int bookingId);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId);
        Task UpdateBookingAsync(Booking newBooking);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
    }
}
