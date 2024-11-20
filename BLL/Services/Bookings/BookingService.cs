using BLL.Services.Bookings.Descriptors;
using DAL.Exceptions;
using DAL.Models;
using DAL.Repositories.Bookings;
using DAL.Repositories.Tables;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace BLL.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ITableRepository _tableRepository;
        private readonly UserManager<User> _userManager;

        public BookingService(IBookingRepository bookingRepository, ITableRepository tableRepository, UserManager<User> userManager)
        {
            _bookingRepository = bookingRepository;
            _tableRepository = tableRepository;
            _userManager = userManager;
        }

        public async Task AddBookingAsync(CreateBookingDescriptor descriptor, string userId)
        {
            if (descriptor == null)
            {
                throw new BusinessException(HttpStatusCode.BadRequest, "Descriptor cannot be null.");
            }

            if (descriptor.Date.Date < DateTime.UtcNow.Date)
            {
                throw new BusinessException(HttpStatusCode.BadRequest, "Cannot create a booking for a past date.");
            }

            var table = await _tableRepository.GetByIdAsync(descriptor.TableId);
            if (table == null)
            {
                throw new BusinessException(HttpStatusCode.NotFound, $"Table with ID {descriptor.TableId} was not found.");
            }

            User user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new BusinessException(HttpStatusCode.NotFound, $"User with ID {userId} was not found.");
            }

            var existingBookings = await _bookingRepository.GetBookingsByDateAndUserAsync(descriptor.Date, user.Id);
            if (existingBookings.Count() >= 2)
            {
                throw new BusinessException(HttpStatusCode.BadRequest, "The user has already booked more than two tables on this date.");
            }

            var booking = new Booking()
            {
                Date = descriptor.Date,
                NumberOfGuests = descriptor.NumberOfGuests,
                Table = table,
                User = user,
            };

           await _bookingRepository.AddBookingAsync(booking);
           await _bookingRepository.SaveAsync();
        }

        public async Task DeleteBookingAsync(int bookingId, string userId)
        {
            Booking booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null)
            {
                throw new BusinessException(HttpStatusCode.NotFound, $"Booking with ID {bookingId} was not found."); 
            }

            var recordAuthor = await _userManager.FindByIdAsync(booking.User.Id);
            IList<string> recordAuthorRoles = await _userManager.GetRolesAsync(recordAuthor);

            User editor = await _userManager.FindByIdAsync(userId);
            IList<string> editorRoles = await _userManager.GetRolesAsync(editor);

            if (recordAuthorRoles.Contains(Roles.Admin) && !editorRoles.Contains(Roles.Admin))
            {
                throw new BusinessException(HttpStatusCode.Forbidden, "You do not have permission to delete this booking.");
            }

            if (!recordAuthorRoles.Contains(Roles.Admin) && !editorRoles.Contains(Roles.Admin) && recordAuthor.Id != editor.Id)
            {
                throw new BusinessException(HttpStatusCode.Forbidden, "You do not have permission to delete this booking.");
            }

            await _bookingRepository.DeleteBookingAsync(bookingId);
            await _bookingRepository.SaveAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetBookingsAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date)
        {
            var bookings = await _bookingRepository.GetBookingsByDateAsync(date);
            if (!bookings.Any())
            {
                throw new BusinessException(HttpStatusCode.NotFound, $"No bookings found for the date {date.ToShortDateString()}.");
            }
            return bookings;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId)
        {
            var bookings = await _bookingRepository.GetByUserIdAsync(userId);
            if (!bookings.Any())
            {
                throw new BusinessException(HttpStatusCode.NotFound, $"No bookings found for user with ID {userId}.");
            }
            return bookings;
        }
    }
}
