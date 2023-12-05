using AutoMapper;
using CRM_MFSR_API.Models.Dtos.Entities;
using CRM_MFSR_API.Models.Request.Lot;
using CRM_MFSR_API.Models.Responses;
using Entities.Models.Developments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CRM_MFSR_API.Controllers
{
    /// <summary>
    /// Lots controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LotController(ILotSerivce service, IMapper mapper) : Controller
    {
        /// <summary>
        /// Lot Lot Service.
        /// </summary>
        private ILotSerivce Service { get; set; } = service;

        /// <summary>
        /// Automapper Service
        /// </summary>
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get's a Lot by his ID
        /// </summary>
        /// <param name="id">UUID.</param>
        /// <returns>Lot data.</returns>
        [HttpGet("GetById")]
        [Authorize(Policy = "Lot.See")]
        public ActionResult<LotDto> GetById(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<Lot, LotDto>(Service.GetById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }

        }
        /// <summary>
        /// Search Lots by Query.
        /// </summary>
        /// <param name="filters">Query.</param>
        /// <returns>Matching Lots.</returns>
        [HttpPost("Search")]
        [Authorize(Policy = "Lot.See")]
        public ActionResult<List<LotDto>> Search(SearchLotRequest filters)
        {
            try
            {
                return Ok(_mapper.Map<List<Lot>, List<LotDto>>(Service.GetAll(_mapper.Map<LotDto, Lot>(filters.ToLotDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
        /// <summary>
        /// Creates a new Lot.
        /// </summary>
        /// <param name="data">Data to save.</param>
        /// <returns>Lot added.</returns>
        [HttpPost("Create")]
        [Authorize(Policy = "Lot.Create")]
        public ActionResult<LotDto> Create(CreateLotRequest data)
        {
            try
            {
                return Ok(_mapper.Map<Lot, LotDto>(Service.Create(_mapper.Map<LotDto, Lot>(data.ToLotDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not create: {ex.Message}" });
            }
        }
        /// <summary>
        /// Updates an existing Lot.
        /// </summary>
        /// <param name="data">data to update.</param>
        /// <returns>Lot updated.</returns>
        [HttpPut("Update")]
        [Authorize(Policy = "Lot.Update")]
        public ActionResult<LotDto> Update(UpdateLotRequest data)
        {
            try
            {

                return Ok(_mapper.Map<Lot, LotDto>(Service.Update(_mapper.Map<LotDto, Lot>(data.ToLotDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not update: {ex.Message}" });
            }
        }
        /// <summary>
        /// Deactivates an existing Lot.
        /// </summary>
        /// <param name="id">Lot UUID.</param>
        /// <param name="deletedBy">person who deactivate the Lot.</param>
        /// <returns>void.</returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "Lot.Delete")]
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
