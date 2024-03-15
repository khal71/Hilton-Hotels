using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Hilton_Hotels.Pages.Room
{
    public class CreateRoomModel : PageModel//This page is to create the room(Jakob)
    {
        private readonly IRoomService _create;//this reads the interface of the room

        public CreateRoomModel(IRoomService create)//contructor
        {
            _create = create;
        }
        [BindProperty]
        public CreateRoom Create { get; set; }// the create room property

        public void OnGet()
        {
        }

        public void OnPost()// this method adds a new room and the information
        {
            RoomModel newRoom = new RoomModel
                (Create.ID,
               Create.Type,
                Create.Price);

            _create.Add(newRoom);
        }


    }
    public class CreateRoom//All the properties of the create room
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Price { get; set; }

      

    }
}

