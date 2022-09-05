using Chat.Data;
using Chat.Entity;
using ChatServer.Data.Abstract;
using ChatServer.Data.Repositorys;

namespace ChatServer.Data.Concrete
{
    public class EfUser : BaseRepository<User, ApplicationDbContext>, IEfUser
    {
    }
}
