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
        public async Task<object> AddNewUser(AddRoleDto addUserDto)
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

        public async Task<object> DeleteUser(Guid id)
        {
            try
            {
                var result = new ResultResponseDto();
                result.message = "User deleted successfully";
                result.result = _context.Users.Remove(_context.Users.FirstOrDefault(_context => _context.Id == id)!);
                return result;

            }
            catch (Exception)
            {
                var result = new ResultResponseDto();
                result.message = "User delete is failed";
                return result;
            }
        }

        public async Task<object> GetAllUser()
        {
            try
            {
                var result = new ResultResponseDto();
                result.message = "User list fetched successfully";
                result.result = _context.Users.ToList();
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                return result;
            }
        }

        public async Task<object> GetByIdUser(Guid id)
        {
            
            try
            {
                var result = new ResultResponseDto();
                result.message = "User fetched successfully";
                result.result = _context.Users.FirstOrDefault(_context => _context.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                var result = new ResultResponseDto();
                result.message = ex.Message;
                return result;
            }
        }

        public async Task<object> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
