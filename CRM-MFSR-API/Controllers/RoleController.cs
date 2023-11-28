using AutoMapper;
using CRM_MFSR_API.Models.Dtos.Entities;
using CRM_MFSR_API.Models.Responses;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CRM_MFSR_API.Controllers
{
    /// <summary>
    /// Role Controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : Controller
    {
        /// <summary>
        /// Role Service.
        /// </summary>
        private IRoleService<Role> Service { get; set; }

        /// <summary>
        /// Automapper Service
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// User controller's contructor.
        /// </summary>
        /// <param name="service">User Service Interface. Dependency Injection.</param>
        /// <param name="mapper">Automapper instance.</param>
        public RoleController(IRoleService<Role> service, IMapper mapper)
        {
            Service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get's a role by his ID
        /// </summary>
        /// <param name="id">UUID.</param>
        /// <returns>role data.</returns>
        [HttpGet("GetById")]
        [Authorize(Policy = "Role.See")]
        public ActionResult<RoleDto> GetById(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<Role, RoleDto>(Service.GetById(id)));
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
        [Authorize(Policy = "Role.See")]
        public ActionResult<List<RoleDto>> Search(RoleDto filters)
        {
            try
            {
                return Ok(_mapper.Map<List<Role>, List<RoleDto>>(Service.GetAll(_mapper.Map<RoleDto, Role>(filters))));
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
        [Authorize(Policy = "Role.Create")]
        public ActionResult<RoleDto> Create(RoleDto data)
        {
            try
            {
                return Ok(_mapper.Map<Role, RoleDto>(Service.Create(_mapper.Map<RoleDto, Role>(data))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not create: {ex.Message}" });
            }
        }
        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="data">data to update.</param>
        /// <returns>Record updated.</returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Role.Update")]
        public ActionResult<RoleDto> Update(RoleDto data)
        {
            try
            {

                return Ok(_mapper.Map<Role, RoleDto>(Service.Update(_mapper.Map<RoleDto, Role>(data))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not update: {ex.Message}" });
            }
        }
        /// <summary>
        /// Deactivates an existing user.
        /// </summary>
        /// <param name="id">User UUID.</param>
        /// <param name="deletedBy">person who deactivate the record.</param>
        /// <returns>void.</returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "Role.Delete")]
        public ActionResult Delete(Guid id, string deletedBy)
        {
            try
            {
                Service.Delete(id, deletedBy);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not delete: {ex.Message}" });
            }
        }
    }
}
