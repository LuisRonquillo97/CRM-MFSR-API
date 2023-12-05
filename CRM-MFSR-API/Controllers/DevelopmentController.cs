using AutoMapper;
using CRM_MFSR_API.Models.Dtos.Entities;
using CRM_MFSR_API.Models.Request.Development;
using CRM_MFSR_API.Models.Responses;
using Entities.Models.Developments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CRM_MFSR_API.Controllers
{
    /// <summary>
    /// Development Controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DevelopmentController : Controller
    {
        /// <summary>
        /// Development Service.
        /// </summary>
        private IDevelopmentService Service { get; set; }

        /// <summary>
        /// Automapper Service
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Development controller's contructor.
        /// </summary>
        /// <param name="service">Development Service Interface. Dependency Injection.</param>
        /// <param name="mapper">Automapper instance.</param>
        public DevelopmentController(IDevelopmentService service, IMapper mapper)
        {
            Service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get's a development by his ID
        /// </summary>
        /// <param name="id">UUID.</param>
        /// <returns>Development data.</returns>
        [HttpGet("GetById")]
        [Authorize(Policy = "Development.See")]
        public ActionResult<DevelopmentDto> GetById(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<Development, DevelopmentDto>(Service.GetById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }

        }
        /// <summary>
        /// Search developments by Query.
        /// </summary>
        /// <param name="filters">Query.</param>
        /// <returns>Matching developments.</returns>
        [HttpPost("Search")]
        [Authorize(Policy = "Development.See")]
        public ActionResult<List<DevelopmentDto>> Search(SearchDevelopmentRequest filters)
        {
            try
            {
                return Ok(_mapper.Map<List<Development>, List<DevelopmentDto>>(Service.GetAll(_mapper.Map<DevelopmentDto, Development>(filters.ToDevelopmentDto()), filters.StartDate, filters.EndDate)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
        /// <summary>
        /// Creates a new development.
        /// </summary>
        /// <param name="data">Data to save.</param>
        /// <returns>Record added.</returns>
        [HttpPost("Create")]
        [Authorize(Policy = "Development.Create")]
        public ActionResult<DevelopmentDto> Create(CreateDevelopmentRequest data)
        {
            try
            {
                return Ok(_mapper.Map<Development, DevelopmentDto>(Service.Create(_mapper.Map<DevelopmentDto, Development>(data.ToDevelopmentDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not create: {ex.Message}" });
            }
        }
        /// <summary>
        /// Updates an existing development.
        /// </summary>
        /// <param name="data">data to update.</param>
        /// <returns>Record updated.</returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Development.Update")]
        public ActionResult<DevelopmentDto> Update(UpdateDevelopmentRequest data)
        {
            try
            {

                return Ok(_mapper.Map<Development, DevelopmentDto>(Service.Update(_mapper.Map<DevelopmentDto, Development>(data.ToDevelopmentDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not update: {ex.Message}" });
            }
        }
        /// <summary>
        /// Deactivates an existing development.
        /// </summary>
        /// <param name="id">Development UUID.</param>
        /// <param name="deletedBy">person who deactivate the record.</param>
        /// <returns>void.</returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "Development.Delete")]
        public ActionResult Delete(Guid id, string deletedBy)
        {
            try
            {
                Service.DeactivateAll(id, deletedBy);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not delete: {ex.Message}" });
            }
        }
    }
}
