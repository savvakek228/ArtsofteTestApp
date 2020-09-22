using System;
using System.Collections.Generic;
using ArtsofteDAL.Interfaces;

namespace ArtsofteDAL.Generic_Interfaces
{
    internal interface IRepository<T> : IRepository where T : class
    {
        void Create(T type);
        void Delete(int id);
        T Read(int id);
        List<T> ReadAll();
        void Update(T type);
    }
}