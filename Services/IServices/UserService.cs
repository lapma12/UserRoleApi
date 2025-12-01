using MySqlX.XDevAPI.Common;
using UserRoleApi.Models;
using UserRoleApi.Models.Dtos;

namespace UserRoleApi.Services.IServices
{
    public class UserService : IUser
    {
        private readonly UserDBContext _context;
        public UserService(UserDBContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewUser(AddUserDto addUserDto)
        {
			try
			{
                var result = new ResultResponseDto();
                var user = new User
				{
                    Id = Guid.NewGuid(),
                    Name = addUserDto.Name,
                    Email = addUserDto.Email,
                    Password = addUserDto.Password
                };
                
                if (user != null)
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    result.message = "User added successfully";
                    result.result = user;
                    return result;
                }
                result.message = "User add is failed";
                result.result = user;
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
