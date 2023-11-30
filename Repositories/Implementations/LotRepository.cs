using Repositories.Interfaces;
using SQLDB.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.Developments;

namespace Repositories.Implementations
{
    /// <summary>
    /// Lot repository.
    /// </summary>
    /// <remarks>
    /// Constructor
    /// </remarks>
    /// <param name="context">DB Context.</param>
    public class LotRepository(SqlContext context) : BaseRepository<Lot>(context), ILotRepository
    {
        /// <summary>
        /// Gets all records matching the search filter.
        /// </summary>
        /// <param name="filter">Base entity to filter.</param>
        /// <returns>List of entities matching the search query.</returns>
        public new List<Lot> GetAll(Lot filter)
        {
            return [.. Context.Lots.Include(x=>x.Category).Where(x => x.IsActive &&
            x.Name.Contains(filter.Name)
            )];
        }

        /// <summary>
        /// Get one Entity by his ID.
        /// </summary>
        /// <param name="id">ID to search.</param>
        /// <returns>Matching entity.</returns>
        public new Lot GetById(Guid id)
        {
            return Context.Lots.Include(x=>x.Category).First(x => x.Id == id && x.IsActive);
        }

        /// <summary>
        /// Updates data from an entity already-saved record.
        /// </summary>
        /// <param name="entity">Data to update from the entity</param>
        /// <returns>Entity updated.</returns>
        public new Lot Update(Lot entity)
        {
            try
            {
                Lot lot = this.GetById(entity.Id);
                lot.LastUpdatedAt = DateTime.Now;
                lot.LastUpdatedBy = entity.LastUpdatedBy;
                lot.FrontMeters = entity.FrontMeters;
                lot.BottomMeters = entity.BottomMeters;
                lot.PricePerSquareMeterUsed = entity.PricePerSquareMeterUsed;
                lot.LotCategoryId = entity.LotCategoryId;
                Context.Lots.Update(entity);
                Context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
