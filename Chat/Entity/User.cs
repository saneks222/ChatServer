using Microsoft.AspNetCore.Identity;

namespace Chat.Entity
{
    public class User: IdentityUser
    {
        public string? Gender { get; set; }

        public  List<UserInChat> UserInChat { get; set; }

        public  List<Messages> Messages { get; set; }
    }
}
