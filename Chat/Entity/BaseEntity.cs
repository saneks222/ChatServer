namespace Chat.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
