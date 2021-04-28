using DanhosMessages.Entitties.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanhosMessages.Entitties.Controllers
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
        public virtual Entity Add(Entity entity = null)
        {
            entity = AddIfNull(entity);

            //_context.Attach(entity);
            _context.Set<Entity>().Add(entity);
            SaveChanges();
            return entity;
        }

        public virtual IList<Entity> GetMultiple(Func<Entity, bool> predicate = null) => predicate != null ? _context.Set<Entity>().Where(predicate).ToList() : _context.Set<Entity>().ToList();
        public virtual Entity Get(Func<Entity, bool> predicate) => GetMultiple(predicate)?.FirstOrDefault();
        public virtual Entity Get(int id) => Get(c => c.ID == id);

        public virtual Entity Update(Entity entity)
        {
            IfNull(entity);

            _context.StateAsModified(entity);
            SaveChanges();
            return entity;
        }
        public virtual Entity Update(int id) => Update(Get(id));

        public virtual void Delete(Entity entity)
        {
            IfNull(entity);

            _context.StateAsDeleted(entity);
            SaveChanges();
        }
        public virtual void Delete(int id) => Delete(Get(id));
    }
}
