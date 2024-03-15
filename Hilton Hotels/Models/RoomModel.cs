namespace Hilton_Hotels.Models
{
    public class RoomModel
    {//Room model with constructor (Khaled)
        public int ID { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public RoomModel()
        {

        }

        public RoomModel(int iD, string type, double price)
        {
            ID = iD;
            Type = type;
            Price = price;
        }
    }
    

}
