using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hilton_Hotels.Pages.Customer
{
    public class UpdateCustomerModel : PageModel // this is the Update page  (Jakob) 
    {
        public UpdateCustomerModel(ICustomerService services) // the constructor of the Update customer 
        {
            _service = services;
        }
        private ICustomerService _service; //this is the Icustomer service 

        [BindProperty]
        public CustomerModel UpdateCustomer { get; set; } // this is the property of the update customer 


        public void OnGet(string name) // this button is to find the customer by name 
        {
            UpdateCustomer = _service.Find(name);
        }
        public IActionResult OnPost() // this buttom is to update and redirect to the Index of customer 
        {
            _service.Update(UpdateCustomer);
            return RedirectToPage("IndexCustomer");
        }
    }
}

