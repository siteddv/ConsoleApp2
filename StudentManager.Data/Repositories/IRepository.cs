using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Repositories;

public interface IRepository<T, TId> where T : BaseEntity<TId>
{
    public T Create(T entity);
    public List<T> ReadAll();
    public T ReadById(TId id);
    public T Update(T entity);
    public void Delete(T entity);
    public void DeleteById(TId id);
}