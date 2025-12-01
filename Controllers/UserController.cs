using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddRoleDto addUserDto)
        {
            if(addUserDto != null)
            {
                return StatusCode(201, await _user.AddNewUser(addUserDto));
            }
            return StatusCode(404, await _user.AddNewUser(addUserDto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
           return StatusCode(201, await _user.GetAllUser());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return StatusCode(201, await _user.DeleteUser(id));
        }


    }
}
