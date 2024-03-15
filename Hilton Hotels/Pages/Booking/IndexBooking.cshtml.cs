using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Booking
{
    public class IndexBookingModel : PageModel//this page shows the list of the bookings(Khaled)
    {
        private IBookingServices _bookingServices;// we use the booking services

        public IndexBookingModel(IBookingServices service)// constructor
        {
            _bookingServices = service;
        }
        public List<BookingModel> BookingModels { get; set; }// list of the bookings
        public void OnGet()// this method gets the list
        {
            BookingModels = _bookingServices.Get();
        }
        public IActionResult OnPost()//this button redirects to Create booking
        {
            
            return RedirectToPage("Booking");
        }
        public IActionResult OnPostRoom()// this button  redirects to room index
        {

            return RedirectToPage("../Room/IndexRoom");
        }
        public IActionResult OnPostCustomer()//This button redirets to customer index
        {

            return RedirectToPage("../Customer/IndexCustomer");
        }

    }
}
