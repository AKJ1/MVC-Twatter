namespace Twatter.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    public class Repository<TEntity> where TEntity : class
    {
        internal TwatterDbContext Context;
        internal DbSet<TEntity> Set;
        private DbContextTransaction currentTransaction;

        public Repository(TwatterDbContext context)
        {
            this.Context    = context;
            this.Set        = this.Context.Set<TEntity>();
        }

            
        #region CRUD Methods
        public virtual void Create(TEntity entity)
        {
            this.Set.Add(entity);
        }

        public virtual TEntity GetById(object id)
        {
            return this.Set.Find(id);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return this.Set.Where(filter).ToList();
        }

        public virtual void Update(TEntity entity)
        {
            this.Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;    
        }
        public virtual void Delete(TEntity entity)
        {
            this.Set.Remove(entity);
        }
        #endregion

        #region Internal Operation Methods
        protected void StartOperation()
        {
            this.currentTransaction = Context.Database.BeginTransaction();
        }

        protected void FinishOperation()
        {
            this.currentTransaction.Commit();
            this.Context.SaveChanges();
        }
        #endregion
    }
}