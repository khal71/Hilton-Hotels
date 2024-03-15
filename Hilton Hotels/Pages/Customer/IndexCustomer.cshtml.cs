using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;

namespace Hilton_Hotels.Pages.Customer
{
    public class IndexCustomerModel : PageModel // this page is for the Index Customer (Jakob)
    {
        private ICustomerService _customerServices; // this is a property to get the properties of the customer from the Icustomer Service 

        public IndexCustomerModel(ICustomerService service)  // this is the constructor of the Index fo the customer 
        {
            _customerServices = service;
        }
        public List<CustomerModel> CustomerModels { get; set; } // this is a property that shows the list of the customers
        public void OnGet() // this button is to show the list of the customers 
        {
            CustomerModels = _customerServices.Get();
        }
        public IActionResult OnPost() // this button is to register 
        {
            return RedirectToPage("Register/Register");
        }
        public IActionResult OnPostBooking() // this is a button that redirect us to the index of booking 
        {
            return RedirectToPage("../Booking/IndexBooking");
        }
        public IActionResult OnPostRoom() // this button to redirect us to the Index of room 
        {
            return RedirectToPage("../Room/IndexRoom");
        }

    }
}
