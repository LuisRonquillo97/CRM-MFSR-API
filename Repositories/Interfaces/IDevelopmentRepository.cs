using Entities.Models.Developments;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Development repository interface.
    /// </summary>
    public interface IDevelopmentRepository : IBaseRepository<Development>
    {
        /// <summary>
        /// Search developments by the provided filters.
        /// </summary>
        /// <param name="filter">Entity with filters.</param>
        /// <param name="releaseDateStart">Release date start filter.</param>
        /// <param name="releaseDateEnd">Release date end filter.</param>
        /// <returns>Development list.</returns>
        public List<Development> GetAll(Development filter, DateTime? releaseDateStart, DateTime? releaseDateEnd);

        /// <summary>
        /// Deactivates a Development, with all them stage, and then, all stage lots.
        /// </summary>
        /// <param name="stageId">Stage id.</param>
        /// <param name="deactivatedBy">Person who deactivates all.</param>
        public void DeactivateAll(Guid stageId, string deactivatedBy);
    }
}
