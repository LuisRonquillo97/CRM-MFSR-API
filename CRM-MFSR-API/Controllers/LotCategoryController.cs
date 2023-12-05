using AutoMapper;
using CRM_MFSR_API.Models.Dtos.Entities;
using CRM_MFSR_API.Models.Request.LotCategory;
using CRM_MFSR_API.Models.Responses;
using Entities.Models.Developments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CRM_MFSR_API.Controllers
{
    /// <summary>
    /// Lot catgories controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LotCategoryController(ILotCategoryService service, IMapper mapper) : Controller
    {
        /// <summary>
        /// Lot category Service.
        /// </summary>
        private ILotCategoryService Service { get; set; } = service;

        /// <summary>
        /// Automapper Service
        /// </summary>
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get's a LotCategory by his ID
        /// </summary>
        /// <param name="id">UUID.</param>
        /// <returns>LotCategory data.</returns>
        [HttpGet("GetById")]
        [Authorize(Policy = "LotCategory.See")]
        public ActionResult<LotCategoryDto> GetById(Guid id)
        {
            try
            {
                return Ok(_mapper.Map<LotCategory, LotCategoryDto>(Service.GetById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }

        }
        /// <summary>
        /// Search LotCategorys by Query.
        /// </summary>
        /// <param name="filters">Query.</param>
        /// <returns>Matching LotCategorys.</returns>
        [HttpPost("Search")]
        [Authorize(Policy = "LotCategory.See")]
        public ActionResult<List<LotCategoryDto>> Search(SearchLotCategoryRequest filters)
        {
            try
            {
                return Ok(_mapper.Map<List<LotCategory>, List<LotCategoryDto>>(Service.GetAll(_mapper.Map<LotCategoryDto, LotCategory>(filters.ToLotCategoryDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
        /// <summary>
        /// Creates a new LotCategory.
        /// </summary>
        /// <param name="data">Data to save.</param>
        /// <returns>LotCategory added.</returns>
        [HttpPost("Create")]
        [Authorize(Policy = "LotCategory.Create")]
        public ActionResult<LotCategoryDto> Create(CreateLotCategoryRequest data)
        {
            try
            {
                return Ok(_mapper.Map<LotCategory, LotCategoryDto>(Service.Create(_mapper.Map<LotCategoryDto, LotCategory>(data.ToLotCategoryDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not create: {ex.Message}" });
            }
        }
        /// <summary>
        /// Updates an existing LotCategory.
        /// </summary>
        /// <param name="data">data to update.</param>
        /// <returns>LotCategory updated.</returns>
        [HttpPut("Update")]
        [Authorize(Policy = "LotCategory.Update")]
        public ActionResult<LotCategoryDto> Update(UpdateLotCategoryRequest data)
        {
            try
            {

                return Ok(_mapper.Map<LotCategory, LotCategoryDto>(Service.Update(_mapper.Map<LotCategoryDto, LotCategory>(data.ToLotCategoryDto()))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = $"Could not update: {ex.Message}" });
            }
        }
        /// <summary>
        /// Deactivates an existing LotCategory.
        /// </summary>
        /// <param name="id">LotCategory UUID.</param>
        /// <param name="deletedBy">person who deactivate the LotCategory.</param>
        /// <returns>void.</returns>
        [HttpDelete("Delete")]
        [Authorize(Policy = "LotCategory.Delete")]
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
