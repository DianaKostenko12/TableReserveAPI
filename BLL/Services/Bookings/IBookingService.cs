using BLL.Services.Bookings.Descriptors;
using DAL.Models;

namespace BLL.Services.Bookings
{
    public interface IBookingService
    {
        Task AddBookingAsync(CreateBookingDescriptor descriptor, string userId);
        Task DeleteBookingAsync(int bookingId, string userId);
        Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId);
    }
}
