using Entities.Models.Developments;
using Entities.Models.Users;
using Repositories.Implementations;

namespace Services.Interfaces
{
    /// <summary>
    /// Development service interface
    /// </summary>
    public interface IDevelopmentService : IBaseService<Development, DevelopmentRepository>
    {
        /// <summary>
        /// Search developments by query.
        /// </summary>
        /// <param name="filter">main development filters</param>
        /// <param name="releaseDateStart">Date filter, release date start.</param>
        /// <param name="releaseDateEnd">Date filter, release date end.</param>
        /// <returns></returns>
        public List<Development> GetAll(Development filter, DateTime? releaseDateStart, DateTime? releaseDateEnd);

        /// <summary>
        /// Deactivates a Development, with all them stage, and then, all stage lots.
        /// </summary>
        /// <param name="stageId">Stage id.</param>
        /// <param name="deactivatedBy">Person who deactivates all.</param>
        public void DeactivateAll(Guid stageId, string deactivatedBy);
    }
}
