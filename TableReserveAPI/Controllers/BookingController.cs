using AutoMapper;
using BLL.Services.Bookings;
using BLL.Services.Bookings.Descriptors;
using DAL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TableReserveAPI.Common.Extensions;

namespace TableReserveAPI.Controllers
{
    [ApiController, Route("booking")]
    public class BookingController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _bookingService = bookingService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{date}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBookingsByDate(DateTime date)
        {
            var bookings = await _bookingService.GetBookingsByDateAsync(date);
            return Ok(bookings);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddBooking([FromBody] CreateBookingDescriptor descriptor)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetUserId();
            try
            {
                await _bookingService.AddBookingAsync(descriptor, userId);
                return Ok("Booking added successfully.");
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            int userId = _httpContextAccessor.HttpContext.User.GetUserId();
            try
            {
                await _bookingService.DeleteBookingAsync(bookingId, userId);
                return Ok("Booking deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }

        [HttpGet("byUserId"), Authorize]
        public async Task<IActionResult> GetBookingsByUserIdAsync()
        {
            int userId = _httpContextAccessor.HttpContext.User.GetUserId();
            try
            {
                var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
                return Ok(bookings);
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
    }
}
