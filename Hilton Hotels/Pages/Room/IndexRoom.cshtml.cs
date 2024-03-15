using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Room
{
    public class IndexRoomModel : PageModel//this page shows all the rooms(Jakob)
    {
        private IRoomService _roomServices;// calls the interface of the room methods

        public IndexRoomModel(IRoomService service)//Constructor
        {
            _roomServices = service;
        }
        public List<RoomModel> RoomModels { get; set; }//the list of the rooms
        public void OnGet()//finds the list of the rooms using the get method
        {
            RoomModels = _roomServices.Get();
        }
        public IActionResult OnPost()// this button redirects to the create room
        {

            return RedirectToPage("CreateRoom");
        }
        public IActionResult OnPostBooking()// this button redirects to the list of the rooms
        {

            return RedirectToPage("../Booking/IndexBooking");
        }
        public IActionResult OnPostCustomer()//this button redirects to customer list
        {

            return RedirectToPage("../Customer/IndexCustomer");
        }
    }
}
