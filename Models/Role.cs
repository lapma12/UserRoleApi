using System.ComponentModel.DataAnnotations.Schema;

namespace UserRoleApi.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }

        public DateTime RegTime { get; set; } = DateTime.Now;

        //Kapcsolatok
        public ICollection<UserRole> userRoles { get; set; } = new List<UserRole>();
    }
}
