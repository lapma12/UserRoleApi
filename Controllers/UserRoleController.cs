using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole _userrole;

        public UserRoleController(IUserRole userrole)
        {
            _userrole = userrole;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUserRole(AddUserRoleDto addUserRoleDto)
        {
            if (addUserRoleDto != null)
            {
                return StatusCode(201, await _userrole.AddNewConnection(addUserRoleDto));
            }
            return StatusCode(404, await _userrole.AddNewConnection(addUserRoleDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRoles()
        {
            return Ok(await _userrole.GetAllUserRoles());
        }
    }
}
