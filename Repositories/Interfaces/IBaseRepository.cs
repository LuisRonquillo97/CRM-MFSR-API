namespace Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll(T filter);
        T GetById(Guid id);
        T Create(T entity);
        T Update(T entity);
        void Delete(Guid id, string deletedBy);
    }
}
