using SpryStore.DataAccessLayer.Abstract;
using SpryStore.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpryStore.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity>
        where TEntity : class, new()
    {
        public void Insert(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new Context())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using(var context = new Context())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity GetById(int id)
        {
            using(var context = new Context())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetList()
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().ToList();
            }
        }
    }
}
