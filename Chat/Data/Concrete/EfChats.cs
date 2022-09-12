using Chat.Data;
using Chat.Entity;
using ChatServer.Data.Abstract;
using ChatServer.Data.Repositorys;
using System.Runtime.CompilerServices;

namespace ChatServer.Data.Concrete
{
    public class EfChats : BaseRepository<Chats, ApplicationDbContext>, IEfChats
    {
        public List<Chats> GetAllChatsInRange(List<Guid> chatIds)
        {
            List<Chats> chats = new List<Chats>();

            foreach (var id in chatIds) 
            {
                chats.Add(Get(x=>x.Id==id));
            }

            return chats;
        }
    }
}
