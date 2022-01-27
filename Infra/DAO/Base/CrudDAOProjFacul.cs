using Domain.Entidades.Base;
using Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DAO.Base
{
    public class CrudDAOProjFacul<TEntity> where TEntity : Entity,  new()
    {
        public ContextProjFacul Db { get; set; }

        public DbSet<TEntity> DbSet { get; set; }


        public CrudDAOProjFacul(ContextProjFacul context = null)
        {
            if (context == null)
            {
                context = new ContextProjFacul();
            }
            Db = context;
            DbSet = Db.Set<TEntity>();
            Db.Database.Log = query => Debug.Write(query);

        }

        public virtual void SaveChanges()
        {
            try
            {

                Db.SaveChanges();
                
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entidade do tipo:\"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine(" -Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public virtual void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
        public virtual void DetachedObject(TEntity obj)
        {
            var attachedEntity = Db.ChangeTracker.Entries<TEntity>().FirstOrDefault(e => e.Entity.Id == obj.Id);
            if(attachedEntity != null)
            {
                Db.Entry<TEntity>(attachedEntity.Entity).State = EntityState.Detached;
                GC.Collect();
            }
        }
        public int Count(Expression<Func<TEntity,bool>> filtro)
        {
            if(filtro == null)
            {
                return DbSet.Count();
            }
            else
            {
                return DbSet.Where(filtro).Count();
            }
        }

        public virtual TEntity FindById (long id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id);
        }
        public virtual TEntity FindByIdWithNoTracking(long id)
        {
            return DbSet.AsNoTracking().SingleOrDefault(lp => lp.Id == id);
        }

        public virtual TEntity Save (TEntity obj)
        {
          
            var objAdd = DbSet.Add(obj);
            SaveChanges();
            return objAdd;
        }
        public virtual void SaveBach(IEnumerable<TEntity>objs)
        {
           foreach(var obj in objs)
           {                
                Save(obj);
           }
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
        }
        public virtual void RemoveById(long id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }
        public virtual void RemoveRange(long[] ids)
        {
            foreach(var id in ids)
            {
                DbSet.Remove(DbSet.Find(id));
            }
            SaveChanges();
        }
    }
}
