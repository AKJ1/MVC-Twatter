namespace Twatter.Data.UnitOfWork
{
    using System;
    using Repository;
    using Models;

    public class UnitOfWork : IDisposable
    {
        private TwatterDbContext context = new TwatterDbContext();

        #region repositories and constructors
        private Repository<Twatt> twattRepository;
        private Repository<User> userRepository;
        private Repository<Trend> trendRepository;

        public Repository<Twatt> TwattRepository
        {
            get
            {
                if (twattRepository == null)
                {
                    twattRepository = new Repository<Twatt>(context);
                }
                return twattRepository;
            }
        }
        public Repository<User> UserRepository
        {
            get {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(context);
                }
                return userRepository; 
            }
        }
        public Repository<Trend> TrendRepository
        {
            get
            {
                if (trendRepository == null)
                {
                    trendRepository = new Repository<Trend>(context);
                }
                return trendRepository; 
                
            }
        }
        #endregion

        #region UnitOfWork Class Methods
        public void Dispose()
        {
            Dispose(true);
        }

        private bool disposed = false;

        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion
    }
}