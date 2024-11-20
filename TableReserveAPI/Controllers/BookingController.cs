using AutoMapper;
using BLL.Services.Bookings;
using BLL.Services.Bookings.Descriptors;
using DAL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TableReserveAPI.Common.Extensions;
using TableReserveAPI.DTOs;

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
            var bookingsDto = _mapper.Map<List<BookingResponse>>(bookings);
            return Ok(bookingsDto);
        }

        [HttpGet("{date}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBookingsByDate(DateTime date)
        {
            var bookings = await _bookingService.GetBookingsByDateAsync(date);
            var bookingsDto = _mapper.Map<List<BookingResponse>>(bookings);
            return Ok(bookingsDto);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddBooking([FromBody] CreateBookingDescriptor descriptor)
        {
            string userId = _httpContextAccessor.HttpContext.User.GetUserId();
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
            string userId = _httpContextAccessor.HttpContext.User.GetUserId();
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
            string userId = _httpContextAccessor.HttpContext.User.GetUserId();
            try
            {
                var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
                var bookingsDto = _mapper.Map<List<BookingResponse>>(bookings);
                return Ok(bookingsDto);
            }
            catch (BusinessException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
    }
}
