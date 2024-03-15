using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Room
{
    public class DeleteRoomModel : PageModel//Delete Page(Khaled)
    {
        public DeleteRoomModel(IRoomService service)//constructor
        {
            _service = service;
        }
        private IRoomService _service;//calls the Room services
        [BindProperty]
        public RoomModel RemoveRoom { get; set; }//Property of the room model

        public void OnGet(int id)//this method finds the room´s id
        {
            RemoveRoom = _service.Find(id);
        }
        public IActionResult OnPost(int id)// this button delete the room based on the id and redirects to the list room page
        {
            _service.Delete(id);
            return RedirectToPage("IndexRoom");
        }
    }
}
