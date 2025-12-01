using AddRoleApi.Models.Dtos;
using UserRoleApi.Models;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class RoleService : IRole
    {
        private readonly UserDBContext _context;
        public RoleService(UserDBContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewRole(AddRoleDto addRoleDto)
        {
            try
            {
                var role = new Role
                {
                    Id = Guid.NewGuid(),
                    Name = addRoleDto.Name
                };
                var result = new ResultResponseDto();
                if (role != null)
                {
                    await _context.Roles.AddAsync(role);
                    await _context.SaveChangesAsync();
                    result.message = "Role added successfully";
                    result.result = role;
                    return result;
                }
                result.message = "Role add is failed";
                result.result = role;
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                return result;
            }
        }
    }
}
