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
        private IDbConnection _connection;

        public UnitOfWork()
        {
            _connection = new SqlConnection();
            _repositories = new Dictionary<string, IRepository>();
            _connection.Open();
        }
            
        public void RegisterRepo(IRepository repo)
        {
            _repositories.Add(repo.GetType().Name,repo);
        }

        public IRepository GetRepo(string repoKey)
        {
            return _repositories.FirstOrDefault(x => x.Key == repoKey).Value;
        }
        
        public void Dispose()
        {
            _connection.Close();
        }
    }
}