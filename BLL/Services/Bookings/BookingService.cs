using BLL.Services.Bookings.Descriptors;
using DAL.Models;
using DAL.Repositories.Bookings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Bookings
{
    //public class BookingService : IBookingService
    //{
    //    private readonly IBookingRepository _bookingRepository;
    //    private readonly UserManager<User> _userManager;

    //    public BookingService(IBookingRepository bookingRepository, UserManager<User> userManager)
    //    {
    //        _bookingRepository = bookingRepository;
    //        _userManager = userManager;
    //    }

    //    public async Task AddBookingAsync(CreateBookingDescriptor descriptor)
    //    {
    //        Table table = _tableRepository.GetById(descriptor.TableId);
    //        if (table == null)
    //        {
    //            throw new KeyNotFoundException($"Table with ID {descriptor.TableId} was not found.");
    //        }

    //        User user = await _userManager.FindByEmailAsync(descriptor.Email);

    //        var existingBookings = _bookingRepository.GetBookingsByDateAndUser(descriptor.Date, user.Id);
    //        if (existingBookings.Count() >= 2)
    //        {
    //            throw new InvalidOperationException("The user has already booked more than two tables on this date.");
    //        }

    //        var booking = new Booking()
    //        {
    //            Date = descriptor.Date,
    //            NumberOfGuests = descriptor.NumberOfGuests,
    //            Table = table,
    //            User = user,
    //        };

    //        _bookingRepository.AddBooking(booking);
    //        _bookingRepository.Save();
    //    }

    //    public async Task DeleteBookingAsync(int bookingId)
    //    {
    //        Booking booking = _bookingRepository.GetById(bookingId);
    //        if (booking == null)
    //        {
    //            throw new KeyNotFoundException($"Table with ID {bookingId} was not found.");
    //        }

    //        _bookingRepository.DeleteBooking(bookingId);
    //        _bookingRepository.Save();
    //    }

    //    public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
    //    {
    //       return _bookingRepository.GetBookings();
    //    }

    //    public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId)
    //    {
    //        return _bookingRepository.GetByUserId(userId);
    //    }
    //}
}
