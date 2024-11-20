using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Bookings
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _context;
        public BookingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBookingAsync(Booking booking)
        {
            await _context.AddAsync(booking);
            return await SaveAsync();
        }

        public async Task<IEnumerable<Booking>> GetByUserIdAsync(string userId)
        {
            return await _context.Bookings
                .Where(u => u.User.Id == userId)
                .Include(u => u.User)
                .Include(t => t.Table)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(t => t.Table)
                .ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .Where(b => b.Id == id)
                .Include(b => b.User)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date)
        {
            return await _context.Bookings
                .Where(b => b.Date.Date == date.Date)
                .Include(b => b.User)
                .Include (t => t.Table)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByDateAndUserAsync(DateTime date, string userId)
        {
            return await _context.Bookings
                .Where(b => b.Date.Date == date.Date && b.User.Id == userId)
                .ToListAsync();
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return false;
            }

            _context.Bookings.Remove(booking);
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}