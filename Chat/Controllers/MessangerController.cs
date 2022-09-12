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
    public class MessangerController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEfUserInChat _efUserInChats;
        private readonly IEfChats _efChats;
        private readonly IEfUser _efUser;
        private readonly IEfMessages _efMessages;

        public MessangerController(UserManager<User> userManager,
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
        ///<summary>
        ///This method get list all chats for current User
        ///</summary>
        [HttpGet]
        [Authorize]
        [Route("GetChats")]
        public async Task<IActionResult> GetChats() 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Guid> chatsId = _efUserInChats.GetList(x=>x.User == user).Select(x=>x.Chat.Id).ToList();

            return Ok(_efChats.GetAllChatsInRange(chatsId));
        }
        ///<summary>
        ///This method create new Chat between current login user and sended users ids
        ///</summary>
        /// <param name="userIds">list users ids which will enter chats</param>
        /// <param name="name">chat name</param>
        [HttpPost]
        [Authorize]
        [Route("CreateNewChat")]
        public async Task<IActionResult> CreateNewChat([FromBody]NewChatModel entity) 
        {
            var currentLoginUser = await _userManager.FindByNameAsync(User.Identity.Name);
            List<User> sendedUsers = new List<User>();

            foreach (var userId in entity.userIds) 
            {
                sendedUsers.Add(_efUser.Get(x => x.Id == userId));
            }

            Chats newChat = new Chats();
            newChat.Name = entity.name;    
            _efChats.Add(newChat);


            _efUserInChats.Add(new UserInChat() { User = currentLoginUser, Chat = newChat });

            foreach (var user in sendedUsers) 
            {
                _efUserInChats.Add(new UserInChat() { User = user, Chat = newChat });
            }


            return Ok();
        }

        ///<summary>
        ///This method get all messeg by ChatId
        ///</summary>
        /// <param name="chatId">id chat for which need load message</param>
        [HttpPost]
        [Authorize]
        [Route("GetAllMessageByChatId")]
        public async Task<IActionResult> GetAllMessageByChatId([FromBody]Guid chatId) 
        {
            List<ResponseMessageModel> responseMessageModels = new List<ResponseMessageModel>();
            var messages = _efMessages.GetList(x => x.Chat.Id == chatId);

            foreach (var msg in messages) 
            {
                responseMessageModels.Add(new ResponseMessageModel()
                {
                    MessageText=msg.MessageText,
                    PostUser=msg.User.UserName,
                    SendTime = msg.TimeSend.ToString(),
                });
            }

           return Ok(responseMessageModels);
        }


    }
}
