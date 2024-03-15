namespace Hilton_Hotels.Models
{
    public interface ICustomer
    {//Interface(Khaled)
        string Name { get; set; }
        
        string Username { get; set; }    
        
        string Password { get; set; }   
    }
}
