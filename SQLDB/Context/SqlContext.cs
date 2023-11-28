using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace SQLDB.Context
{
    /// <summary>
    /// DB Connection class.
    /// </summary>
    /// <remarks>Uses EF Core and migrations.</remarks>
    /// <param name="options">SQLContext options.</param>
    public class SqlContext(DbContextOptions options) : DbContext(options)
    {
        /// <summary>
        /// User entity.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Role entity.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// User role entity.
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }
        /// <summary>
        /// Permissions entity.
        /// </summary>
        public DbSet<Permission> Permissions { get; set; }
        /// <summary>
        /// Role permissions entity.
        /// </summary>
        public DbSet<RolePermission> RolePermissions { get; set; }

        /// <summary>
        /// Actions to be performed when models are being created
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Indexes
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Permission>().HasIndex(x=>x.Key).IsUnique();
            #endregion
            #region Relationships
            //userRoles with roles
            modelBuilder.Entity<UserRole>().HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId).HasPrincipalKey(x => x.Id);
            //userRoles with users
            modelBuilder.Entity<UserRole>().HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id);
            //roles with permissions
            modelBuilder.Entity<RolePermission>().HasOne(x => x.Role).WithMany(x => x.RolePermissions).HasForeignKey(x => x.RoleId).HasPrincipalKey(x => x.Id);
            modelBuilder.Entity<RolePermission>().HasOne(x => x.Permission).WithMany(x => x.RolePermissions).HasForeignKey(x => x.PermissionId).HasPrincipalKey(x => x.Id);
            #endregion
            #region seeds
            //base values
            Guid roleId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            Guid seeAllUsersPermissionId = Guid.NewGuid();
            Guid crudUsersPermissionId = Guid.NewGuid();
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
            modelBuilder.Entity<Permission>().HasData([
                new Permission
                {
                    Id = seeAllUsersPermissionId,
                    Name = "See users",
                    Description = "See all users for the role Admin.",
                    Key = "User.See",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "MainSeed",
                    IsActive = true
                },
                new Permission
                {
                    Id = crudUsersPermissionId,
                    Name = "Create users",
                    Description = "Create users.",
                    Key = "User.Create",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "MainSeed",
                    IsActive = true
                },
            ]);
            modelBuilder.Entity<RolePermission>().HasData(new RolePermission
            {
                Id = Guid.NewGuid(),
                RoleId = roleId,
                PermissionId = seeAllUsersPermissionId
            }, new RolePermission
            {
                Id = Guid.NewGuid(),
                RoleId = roleId,
                PermissionId = crudUsersPermissionId
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