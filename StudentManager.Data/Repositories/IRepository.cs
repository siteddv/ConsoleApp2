using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Repositories;

public interface IRepository<T, TId> where T : BaseEntity<TId>
{
    public T Create(T entity);
    public List<T> ReadAll();
    public T ReadById(TId id);
    public T Update(T entity);
    public T Delete(T entity);
    public T DeleteById(TId id);
    public bool IsExists(TId id);
}