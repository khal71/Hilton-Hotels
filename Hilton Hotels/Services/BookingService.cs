using Hilton_Hotels.Models;
using Hilton_Hotels.Pages.Customer;
using Hilton_Hotels.Services.Interface;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Hilton_Hotels.Services
{
    public class BookingService : IBookingServices
    {//Booking services(Jakob


        private const string fileDir = "../Hilton Hotels/wwwroot/Jsonfiles/";
        private const string fileName = fileDir + "BookingJson.json";

        List<BookingModel> _bookingModel = new List<BookingModel>();

        public BookingService()
        {
            _bookingModel = ReadFromJson();
        }
        //we use to overlap methop and is it doesnt ovrlap it add the booking and saves the file to json
        public void AddBooking(BookingModel book)
        {
            var result=IsOverlapping(book);
            if (result == false)
            {
                _bookingModel.Add(book);
                SaveToJson();
            }
            else 
            {
                throw new Exception("is overlapping");
            }
        }
        //this check and reads the json files
        public List<BookingModel> ReadFromJson()
        {
            using (var file = File.OpenText(fileName))
            {

                String json = file.ReadToEnd();
             return JsonSerializer.Deserialize<List<BookingModel>>(json);
            }
            return new List<BookingModel>();
        }
        // this method finds a booking with id
        public BookingModel Find(int id)
        {
            BookingModel b = _bookingModel.Find(b => b.ID == id);
            if (b is not null)
            {
                return b;
            }
            throw new KeyNotFoundException();
        }

       
        //this method remove a booking and saves the change in json files
        public void RemoveBooking(int id)
        {
            BookingModel booking = Find(id);
            _bookingModel.Remove(booking);
            SaveToJson();
        }
        //the update uses the method find to find the booking check if it is overlapping and then makes the changes and saves it to json
        public void Update(BookingModel book)
        {
            BookingModel booking = Find(book.ID);
            var result = IsOverlapping(book);
            if (result == false)
            {
                booking.CheckIn = book.CheckIn;
                booking.CheckOut = book.CheckOut;
                booking.RooomeId = book.RooomeId;
                booking.CustomerUser = book.CustomerUser;

                SaveToJson();
            }
            else
            {
                throw new Exception("Overlap");
            }
        }
        //this method saves information to json files
        private void SaveToJson()
        {
            String json = JsonSerializer.Serialize(_bookingModel);
            File.WriteAllText(fileName, json);
        }
        //this method shows the list of the bookings
        public List<BookingModel> Get()
        {
            return new List<BookingModel>(_bookingModel);
        }
        // this methods gets the list of booking and checks if it overlaps with the new information.
        public bool IsOverlapping(BookingModel booking)
        {
            return Get()
                .Any(a => a.ID != booking.ID && a.CheckIn <= booking.CheckOut && booking.CheckIn <= a.CheckOut && a.RooomeId == booking.RooomeId);
        }

    }
}
