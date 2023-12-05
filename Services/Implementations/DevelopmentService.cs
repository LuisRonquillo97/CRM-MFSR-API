using Entities.Models.Developments;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;

namespace Services.Implementations
{
    /// <summary>
    /// Development service.
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="context">DB context.</param>
    public class DevelopmentService(SqlContext context) : BaseService<Development>(new DevelopmentRepository(context)), IDevelopmentService
    {
        public readonly DevelopmentRepository Repository = new(context);

        /// <summary>
        /// Gets a list of <typeparamref name="Development"/> which matches the query.
        /// </summary>
        /// <param name="filter">Entity <typeparamref name="Development"/> used to filter.</param>
        /// <returns>List of <typeparamref name="Development"/> matching the query.</returns>
        public override List<Development> GetAll(Development filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Get an entity <typeparamref name="Development"/> by his <paramref name="id"/>
        /// </summary>
        /// <param name="id"><typeparamref name="Development"/> ID.</param>
        /// <returns>Entity <typeparamref name="Development"/></returns>
        public override Development GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Updates a <typeparamref name="Development"/> record.
        /// </summary>
        /// <param name="entity">Entity <typeparamref name="Development"/> with data to update.</param>
        /// <returns>Entity <typeparamref name="Development"/> updated.</returns>
        public override Development Update(Development entity)
        {
            return Repository.Update(entity);
        }

        /// <summary>
        /// Deactivates a Development, with all them stage, and then, all stage lots.
        /// </summary>
        /// <param name="stageId">Stage id.</param>
        /// <param name="deactivatedBy">Person who deactivates all.</param>
        public void DeactivateAll(Guid stageId, string deactivatedBy)
        {
            Repository.DeactivateAll(stageId, deactivatedBy);
        }

        /// <summary>
        /// Search developments by the provided filters.
        /// </summary>
        /// <param name="filter">Entity with filters.</param>
        /// <param name="releaseDateStart">Release date start filter.</param>
        /// <param name="releaseDateEnd">Release date end filter.</param>
        /// <returns>Development list.</returns>
        public List<Development> GetAll(Development filter, DateTime? releaseDateStart, DateTime? releaseDateEnd)
        {
            return Repository.GetAll(filter, releaseDateStart, releaseDateEnd);
        }
    }
}
