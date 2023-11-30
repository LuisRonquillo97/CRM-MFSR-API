using Entities.Models;
using Repositories.Implementations;
using Services.Interfaces;

namespace Services.Implementations
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repository">DB repository.</param>
    public class BaseService<T>(BaseRepository<T> repository) : IBaseService<T, BaseRepository<T>> where T : BaseAttributes
    {
        /// <summary>
        /// Repository inherit from baseRepository.
        /// </summary>
        public readonly BaseRepository<T> Repository = repository;

        /// <summary>
        /// Creates a new Record <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity"><typeparamref name="T"/> Entity.</param>
        /// <returns><typeparamref name="T"/></returns>
        public virtual T Create(T entity)
        {
            return Repository.Create(entity);
        }

        /// <summary>
        /// Deactivates an existing <typeparamref name="T"/> record on DB.
        /// </summary>
        /// <param name="id"><typeparamref name="T"/> ID.</param>
        /// <param name="deletedBy">Person who deactivates <typeparamref name="T"/></param>
        public virtual void Delete(Guid id, string deletedBy)
        {
            Repository.Delete(id, deletedBy);
        }

        /// <summary>
        /// Gets a list of <typeparamref name="T"/> which matches the query.
        /// </summary>
        /// <param name="filter">Entity <typeparamref name="T"/> used to filter.</param>
        /// <returns>List of <typeparamref name="T"/> matching the query.</returns>
        public virtual List<T> GetAll(T filter)
        {
            return Repository.GetAll(filter);
        }

        /// <summary>
        /// Get an entity <typeparamref name="T"/> by his <paramref name="id"/>
        /// </summary>
        /// <param name="id"><typeparamref name="T"/> ID.</param>
        /// <returns>Entity <typeparamref name="T"/></returns>
        public virtual T GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Updates a <typeparamref name="T"/> record.
        /// </summary>
        /// <param name="entity">Entity <typeparamref name="T"/> with data to update.</param>
        /// <returns>Entity <typeparamref name="T"/> updated.</returns>
        public virtual T Update(T entity)
        {
            return Repository.Update(entity);
        }
    }
}
