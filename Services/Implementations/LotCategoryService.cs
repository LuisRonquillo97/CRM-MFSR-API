using Entities.Models.Developments;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;

namespace Services.Implementations
{
    /// <summary>
    /// Lot category service.
    /// </summary>
    /// <param name="context">SQL Context.</param>
    public class LotCategoryService(SqlContext context) : BaseService<LotCategory>(new(context)), ILotCategoryService
    {
        private readonly LotCategoryRepository Repository = new(context);

        /// <summary>
        /// Gets a list of <typeparamref name="LotCategory"/> which matches the query.
        /// </summary>
        /// <param name="filter">Entity <typeparamref name="LotCategory"/> used to filter.</param>
        /// <returns>List of <typeparamref name="LotCategory"/> matching the query.</returns>
        public override List<LotCategory> GetAll(LotCategory filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Updates a <typeparamref name="LotCategory"/> record.
        /// </summary>
        /// <param name="entity">Entity <typeparamref name="LotCategory"/> with data to update.</param>
        /// <returns>Entity <typeparamref name="LotCategory"/> updated.</returns>
        public override LotCategory Update(LotCategory entity)
        {
            return Repository.Update(entity);
        }
    }
}
