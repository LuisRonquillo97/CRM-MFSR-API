using Repositories.Interfaces;
using SQLDB.Context;
using Microsoft.EntityFrameworkCore;
using Entities.Models.Developments;

namespace Repositories.Implementations
{
    /// <summary>
    /// Development repository.
    /// </summary>
    /// <remarks>
    /// Constructor.
    /// </remarks>
    /// <param name="context">Sql server context.</param>
    public class DevelopmentRepository(SqlContext context) : BaseRepository<Development>(context), IDevelopmentRepository
    {
        /// <summary>
        /// Get a development with his stages by default.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new Development GetById(Guid id)
        {
            return Context.Developments.Include(x => x.Stages)
                .First(x => x.Id.Equals(id) && x.IsActive);
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
            releaseDateEnd ??= DateTime.MaxValue;
            releaseDateStart ??= DateTime.MinValue;
            return
            [.. Context.Developments
                    .Where(x=>x.IsActive &&
                    x.Name.Contains(filter.Name) &&
                    x.Description.Contains(filter.Description) &&
                    x.ReleaseDate >= releaseDateStart && x.ReleaseDate<= releaseDateEnd)
            ];
        }

        /// <summary>
        /// Updates an existing record from development.
        /// </summary>
        /// <param name="entity">Data to update.</param>
        /// <returns>Record updated.</returns>
        public new Development Update(Development entity)
        {
            Development development = this.GetById(entity.Id);
            development.Name = entity.Name;
            development.Description = entity.Description;
            development.ReleaseDate = entity.ReleaseDate;
            development.ResourcesUri = entity.ResourcesUri;
            development.LastUpdatedAt = DateTime.Now;
            development.LastUpdatedBy = entity.LastUpdatedBy;
            Context.Update(development);
            Context.SaveChanges();
            return development;
        }
        
        /// <summary>
        /// Deactivates a Development, with all them stage, and then, all stage lots.
        /// </summary>
        /// <param name="stageId">Stage id.</param>
        /// <param name="deactivatedBy">Person who deactivates all.</param>
        public void DeactivateAll(Guid stageId, string deactivatedBy)
        {
            Development development = Context.Developments.Include(x=>x.Stages).ThenInclude(x=>x.Lots).First(x=>x.Id == stageId);
            if(development != null)
            {
                development.Stages.ForEach(stage =>
                {
                    stage.Lots.ForEach(lot =>
                    {
                        lot.IsActive = false;
                        lot.DeactivatedAt = DateTime.Now;
                        lot.DeactivatedBy = deactivatedBy;
                    });
                    stage.IsActive = false;
                    stage.DeactivatedAt = DateTime.Now;
                    stage.DeactivatedBy = deactivatedBy;
                });
                development.IsActive = false;
                development.DeactivatedAt = DateTime.Now;
                development.DeactivatedBy = deactivatedBy;
                Context.Update(development);
                Context.SaveChanges();
            }
        }
    }
}