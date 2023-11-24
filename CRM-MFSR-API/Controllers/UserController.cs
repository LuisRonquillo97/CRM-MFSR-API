using CRM_MFSR_API.Models.Request.User;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using SQLDB.Entities;

namespace CRM_MFSR_API.Controllers
{
    /// <summary>
    /// User Controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// User Service.
        /// </summary>
        private IUserService<User> Service { get; set; }
        /// <summary>
        /// User controller's contructor.
        /// </summary>
        /// <param name="service">User Service Interface. Dependency Injection.</param>
        public UserController(IUserService<User> service)
        {
            Service = service;
        }
        /// <summary>
        /// Get's an User by his ID
        /// </summary>
        /// <param name="id">UUID.</param>
        /// <returns>User data.</returns>
        [HttpGet("GetById")]
        public ActionResult GetById(Guid id)
        {
            return Ok(Service.GetById(id));
        }
        /// <summary>
        /// Search users by Query.
        /// </summary>
        /// <param name="filters">Query.</param>
        /// <returns>Matching users.</returns>
        [HttpPost("Search")]
        public ActionResult Search(SearchRequest filters)
        {
            User userFilter = new User
            {
                Email = filters.Email,
                FirstName = filters.FirstName,
                LastName = filters.LastName,
                CreatedBy = string.Empty,
                Password = string.Empty,
            };
            return Ok(Service.GetAll(userFilter));
        }
        [HttpPost("Create")]
        public ActionResult Create(CreateRequest data)
        {
            Guid id = Guid.NewGuid();
            List<UserRole> roles = new List<UserRole>();
            data.RoleIds.ForEach(x => roles.Add(new UserRole { RoleId = x, UserId = id, CreatedBy = data.CreatedBy }));
            User userData = new User { 
                Id = id,
                FirstName = data.FirstName, 
                LastName = data.LastName, 
                Email = data.Email, 
                Password = data.Password, 
                CreatedBy = data.CreatedBy,
                UserRoles = roles
            };
            return Ok(Service.Create(userData));
        }
        [HttpPut("Update")]
        public ActionResult Update(UpdateRequest data)
        {
            Guid id = Guid.NewGuid();
            List<UserRole> roles = new List<UserRole>();
            data.RoleIds.ForEach(x => roles.Add(new UserRole { RoleId = x, UserId = id, CreatedBy = data.UpdatedBy }));
            User userData = new User
            {
                Id = id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                LastUpdatedAt = DateTime.Now,
                LastUpdatedBy = data.UpdatedBy,
                UserRoles = roles
            };
            return Ok(Service.Update(userData));
        }
        [HttpDelete("Delete")]
        public ActionResult Delete(Guid id, string deletedBy)
        {
            Service.Delete(id, deletedBy);
            return Ok();
        }
    }
}
