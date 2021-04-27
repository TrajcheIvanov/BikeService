using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BikeService.Repositories
{
    public class BaseRepository<T> where T: class
    {
        protected readonly BikeServiceDbContext _dbContext;
        public BaseRepository(BikeServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual T GetById(int entityId)
        {
            return _dbContext.Set<T>().Find(entityId);
        }

        public virtual void Add(T newEntity)
        {
            _dbContext.Set<T>().Add(newEntity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
