using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ArtsofteDAL.Concrete_Repositories;
using ArtsofteDAL.Generic_Interfaces;
using ArtsofteDAL.Interfaces;

namespace ArtsofteDAL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<string, IRepository> _repositories;
        private bool disposed = false;
        

        public UnitOfWork()
        {
            _repositories = new Dictionary<string, IRepository>();
        }
            
        public void RegisterRepo(IRepository repo)
        {
            if(!_repositories.ContainsValue(repo))
                _repositories.Add(repo.GetType().Name,repo);
        }

        public IRepository GetRepo(string repoKey)
            => _repositories.FirstOrDefault(x => x.Key == repoKey).Value;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _repositories.Clear();
                }
                this.disposed = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}