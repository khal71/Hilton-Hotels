using Hilton_Hotels.Models;

namespace Hilton_Hotels.Services.Interface
{
    public interface IRoomService
    {// interface room methods(Jakob)
        public void Add(RoomModel room);
        public void Update(RoomModel room);
        public void Delete(int ID);
        public List<RoomModel> Get();
        public RoomModel Find(int ID);
    }
}
