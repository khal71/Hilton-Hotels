using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;

namespace Hilton_Hotels.Pages.Booking
{
    public class UpdateBookingModel : PageModel//Page for the update booking(Jakob)
    {
        public UpdateBookingModel(IBookingServices services)//constructor
        {
            _service = services;
        }
        private IBookingServices _service;//we use rthe booking services metod

        [BindProperty]
        public BookingModel UpdateBooking { get; set; }//property with the booking model


        public void OnGet(int Id)// this method finds the booking with the id
        {
            UpdateBooking = _service.Find(Id);
        }
        public IActionResult OnPost()// this method redirects us to the booking index
        {
            _service.Update(UpdateBooking);
            return RedirectToPage("IndexBooking");
        }
    }

}