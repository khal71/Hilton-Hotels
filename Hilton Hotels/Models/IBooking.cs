namespace Hilton_Hotels.Models
{
    public interface IBooking
    {//Booking Interface(Jakob)
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string CustomerUser { get; set; }
        public int RoomId { get; set; }

    }
}
