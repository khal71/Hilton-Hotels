using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Customer
{
    public class DeleteCustomerModel : PageModel // this page is to delete Customer (Khaled)
    {
        public DeleteCustomerModel(ICustomerService service) // this is the constructor for delete customer 
        {
            _service = service;
        }
        private ICustomerService _service; // this is a constructor to the Icustomer service 
        [BindProperty]
        public CustomerModel RemoveCustomer { get; set; } // this is the property for the delete customer 

        public void OnGet(string name) // this button is to find the customer by name 
        {
            RemoveCustomer = _service.Find(name);
        }
        public IActionResult OnPost(string name) // this button is to delete the customer and it can also redirct us to the customer index
        {
            _service.Delete(name);
            return RedirectToPage("IndexCustomer");
        }
    }
}
