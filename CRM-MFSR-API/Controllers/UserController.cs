using CRM_MFSR_API.Models.Request.User;
using CRM_MFSR_API.Models.Responses;
using CRM_MFSR_API.Models.Responses.User;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

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
            try
            {
                return Ok(Service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }

        }
        /// <summary>
        /// Search users by Query.
        /// </summary>
        /// <param name="filters">Query.</param>
        /// <returns>Matching users.</returns>
        [HttpPost("Search")]
        public ActionResult Search(SearchRequest filters)
        {
            try
            {
                return Ok(Service.GetAll(filters.ToUserEntity()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="data">Data to save.</param>
        /// <returns>Record added.</returns>
        [HttpPost("Create")]
        public ActionResult Create(CreateRequest data)
        {
            try
            {
                return Ok(Service.Create(data.ToUserEntity()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not create: {ex.Message}");
            }
        }
        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="data">data to update.</param>
        /// <returns>Record updated.</returns>
        [HttpPut("Update")]
        public ActionResult Update(UpdateRequest data)
        {
            try
            {
                return Ok(Service.Update(data.ToUserEntity()));
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not update: {ex.Message}");
            }
        }
        /// <summary>
        /// Deactivates an existing user.
        /// </summary>
        /// <param name="id">User UUID.</param>
        /// <param name="deletedBy">person who deactivate the record.</param>
        /// <returns>void.</returns>
        [HttpDelete("Delete")]
        public ActionResult Delete(Guid id, string deletedBy)
        {
            try
            {
                Service.Delete(id, deletedBy);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not delete: {ex.Message}");
            }
        }
        /// <summary>
        /// Determinates if user has provided role.
        /// </summary>
        /// <param name="userId">User UUID.</param>
        /// <param name="roleId">Role UUID.</param>
        /// <returns>boolean to determinate if user has role.</returns>
        [HttpGet("HasRole")]
        public ActionResult HasRole(Guid userId, Guid roleId)
        {
            try
            {
                return Ok(new HasRoleResponse(Service.HasRole(userId, roleId), userId, roleId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
        /// <summary>
        /// Login method.
        /// </summary>
        /// <param name="email">provided email.</param>
        /// <param name="password">provided password.</param>
        /// <returns>User data if login is correct.</returns>
        [HttpPost("Login")]
        public ActionResult ValidateLogin(string email, string password)
        {
            try
            {
                return Ok(Service.ValidateLogin(email, password));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
    }
}
