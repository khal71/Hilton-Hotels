using Hilton_Hotels.Models;
using Hilton_Hotels.Services.Interface;
using System.Text.Json;

namespace Hilton_Hotels.Services
{
    public class RoomServiceJson : IRoomService
    {//methods for rooms(Jakob)
        private const string fileDir = "../Hilton Hotels/wwwroot/Jsonfiles/";
        private const string fileName = fileDir + "RoomJson.json";

        List<RoomModel> _rooms = new List<RoomModel>();
        public RoomServiceJson()
        {
            _rooms = ReadFromJson();
        }
        // adds a room and saves it to json
        public void Add(RoomModel room)
        {
            _rooms.Add(room);
            SaveToJson();
        }
        // this methods findsthe room with an id and removes it and saves changes to json
        public void Delete(int ID)
        {
            RoomModel room = Find(ID);
            _rooms.Remove(room);
            SaveToJson();

        }
        //this method reads the files from json
        public List<RoomModel> ReadFromJson()
        {
            using (var file = File.OpenText(fileName))
            {
                String json = file.ReadToEnd();
                return JsonSerializer.Deserialize<List<RoomModel>>(json);
            }
            return new List<RoomModel>();
        }
        // this method finds the room from the id we give it
        public RoomModel Find(int ID)
        {
            RoomModel r = _rooms.Find(r => r.ID == ID);
            if (r is not null)
            {
                return r;
            }
            throw new KeyNotFoundException();
            //This method finds the room with the id, makes changes and saves them to json
        }
        public void Update(RoomModel newRoom)
        {
            RoomModel room = Find(newRoom.ID);

            room.ID = newRoom.ID;
            room.Type = newRoom.Type;
            room.Price = newRoom.Price;

            SaveToJson();
        }
        //This method saves changes to json
        private void SaveToJson()
        {
            String json = JsonSerializer.Serialize(_rooms);
            File.WriteAllText(fileName, json);
        }
        // this ethods calls and shows the list of rooms
        public List<RoomModel> Get()
        {
            return new List<RoomModel>(_rooms);
        }
    }
}
