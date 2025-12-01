using Microsoft.EntityFrameworkCore;

namespace UserRoleApi.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=authuser;user=root;password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ru => new { ru.UserId, ru.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ru => ru.Users)
                .WithMany(u => u.userRoles)
                .HasForeignKey(ru => ru.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ru => ru.Role)
                .WithMany(r => r.userRoles)
                .HasForeignKey(ru => ru.RoleId);
        }
    }
}

