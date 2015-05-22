namespace Twatter.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    public class Repository<TEntity> where TEntity : class
    {
        internal TwatterDbContext context;
        internal DbSet<TEntity> set;
        private DbContextTransaction currentTransaction;

        public Repository(TwatterDbContext context )
        {
            this.context    = context;
            this.set        = this.context.Set<TEntity>();
        }

            
        #region CRUD Methods
        public virtual void Create(TEntity entity)
        {
            this.set.Add(entity);
        }

        public virtual TEntity GetById(object id)
        {
            return this.set.Find(id);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return this.set.Where(filter).ToList();
        }

        public virtual void Update(TEntity entity)
        {
            this.set.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;    
        }
        public virtual void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }
        #endregion

        #region Internal Operation Methods
        protected void StartOperation()
        {
            this.currentTransaction = context.Database.BeginTransaction();
        }

        protected void FinishOperation()
        {
            this.currentTransaction.Commit();
            this.context.SaveChanges();
        }
        #endregion
    }
}