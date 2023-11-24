using Microsoft.EntityFrameworkCore;
using SQLDB.Entities;

namespace SQLDB.Context
{
    public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Indexes
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(x => x.Name).IsUnique();
            #endregion
            #region Relationships
            //userRoles with roles
            modelBuilder.Entity<UserRole>().HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId).HasPrincipalKey(x => x.Id);
            //userRoles with users
            modelBuilder.Entity<UserRole>().HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id);
            #endregion
            #region seeds
            //base values
            Guid roleId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string createdBy = "mainSeed";
            //first user role.
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                Email = "admin@mail.com",
                FirstName = "First",
                LastName = "Admin",
                Password = "Password",
                CreatedAt = DateTime.Now,
                CreatedBy = createdBy
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Description = "Has full permissions.",
                Name = "Administrator",
                CreatedAt = DateTime.Now,
                CreatedBy = createdBy
            });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    RoleId = roleId,
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = createdBy
                }
                );
            #endregion
        }
    }
}