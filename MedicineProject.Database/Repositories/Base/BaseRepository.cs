using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Database
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        protected MedicineProjectDbContext _context;


        protected BaseRepository(MedicineProjectDbContext dbContext)
        {
            _context = dbContext;
        }


        protected abstract DbSet<Entity> DbSet { get; }


        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
            {
                list.Add(entity);
            }

            return list;
        }


      


        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);

             return SaveChanges();
        }

        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return SaveChanges();
            }

            return false;

        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

    }

}
