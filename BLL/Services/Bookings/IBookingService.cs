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
        Task AddBookingAsync(CreateBookingDescriptor descriptor, int userId);
        Task DeleteBookingAsync(int bookingId, int userId);
        Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
    }
}
