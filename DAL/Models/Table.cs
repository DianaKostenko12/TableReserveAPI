﻿namespace DAL.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
