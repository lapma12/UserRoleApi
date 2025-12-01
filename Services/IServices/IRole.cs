using AddRoleApi.Models.Dtos;

namespace UserRoleApi.Services.IServices
{
    public interface IRole
    {
        Task<object> AddNewRole(AddRoleDto addRoleDto);

    }
}
