using Hilton_Hotels.Models;

namespace Hilton_Hotels.Services.Interface
{
    public interface IBookingServices
    {//Interface Booking Methods(Jakob)
        public void AddBooking(BookingModel room);
        public void RemoveBooking(int id);
        public List<BookingModel> Get();
        public BookingModel Find(int id);

        public void Update(BookingModel room);
    }
}
