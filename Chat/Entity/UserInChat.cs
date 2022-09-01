namespace Chat.Entity
{
    public class UserInChat:BaseEntity
    {
        public  User User { get; set; }
        public  Chats Chat { get; set; }

    }
}
