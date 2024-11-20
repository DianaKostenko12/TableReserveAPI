namespace BLL.Services.Bookings.Descriptors
{
    public class CreateBookingDescriptor
    {
        public DateTime Date { get; set; }
        public int NumberOfGuests { get; set; }
        public int TableId { get; set; }
    }
}
