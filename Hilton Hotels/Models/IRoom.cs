namespace Hilton_Hotels.Models
{
    public interface IRoom
    {//INterface room (Khaled)
        int ID { get; set; } 

        string Type { get; set; }

        double Price { get; set; }
    }
}
