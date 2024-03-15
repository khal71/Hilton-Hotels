using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Room
{
    public class UpdateRoomModel : PageModel//Page to update rooms(Khaled)
    {
        public UpdateRoomModel(IRoomService services)//constructor
        {
            _service = services;
        }
        private IRoomService _service;// calls the interface of methods for room

        [BindProperty]
        public RoomModel UpdateRoom { get; set; }// Property of the room to update


        public void OnGet(int id)//this method finds the room using the id
        {
            UpdateRoom = _service.Find(id);
        }
        public IActionResult OnPost()//this method updates the info of the room based on the update method and redirects to the lists of rooms page
        {
            _service.Update(UpdateRoom);
            return RedirectToPage("IndexRoom");
        }
    }
}

