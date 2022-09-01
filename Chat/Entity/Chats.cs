namespace Chat.Entity
{
    public class Chats : BaseEntity
    {
        public  List<UserInChat> UserInChats { get; set; }
        public  List<Messages> Messages { get; set; }
    }
}
