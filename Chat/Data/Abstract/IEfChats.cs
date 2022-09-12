using Chat.Entity;

namespace ChatServer.Data.Abstract
{
    public interface IEfChats:IRepository<Chats>
    {
        List<Chats> GetAllChatsInRange(List<Guid> chatIds);
    }
}
