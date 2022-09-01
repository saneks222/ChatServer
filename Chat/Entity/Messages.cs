namespace Chat.Entity
{
    public class Messages:BaseEntity
    {
        public string MessageText { get; set; }
        public string MessageImg { get; set; }
        public DateTime TimeSend = DateTime.Now;

        public  Chats Chat { get; set; }
        public  User User { get; set; }
    }
}
