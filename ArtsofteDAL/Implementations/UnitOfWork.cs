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
        public IDbConnection Connection { get;}
        private bool disposed = false;
        

        public UnitOfWork(string connStr)
        {
            Connection = new SqlConnection(connStr);
            _repositories = new Dictionary<string, IRepository>();
            Connection.Open();
        }
            
        public void RegisterRepo(IRepository repo)
        {
            if(!_repositories.ContainsValue(repo))
                _repositories.Add(repo.GetType().Name,repo);
        }

        public IRepository GetRepo(string repoKey)
        {
            return _repositories.FirstOrDefault(x => x.Key == repoKey).Value;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
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
            Connection.Close();
            GC.SuppressFinalize(this);
        }
    }
}