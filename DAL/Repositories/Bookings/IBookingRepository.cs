using DAL.Models;

namespace DAL.Repositories.Bookings
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<IEnumerable<Booking>> GetByUserIdAsync(string userId);
        Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date);
        Task<IEnumerable<Booking>> GetBookingsByDateAndUserAsync(DateTime date, string userId);
        Task<Booking> GetByIdAsync(int id);
        Task<bool> AddBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int id);
        Task<bool> SaveAsync();
    }
}
