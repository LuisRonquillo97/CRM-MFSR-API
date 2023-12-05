using Entities.Models.Developments;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using SQLDB.Context;

namespace Repositories.Implementations
{
    /// <summary>
    /// Stage repository.
    /// </summary>
    /// <remarks>Constructor.</remarks>
    /// <param name="context">DB Context.</param>
    public class StageRepository(SqlContext context) : BaseRepository<Stage>(context), IStageRepository
    {
        /// <summary>
        /// Deactivates an stage with all them lots.
        /// </summary>
        /// <param name="stageId">Stage id.</param>
        /// <param name="deactivatedBy">Person who deactivates all.</param>
        public void DeactivateAll(Guid stageId, string deactivatedBy)
        {
            Stage stage = this.GetById(stageId);
            if (stage != null)
            {
                foreach (Lot lot in stage.Lots)
                {
                    lot.DeactivatedAt = DateTime.Now;
                    lot.DeactivatedBy = deactivatedBy;
                    lot.IsActive = false;
                }
                stage.IsActive = false;
                stage.DeactivatedAt = DateTime.Now;
                stage.DeactivatedBy = deactivatedBy;
                Context.Update(stage);
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Search stages by the provided filters.
        /// </summary>
        /// <param name="filter">Entity with filters.</param>
        /// <param name="releaseDateStart">Release date start filter.</param>
        /// <param name="releaseDateEnd">Release date end filter.</param>
        /// <returns>Stage list.</returns>
        public List<Stage> GetAll(Stage filter, DateTime? releaseDateStart, DateTime? releaseDateEnd)
        {
            releaseDateEnd ??= DateTime.MaxValue;
            releaseDateStart ??= DateTime.MinValue;
            return
            [.. Context.Stages.Where(x => x.IsActive &&
                    x.Name.Contains(filter.Name) &&
                    x.Description.Contains(filter.Description) &&
                    x.ReleaseDate >= releaseDateStart && x.ReleaseDate <= releaseDateEnd ||
                    x.DevelopmentId.Equals(filter.DevelopmentId)
                    )
            ];
        }

        /// <summary>
        /// Gets an stage and his lots by id.
        /// </summary>
        /// <param name="id">Stage Id.</param>
        /// <returns>Stage with lots.</returns>
        public new Stage GetById(Guid id)
        {
            return Context.Stages.Include(x => x.Lots).Include(x=>x.Development).First(x => x.Id == id && x.IsActive);
        }

        /// <summary>
        /// Updates an already saved stage.
        /// </summary>
        /// <param name="entity">entity data.</param>
        /// <returns>Stage updated.</returns>
        public new Stage Update(Stage entity)
        {
            Stage stage = this.GetById(entity.Id);
            stage.Name = entity.Name;
            stage.Description = entity.Description;
            stage.ReleaseDate = entity.ReleaseDate;
            stage.PricePerSquareMeter = entity.PricePerSquareMeter;
            stage.LastUpdatedBy = entity.LastUpdatedBy;
            stage.LastUpdatedAt = DateTime.Now;
            stage.DevelopmentId = entity.DevelopmentId;
            Context.Update(stage);
            Context.SaveChanges();
            return stage;
        }
    }
}
