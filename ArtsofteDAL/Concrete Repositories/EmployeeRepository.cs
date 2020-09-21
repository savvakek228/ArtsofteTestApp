using System.Collections.Generic;
using ArtsofteDAL.Generic_Interfaces;
using ArtsofteDAL.POCO_Entities;

namespace ArtsofteDAL.Concrete_Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Create(Employee type)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Employee type)
        {
            throw new System.NotImplementedException();
        }
    }
}