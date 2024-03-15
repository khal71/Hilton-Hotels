using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Booking
{
    public class DeleteBookingModel : PageModel //this is the delete booking page (Jakob)
    {
        public DeleteBookingModel(IBookingServices service) // delete booking constructor 
        {
            _service = service; 
        }
        private IBookingServices _service; // booking service
        [BindProperty]
        public BookingModel RemoveBooking { get; set; } // delete booking property 

        public void OnGet(int Id) // this on get we use it to find booking Id so we can delete it 
        {
            RemoveBooking = _service.Find(Id); 
        }
        public IActionResult OnPost(int Id) // thi OnPost we use so after we remove the booking it remove and can dircte us to the index booking 
        {
            _service.RemoveBooking(Id);
            return RedirectToPage("IndexBooking");
        }
    }
}
