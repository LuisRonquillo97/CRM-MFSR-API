namespace Repositories.Interfaces
{
    /// <summary>
    /// Interface base for repository CRUD methods.
    /// </summary>
    /// <typeparam name="T">DB entity</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Obtains a list of entities matching the search filter.
        /// </summary>
        /// <param name="filter">search filter.</param>
        /// <returns>Entity <typeparamref name="T"/> list.</returns>
        public List<T> GetAll(T filter);

        /// <summary>
        /// Get a single record of entity T, by his ID.
        /// </summary>
        /// <param name="id">Entity ID.</param>
        /// <returns>Entity.</returns>
        public T GetById(Guid id);

        /// <summary>
        /// Add a new record to entity <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Record to add.</param>
        /// <returns>Record <typeparamref name="T"/> added.</returns>
        public T Create(T entity);

        /// <summary>
        /// Updates an existing record from entity <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Data to update.</param>
        /// <returns>Record <typeparamref name="T"/> updated.</returns>
        public T Update(T entity);

        /// <summary>
        /// Deactivates an active <typeparamref name="T"/> record.
        /// </summary>
        /// <param name="id">Entity <typeparamref name="T"/> ID.</param>
        /// <param name="deletedBy">Person who deactivate the entity.</param>
        public void Delete(Guid id, string deletedBy);
    }
}
