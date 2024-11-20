namespace TableReserveAPI.DTOs
{
    public class BookingResponse
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
