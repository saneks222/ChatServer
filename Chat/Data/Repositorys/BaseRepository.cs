using Chat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace ChatServer.Data.Repositorys
{
    public class BaseRepository<Tentity, Tcontext> : IRepository<Tentity> 
        where Tentity : class, new()
        where Tcontext : DbContext ,new()
    {

        public void Add(Tentity entity)
        {
            using (var context = new Tcontext()) 
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var context = new Tcontext()) 
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public IList<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var context = new Tcontext()) 
            {
                if (filter == null)
                    return context.Set<Tentity>().ToList();

                return  context.Set<Tentity>().Where(filter).ToList();

            }
        }

        public void Update(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
