using StudentManager.Backend.Contexts;
using StudentManager.Backend.Entities;
using StudentManager.Backend.Repositories;

namespace StudentManager.Data.Repositories
{
    public class DbRepository<T, TId> : IRepository<T, TId>
        where T : BaseEntity<TId>
    {
        protected readonly AppDbContext Ctx;

        public DbRepository(AppDbContext ctx)
        {
            Ctx = ctx;
        }

        public T Create(T entity)
        {
            if(Ctx.Set<T>() == null)
            {
                return null;
            }

            var a = Ctx.Set<T>().Add(entity);
            Ctx.SaveChanges();

            return a.Entity;
        }

        public List<T> ReadAll()
        {
            if (Ctx.Set<T>() == null)
            {
                return null;
            }

            var list = Ctx.Set<T>().ToList();

            return list;
        }

        public T ReadById(TId id)
        {
            if (Ctx.Set<T>() == null)
            {
                return null;
            }

            var entity = Ctx.Set<T>().FirstOrDefault(en => en.Id.Equals(id));
            return entity;
        }

        public T Update(T entity)
        {
            if (Ctx.Set<T>() == null)
            {
                return null;
            }

            var a = Ctx.Set<T>().Update(entity);
            Ctx.SaveChanges();

            return a.Entity;
        }

        public T Delete(T entity)
        {
            if (Ctx.Set<T>() == null)
            {
                return null;
            }

            Ctx.Set<T>().Remove(entity);

            Ctx.SaveChanges();

            return entity;
        }

        public T DeleteById(TId id)
        {
            var entity = ReadById(id);
            Ctx.Set<T>().Remove(entity);

            Ctx.SaveChanges();

            return entity;
        }

        public bool IsExists(TId id)
        {
            return Ctx.Set<T>().Any(entity => entity.Id.Equals(id));
        }
    }
}
