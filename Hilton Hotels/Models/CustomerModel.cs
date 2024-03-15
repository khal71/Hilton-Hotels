namespace Hilton_Hotels.Models
{
    public class CustomerModel : ICustomer
    {//Model with constructors(Khaled)
        public string Name { get; set; }
        
        public string Username { get; set; }
        public string Password { get; set; }
        public CustomerModel()
        {

        }
        public CustomerModel(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
        }


    }
}
