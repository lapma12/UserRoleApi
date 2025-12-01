using System.Data;
using UserRoleApi.Models;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class UserRoleService : IUserRole
    {
        private readonly UserDBContext _context;
        public UserRoleService(UserDBContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewConnection(AddUserRoleDto addUserRoleDto)
        {
            try
            {
                var result = new ResultResponseDto();
                var userrole = new UserRole
                {
                    UserId = addUserRoleDto.UserId,
                    RoleId = addUserRoleDto.RoleId
                };
                if (userrole != null)
                {
                    _context.UserRoles.AddAsync(userrole);
                    _context.SaveChangesAsync();
                    result.message = "UserRole connection added successfully";
                    result.result = userrole;
                    return result;
                }
                result.message = "Role add is failed";
                result.result = userrole;
                return result;
            }
            catch (Exception ex)
            {

                var result = new ResultResponseDto();
                result.message = ex.Message;
                return result;
            }
        }

        public Task<object> GetAllUserRoles()
        {
            try
            {
                var result = new ResultResponseDto();
                var userroles = _context.UserRoles.ToList();
                if (userroles != null && userroles.Count > 0)
                {
                    result.message = "UserRoles fetched successfully";
                    result.result = userroles;
                    return Task.FromResult((object)result);
                }
                result.message = "No UserRoles found";
                result.result = userroles;
                return Task.FromResult((object)result);
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                return Task.FromResult((object)result);
            }
        }
    }
}
