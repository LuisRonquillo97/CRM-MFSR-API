using Repositories.Interfaces;
using SQLDB.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using Entities.Models.Developments;

namespace Repositories.Implementations
{
    /// <summary>
    /// Lot category repository
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="context">DB context.</param>
    public class LotCategoryRepository(SqlContext context) : BaseRepository<LotCategory>(context), ILotCategoryRepository
    {
        /// <summary>
        /// Obtains a list of lot categories matching the search filter.
        /// </summary>
        /// <param name="filter">search filter.</param>
        /// <returns>Lot categories list.</returns>
        public new List<LotCategory> GetAll(LotCategory filter)
        {
            return
            [.. Context.LotCategories.Where(c => c.IsActive &&
                    (c.Name.Contains(filter.Name) ||
                    c.Description.Contains(filter.Description))
                    )
            ];
        }

        /// <summary>
        /// Updates data from a log category already-saved record.
        /// </summary>
        /// <param name="entity">Data to update from the entity</param>
        /// <returns>Entity updated.</returns>
        public new LotCategory Update(LotCategory entity)
        {
            LotCategory category = this.GetById(entity.Id);
            category.Name = entity.Name;
            category.Description = entity.Description;
            category.LastUpdatedBy = entity.LastUpdatedBy;
            category.LastUpdatedAt = DateTime.Now;
            Context.Update(category);
            Context.SaveChanges();
            return category;
        }
    }
}
