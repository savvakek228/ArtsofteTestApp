using System;

namespace ArtsofteDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void ConnectToDb(string connString);
        void AddRepo<T>(T repoType);
        void GetRepo<T>(T repoType);
        void SubmitToDatabase();
    }
}