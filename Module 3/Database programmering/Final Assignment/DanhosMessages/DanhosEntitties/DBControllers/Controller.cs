using DanhosEntitties.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanhosEntitties.DBControllers
{
    public abstract class Controller<Entity> where Entity : HasID
    {
        protected readonly DanhosMessagesContext _context;
        public Controller(DanhosMessagesContext context) => _context = context;

        protected int SaveChanges() => _context.SaveChanges();
        protected virtual void IfNull(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException($"{nameof(entity)} must not be null");
        }

        protected abstract Entity AddIfNull(Entity entity);
        protected virtual Entity Insert(Entity entity)
        {
            IfNull(entity);

            _context.Set<Entity>().Add(entity);
            SaveChanges();
            return entity;
        }

        protected virtual IList<Entity> Get(Func<Entity, bool> predicate = null) =>
            (predicate != null ?
                _context.Set<Entity>().Where(predicate) :
                _context.Set<Entity>()
            ) as IList<Entity>;
        protected virtual Entity Get(int id) => Get(c => c.ID == id).FirstOrDefault();

        protected virtual Entity Update(Entity entity)
        {
            IfNull(entity);

            _context.StateAsModified(entity);
            SaveChanges();
            return entity;
        }
        protected virtual Entity Update(int id) => Update(Get(id));

        protected virtual void Delete(Entity entity)
        {
            IfNull(entity);

            _context.StateAsDeleted(entity);
            SaveChanges();
        }
        protected virtual void Delete(int id) => Delete(Get(id));
    }
}
