using Chat.Data;
using Chat.Entity;
using ChatServer.Data.Abstract;
using ChatServer.Data.Repositorys;

namespace ChatServer.Data.Concrete
{
    public class EfUserInChat:BaseRepository<UserInChat,ApplicationDbContext>, IEfUserInChat
    {
    }
}
