using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using ArtsofteDAL.GenericInterfaces;
using ArtsofteDAL.Models;

namespace ArtsofteDAL.ConcreteRepositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly IDbConnection _connection;
        
        /// <summary>
        /// Конструктор репозитория отделов. Зависимость внедрена в Startup.
        /// </summary>
        /// <param name="connection">Текущее подключение. Зависимость внедрена в Startup.</param>
        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        
        ///<inheritdoc/>
        public void Create(Department type)
        {
            _connection.Execute("INSERT INTO Departments(Name, Floor) VALUES (@Name, @Floor)",
                type);
        }
        
        ///<inheritdoc/>
        public void Update(Department type)
        { 
            _connection.Execute(
                "UPDATE Departments SET Name = @Name WHERE DepartmentID = @DepartmentID",
                type);
        }
        
        ///<inheritdoc/>
        public Department Read(int id)
        {
            return _connection.Query<Department>("SELECT * FROM Departments WHERE DepartmentID = @id", new {id}).FirstOrDefault();
        }
        
        ///<inheritdoc/>
        public List<Department> ReadAll()
        {
            return _connection.Query<Department>("SELECT * FROM Departments").ToList();
        }
        
        ///<inheritdoc/>
        public void Delete(int id)
        { 
            _connection.Execute("DELETE FROM Departments WHERE DepartmentID = @id", new {id});
        }
    }
}