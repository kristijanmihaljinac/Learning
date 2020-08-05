using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EasyBlog.Core
{
    public abstract class DataRepositoryBase<T, U> : IDataRepository<T>
        where T : class, IIdentifiableEntity, new()
        where U : DbContext, new()
    {
        public DataRepositoryBase(string connectionStringName)
        {
            _ConnectionStringName = connectionStringName;
        }

        protected string _ConnectionStringName = string.Empty;

        protected abstract DbSet<T> DbSet(U entityContext);
        protected abstract Expression<Func<T, bool>> IdentifierPredicate(U entityContext, int id);

        T AddEntity(U entityContext, T entity)
        {
            return DbSet(entityContext).Add(entity);
        }

        IEnumerable<T> GetEntities(U entityContext)
        {
            return DbSet(entityContext).ToFullyLoaded();
        }

        T GetEntity(U entityContext, int id)
        {
            return DbSet(entityContext).Where(IdentifierPredicate(entityContext, id)).FirstOrDefault();
        }
        
        T UpdateEntity(U entityContext, T entity)
        {
            var q = DbSet(entityContext).Where(IdentifierPredicate(entityContext, entity.EntityId));
            return q.FirstOrDefault();
        }

        public T Add(T entity)
        {
            U entityContext = (U)(Activator.CreateInstance(typeof(U), _ConnectionStringName));
            using (entityContext)
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public void Remove(T entity)
        {
            U entityContext = (U)(Activator.CreateInstance(typeof(U), _ConnectionStringName));
            using (entityContext)
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            U entityContext = (U)(Activator.CreateInstance(typeof(U), _ConnectionStringName));
            using (entityContext)
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            U entityContext = (U)(Activator.CreateInstance(typeof(U), _ConnectionStringName));
            using (entityContext)
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return existingEntity;
            }
        }

        public IEnumerable<T> Get()
        {
            U entityContext = (U)(Activator.CreateInstance(typeof(U), _ConnectionStringName));
            using (entityContext)
                return (GetEntities(entityContext)).ToArray().ToList();
        }

        public T Get(int id)
        {
            U entityContext = (U)(Activator.CreateInstance(typeof(U), _ConnectionStringName));
            using (entityContext)
                return GetEntity(entityContext, id);
        }
    }
}
