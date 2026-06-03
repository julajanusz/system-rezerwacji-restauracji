namespace System_rezerwacji_stolikow.Models
{
    public class Reservation
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int PeopleCount { get; set; }
    }
}
