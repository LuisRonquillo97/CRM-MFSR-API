using AutoMapper;
using CRM_MFSR_API.Models.Dtos.Entities;
using CRM_MFSR_API.Models.Request.Development;
using CRM_MFSR_API.Models.Request.Stage;
using CRM_MFSR_API.Models.Responses;
using Entities.Models.Developments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CRM_MFSR_API.Controllers
{
    /// <summary>
    /// Stage controller.
    /// </summary>
    /// <remarks>
    /// Development controller's contructor.
    /// </remarks>
    /// <param name="service">Development Service Interface. Dependency Injection.</param>
    /// <param name="mapper">Automapper instance.</param>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StageController(IStageService service, IMapper mapper) : Controller
    {
        /// <summary>
        /// Stage Service.
        /// </summary>
        private IStageService Service { get; set; } = service;

        /// <summary>
        /// Automapper Service
        /// </summary>
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get's a Stage by his ID
        /// </summary>
        /// <param name="id">UUID.</param>
        /// <returns>Stage data.</returns>
        [HttpGet("GetById")]
        [Authorize(Policy = "Stage.See")]
        public ActionResult<StageDto> GetById(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<Stage, StageDto>(Service.GetById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }

        }
        /// <summary>
        /// Search Stages by Query.
        /// </summary>
        /// <param name="filters">Query.</param>
        /// <returns>Matching Stages.</returns>
        [HttpPost("Search")]
        [Authorize(Policy = "Stage.See")]
        public ActionResult<List<StageDto>> Search(SearchStageRequest filters)
        {
            try
            {
                return Ok(_mapper.Map<List<Stage>, List<StageDto>>(Service.GetAll(_mapper.Map<StageDto, Stage>(filters.ToStageDto()), filters.Startdate, filters.EndDate)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
        /// <summary>
        /// Creates a new Stage.
        /// </summary>
        /// <param name="data">Data to save.</param>
        /// <returns>Stage added.</returns>
        [HttpPost("Create")]
        [Authorize(Policy = "Stage.Create")]
        public ActionResult<StageDto> Create(CreateStageRequest data)
        {
            try
            {
                return Ok(_mapper.Map<Stage, StageDto>(Service.Create(_mapper.Map<StageDto, Stage>(data.ToStageDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not create: {ex.Message}" });
            }
        }
        /// <summary>
        /// Updates an existing stage.
        /// </summary>
        /// <param name="data">data to update.</param>
        /// <returns>Stage updated.</returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Stage.Update")]
        public ActionResult<StageDto> Update(UpdateStageRequest data)
        {
            try
            {

                return Ok(_mapper.Map<Stage, StageDto>(Service.Update(_mapper.Map<StageDto, Stage>(data.ToStageDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not update: {ex.Message}" });
            }
        }
        /// <summary>
        /// Deactivates an existing stage.
        /// </summary>
        /// <param name="id">Stage UUID.</param>
        /// <param name="deletedBy">person who deactivate the stage.</param>
        /// <returns>void.</returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "Stage.Delete")]
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
