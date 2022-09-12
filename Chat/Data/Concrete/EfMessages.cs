using Chat.Data;
using Chat.Entity;
using ChatServer.Data.Abstract;
using ChatServer.Data.Repositorys;

namespace ChatServer.Data.Concrete
{
    public class EfMessages:BaseRepository<Messages,ApplicationDbContext>,IEfMessages
    {
    }
}
