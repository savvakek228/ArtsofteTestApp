using System.Collections.Generic;
using System.Data;
using ArtsofteDAL.Generic_Interfaces;
using ArtsofteDAL.POCO_Entities;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using ArtsofteDAL.Base_Classes;
using ArtsofteDAL.Interfaces;

namespace ArtsofteDAL.Concrete_Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>
    {
        private readonly IDbConnection _connection;

        public DepartmentRepository(IUnitOfWork unitOfWork, IDbConnection connection) : base(unitOfWork)
        {
            _connection = connection;
        }

        public override void Create(Department type)
            => _connection.Execute("INSERT INTO Departments(EmployeeID, Name) VALUES (@EmployeeID, @Name)", type);

        public override Department Read(int id) =>
            _connection.Query<Department>("SELECT * FROM Departments WHERE DepartmentID = @id",
                new {id}).FirstOrDefault();

        public override void Update(Department type) =>
            _connection.Execute(
                "UPDATE Departments SET EmployeeID = @EmployeeID, Name = @Name WHERE DepartmentID = @DepartmentID",
                type);

        public override List<Department> ReadAll()
            => _connection.Query<Department>("SELECT * FROM Departments").ToList();
    }
}