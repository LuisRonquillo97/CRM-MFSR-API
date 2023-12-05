using Entities.Models.Developments;
using Repositories.Implementations;

namespace Services.Interfaces
{
    /// <summary>
    /// Stage service interface.
    /// </summary>
    public interface IStageService : IBaseService<Stage, StageRepository>
    {
        /// <summary>
        /// Search stages by the provided filters.
        /// </summary>
        /// <param name="filter">Entity with filters.</param>
        /// <param name="releaseDateStart">Release date start filter.</param>
        /// <param name="releaseDateEnd">Release date end filter.</param>
        /// <returns>Stage list.</returns>
        public List<Stage> GetAll(Stage filter, DateTime? releaseDateStart, DateTime? releaseDateEnd);

        /// <summary>
        /// Deactivates an stage with all them lots.
        /// </summary>
        /// <param name="stageId">Stage id.</param>
        /// <param name="deactivatedBy">Person who deactivates all.</param>
        public void DeactivateAll(Guid stageId, string deactivatedBy);
    }
}
