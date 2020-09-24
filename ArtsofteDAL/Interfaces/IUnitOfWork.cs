using System;
using System.Data;

namespace ArtsofteDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void RegisterRepo(IRepository repo);
        IRepository GetRepo(string repoKey);
    }
}