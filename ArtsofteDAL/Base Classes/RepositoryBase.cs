using System.Collections.Generic;
using ArtsofteDAL.Generic_Interfaces;
using ArtsofteDAL.Interfaces;

namespace ArtsofteDAL.Base_Classes
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            unitOfWork.RegisterRepo(this);
        }
        public virtual void Create(T type)
        {

        }

        public virtual void Delete(int id)
        {
            
        }

        public virtual T Read(int id)
        {
            return null;
        }

        public virtual List<T> ReadAll()
        {
            return null;
        }

        public virtual void Update(T type)
        {
            
        }
    }
}