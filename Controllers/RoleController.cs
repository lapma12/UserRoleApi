using AddRoleApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;

        public RoleController(IRole role)
        {
            _role = role;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRole(AddRoleDto addRoleDto)
        {
            if (addRoleDto != null)
            {
                return StatusCode(201, await _role.AddNewRole(addRoleDto));
            }
            return StatusCode(404, await _role.AddNewRole(addRoleDto));
        }
    }
}
