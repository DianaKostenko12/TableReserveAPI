using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Bookings
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _context;
        public BookingRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddBooking(Booking booking)
        {
            _context.Add(booking);
            return Save();
        }

        public IEnumerable<Booking> GetByUserId(string userId)
        {
            return _context.Bookings
                    .Where(u => u.User.Id == userId)
                    .ToList();
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetById(int id)
        {
            return _context.Bookings.Where(t => t.Id == id).FirstOrDefault();
        }

        public IEnumerable<Booking> GetBookingsByDateAndUser(DateTime date, string userId)
        {
            return _context.Bookings
                .Where(b => b.Date == date && b.User.Id == userId)
                .ToList();
        }

        public bool UpdateBooking(Booking booking)
        {
            _context.Update(booking);
            return Save();
        }

        public bool DeleteBooking(int id)
        {
            _context.Remove(id);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
