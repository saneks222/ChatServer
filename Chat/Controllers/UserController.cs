using Chat.Data;
using Chat.DTO;
using Chat.Entity;
using ChatServer.Data.Abstract;
using ChatServer.Data.Concrete;
using ChatServer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEfUser _efUser;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEfUser efUser)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _efUser = efUser;
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers() 
        {
            List<User> users = _efUser.GetList().ToList();

            List<UserModel> usersModel = new List<UserModel>();

            foreach (var user in users) 
            {
                usersModel.Add(new UserModel {
                    Id=user.Id,
                    Username=user.UserName,
                    Email=user.Email,
                });
            }

            return Ok(usersModel);
        }
    }
}
