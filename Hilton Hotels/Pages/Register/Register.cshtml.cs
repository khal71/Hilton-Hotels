using Hilton_Hotels.Models;
using Hilton_Hotels.Pages.Account;
using Hilton_Hotels.Services;
using Hilton_Hotels.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hilton_Hotels.Pages.Customer
{
    public class RegisterModel : PageModel // here we have a code for the register  (Jakob) 
    {
        private readonly ICustomerService _customer;


        public RegisterModel(ICustomerService customer) // this constructor is for the Customer service 
        {
            _customer = customer;
            
        }
        [BindProperty]
        public RegisterCostumer registerCostumer { get; set; } // this property is for the register 
        public void OnGet() 
        {
        }
        public void OnPost() // this adds the info about the Customer 
        {
            CustomerModel model = new CustomerModel(){
            Name = registerCostumer.Name,
            Password = registerCostumer.Password,
            Username = registerCostumer.UserName,
            };
            
            _customer.Add(model);
            Response.Redirect("/Account/Login");
        }
       
    }
    public class RegisterCostumer // this is the properties for the Register
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
