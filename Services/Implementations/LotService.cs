using Entities.Models.Developments;
using Repositories.Implementations;
using Services.Interfaces;
using SQLDB.Context;

namespace Services.Implementations
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">SQL Context.</param>
    public class LotService(SqlContext context) : BaseService<Lot>(new(context)), ILotSerivce
    {
        private readonly LotRepository Repository = new(context);
        /// <summary>
        /// Gets a list of <typeparamref name="Lot"/> which matches the query.
        /// </summary>
        /// <param name="filter">Entity <typeparamref name="Lot"/> used to filter.</param>
        /// <returns>List of <typeparamref name="Lot"/> matching the query.</returns>
        public override List<Lot> GetAll(Lot filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Get an entity <typeparamref name="Lot"/> by his <paramref name="id"/>
        /// </summary>
        /// <param name="id"><typeparamref name="Lot"/> ID.</param>
        /// <returns>Entity <typeparamref name="Lot"/></returns>
        public override Lot GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Updates a <typeparamref name="Lot"/> record.
        /// </summary>
        /// <param name="entity">Entity <typeparamref name="Lot"/> with data to update.</param>
        /// <returns>Entity <typeparamref name="Lot"/> updated.</returns>
        public override Lot Update(Lot entity)
        {
            return Repository.Update(entity);
        }
    }
}
