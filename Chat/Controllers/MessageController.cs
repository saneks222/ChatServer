using Chat.Entity;
using ChatServer.Data.Abstract;
using ChatServer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEfUserInChat _efUserInChats;
        private readonly IEfChats _efChats;
        private readonly IEfUser _efUser;
        private readonly IEfMessages _efMessages;

        public MessageController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IEfUserInChat efUserInChats,
            IEfChats efChats,
            IEfUser efUser,
            IEfMessages efMessages)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _efUserInChats = efUserInChats;
            _efChats = efChats;
            _efUser = efUser;
            _efMessages = efMessages;
        }

        [HttpPost]
        [Authorize]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody]MessageModel input) 
        {
            Chats chat = _efChats.Get(x => x.Id == input.ChatId);
            Messages message = new Messages();
            message.MessageText = input.MessageText;
            message.Chat = chat;
            message.User= await _userManager.FindByNameAsync(User.Identity.Name);

            _efMessages.Add(message);

            return Ok();
        }
    }
}
