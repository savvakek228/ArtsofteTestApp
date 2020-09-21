using System;
using System.Collections.Generic;

namespace ArtsofteDAL.Generic_Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T type);
        void Delete(int id);
        T Read(int id);
        List<T> ReadAll();
        void Update(T type);
    }
}