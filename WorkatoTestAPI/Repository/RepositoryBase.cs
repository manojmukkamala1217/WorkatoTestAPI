using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorkatoTestAPI.Contracts;

namespace WorkatoTestAPI.Repository
{
    public class RepositoryBase<T>
           where T : class, IEntity
    {
        protected readonly EnginuityContext Context;

        public RepositoryBase(EnginuityContext context)
        {
            Context = context;
        }

        protected T Create(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return entity;
        }
        protected T CreateEntityWithDetached(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        protected List<T> CreateList(List<T> entities)
        {
            Context.Set<T>().AddRange(entities);
            Context.SaveChanges();
            return entities;
        }
       

        protected Task<T> CreateAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return Task.Run(() => entity);
        }

        protected Task<T> CreateAsyncNoTracking(T entity)
        {
            Context.Set<T>().Add(entity);
            var dbEntityEntry = Context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Added;
            Context.SaveChanges();
            dbEntityEntry.State = EntityState.Detached;
            return Task.Run(() => entity);
        }


        protected void Delete(int id)
        {
            var entity = GetById(id);
            Context.Set<T>().Remove(entity!);
            Context.SaveChanges();
        }

        protected void DeleteBy(Expression<Func<T, bool>> predicate)
        {
            var entities = FindBy(predicate);
            Context.Set<T>().RemoveRange(entities);
            Context.SaveChanges();
        }

        protected IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        protected Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.Run(() => Context.Set<T>().AsNoTracking().AsEnumerable());
        }

        protected T? GetById(int id)
        {
            var lambda = BuildLambdaForFindByKey(id);

            return Context.Set<T>()
                          .AsNoTracking()
                          .SingleOrDefault(lambda);
        }

        protected Task<T?> GetByIdAsync(int id)
        {
            var lambda = BuildLambdaForFindByKey(id);

            return Task.Run(() => Context.Set<T>()
                .AsNoTracking()
                .SingleOrDefault(lambda));
        }

        protected void Update(T entity)
        {
            var dbEntityEntry = Context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            Context.SaveChanges();
            dbEntityEntry.State = EntityState.Detached;
        }

        protected void UpdateForFileProcessing(T entity)
        {
            var dbEntityEntry = Context.Entry<T>(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                Context.Set<T>().Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
            Context.SaveChanges();
        }

        protected async Task UpdateAsync(T entity)
        {
            var dbEntityEntry = Context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            dbEntityEntry.State = EntityState.Detached;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> results = Context.Set<T>().AsNoTracking()
                .Where(predicate).ToList();
            return results;
        }

        public async Task<IEnumerable<T>> FindItemsAsync(Expression<Func<T, bool>> predicate)
        {
            var results = Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
            return await results;
        }

        public Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> results = Context.Set<T>().AsNoTracking()
                .Where(predicate).ToList();
            return Task.Run(() => results);
        }

        protected IEnumerable<T> FindByInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<T> results = query.Where(predicate).ToList();
            return results;
        }

        protected IEnumerable<T> FindByInclude(EnginuityContext context, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(context, includeProperties);
            IEnumerable<T> results = query.Where(predicate).ToList();
            return results;
        }

        protected Task<IEnumerable<T>> FindByIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<T> results = query.Where(predicate).ToList();
            return Task.Run(() => results);
        }

        private IQueryable<T> GetAllIncluding
            (params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = Context.Set<T>().AsNoTracking();

            return includeProperties.Aggregate
                (queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        private IQueryable<T> GetAllIncluding
            (EnginuityContext context, params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = context.Set<T>().AsNoTracking();

            return includeProperties.Aggregate
                (queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<T> AllInclude
            (params Expression<Func<T, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        private Expression<Func<T, bool>> BuildLambdaForFindByKey(int id)
        {
            var keyProperty = GetKeyProperty();
            var item = Expression.Parameter(typeof(T), "entity");
            var prop = Expression.Property(item, keyProperty);
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<T, bool>>(equal, item);
            return lambda;
        }

        private string GetKeyProperty()
        {
            var type = typeof(T);

            var typeName = type.Name;

            string keyProperty;

            if (type.GetProperty($"{typeName}Id") != null)
            {
                keyProperty = $"{typeName}Id";
            }
            else if (type.GetProperty($"{typeName}ID") != null)
            {
                keyProperty = $"{typeName}ID";
            }
            else
            {
                keyProperty = "Id";
            }

            return keyProperty;
        }
    }
}
