using Entities.Models.Developments;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;

namespace Services.Implementations
{
    public class StageService(SqlContext context) : BaseService<Stage>(new StageRepository(context)), IStageService
    {
        public readonly StageRepository Repository = new(context);

        /// <summary>
        /// Search stages by the provided filters.
        /// </summary>
        /// <param name="filter">Entity with filters.</param>
        /// <param name="releaseDateStart">Release date start filter.</param>
        /// <param name="releaseDateEnd">Release date end filter.</param>
        /// <returns>Stage list.</returns>
        public List<Stage> GetAll(Stage filter, DateTime? releaseDateStart, DateTime? releaseDateEnd) { 
            return Repository.GetAll(filter, releaseDateStart, releaseDateEnd);
        }

        /// <summary>
        /// Deactivates an stage with all them lots.
        /// </summary>
        /// <param name="stageId">Stage id.</param>
        /// <param name="deactivatedBy">Person who deactivates all.</param>
        public void DeactivateAll(Guid stageId, string deactivatedBy)
        {
            Repository.DeactivateAll(stageId, deactivatedBy);
        }

        /// <summary>
        /// Get an entity <typeparamref name="Stage"/> by his <paramref name="id"/>
        /// </summary>
        /// <param name="id"><typeparamref name="Stage"/> ID.</param>
        /// <returns>Entity <typeparamref name="Stage"/></returns>
        public override Stage GetById(Guid id)
        {
            return BaseRepository.GetById(id);
        }

        /// <summary>
        /// Updates a <typeparamref name="Stage"/> record.
        /// </summary>
        /// <param name="entity">Entity <typeparamref name="Stage"/> with data to update.</param>
        /// <returns>Entity <typeparamref name="Stage"/> updated.</returns>
        public override Stage Update(Stage entity)
        {
            return BaseRepository.Update(entity);
        }
    }
}
