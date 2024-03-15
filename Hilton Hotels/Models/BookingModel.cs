using Hilton_Hotels.Services;
using Hilton_Hotels.Services.Interface;

namespace Hilton_Hotels.Models
{
    public class BookingModel//Booking model with constructors(Jakob)
    {
        public int ID { get; set; }
        public int RooomeId{ get; set; }
        public string CustomerUser { get; set; }
        public DateTime CheckIn { get; set; }   
        public DateTime CheckOut { get; set; }

        private readonly IBookingServices BookingService;
        public BookingModel() 
        {
        }

        public BookingModel(int ID, DateTime CheckIn, DateTime CheckOut, string CustomerUser, int RooomeId)
        {
            if (ID == default) throw new ArgumentOutOfRangeException(nameof(ID), "Booking Id is required");
            if (CheckIn == default) throw new ArgumentOutOfRangeException(nameof(CheckIn), "CheckIn date is required");
            if (CheckOut == default) throw new ArgumentOutOfRangeException(nameof(CheckOut), "CheckOut date is required");
            if (RooomeId == default) throw new ArgumentOutOfRangeException(nameof(RooomeId), "Room id is required");
            if (CustomerUser == default) throw new ArgumentOutOfRangeException(nameof(CustomerUser), "CustomerUserName  is required");
            if (CheckIn >= CheckOut) throw new Exception($"CheckOut has to come later than check in (CheckIn, CheckOut): {CheckIn}, {CheckOut}");
            this.ID = ID;
            this.CheckIn = CheckIn;
            this.CheckOut = CheckOut;
            this.CustomerUser = CustomerUser;
            this.RooomeId = RooomeId;

            
        }
        public BookingModel(int _bookingId, DateTime _checkIn, DateTime _checkOut, string _customerUsername, int _roomId, IBookingServices _services)
        {
            if (_bookingId == default) throw new ArgumentOutOfRangeException(nameof(_bookingId), "Booking Id is required");
            if (_checkIn == default) throw new ArgumentOutOfRangeException(nameof(_checkIn), "CheckIn date is required");
            if (_checkOut == default) throw new ArgumentOutOfRangeException(nameof(_checkOut), "CheckOut date is required");
            if (_roomId == default) throw new ArgumentOutOfRangeException(nameof(_roomId), "Room id is required");
            if (_customerUsername == default) throw new ArgumentOutOfRangeException(nameof(_customerUsername), "CustomerUserName  is required");
            if (_checkIn >= _checkOut) throw new Exception($"CheckOut has to come later than check in (CheckIn, CheckOut): {_checkIn}, {_checkOut}");
            ID = _bookingId; 
            CheckIn = _checkIn;
            CheckOut = _checkOut;
            CustomerUser = _customerUsername;
            RooomeId = _roomId;
            BookingService = _services;
        }
      


      







    }
}
