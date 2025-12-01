namespace UserRoleApi.Models
{
    public class UserRole
    {
        public Guid UserId { get; set; }

        public User Users { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }


    }
}
