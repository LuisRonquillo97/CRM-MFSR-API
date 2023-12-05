using Repositories.Interfaces;
using SQLDB.Context;
using Entities.Models;

namespace Repositories.Implementations
{
    /// <summary>
    /// Generic implementation of base repository.
    /// </summary>
    /// <typeparam name="T">Base Attribute from DB entities.</typeparam>
    /// <remarks>
    /// Constructor.
    /// </remarks>
    /// <param name="context">DBContext.</param>
    public class BaseRepository<T>(SqlContext context) : IBaseRepository<T> where T : BaseAttributes
    {
        /// <summary>
        /// DBContext.
        /// </summary>
        public readonly SqlContext Context = context;

        /// <summary>
        /// Creates a new row of the provided Entity.
        /// </summary>
        /// <param name="entity">Data to save.</param>
        /// <returns>Record saved.</returns>
        public virtual T Create(T entity)
        {
            try
            {
                Context.Add(entity);
                Context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Set the field 'IsActive' switch to false of the provided entity.
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <param name="deletedBy">User who delete the entity.</param>
        public virtual void Delete(Guid id, string deletedBy)
        {
            try
            {
                T entity = GetById(id);
                entity.IsActive = false;
                entity.DeactivatedAt = DateTime.Now;
                entity.DeactivatedBy = deletedBy;
                Context.Update(entity);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all records matching the search filter.
        /// </summary>
        /// <param name="filter">Base entity to filter.</param>
        /// <returns>List of entities matching the search query.</returns>
        public virtual List<T> GetAll(T filter)
        {
            return [.. Context.Set<T>().Where(x => x == filter)];
        }

        /// <summary>
        /// Get one Entity by his ID.
        /// </summary>
        /// <param name="id">ID to search.</param>
        /// <returns>Matching entity.</returns>
        public virtual T GetById(Guid id)
        {
            return Context.Set<T>().First(x => x.Id == id && x.IsActive);
        }

        /// <summary>
        /// Updates data from an entity already-saved record.
        /// </summary>
        /// <param name="entity">Data to update from the entity</param>
        /// <returns>Entity updated.</returns>
        public virtual T Update(T entity)
        {
            try
            {
                Context.Set<T>().Update(entity);
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
