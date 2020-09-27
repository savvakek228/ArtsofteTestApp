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
        public IDbConnection Connection => new SqlConnection(@"Server=LAPTOP-RNC7R08Q\SQLExpress;Database=EmployeesDB;Trusted_Connection=true");

        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Connection.Open();
        }

        public override void Create(Department type)
            => Connection.Execute("INSERT INTO Departments(EmployeeID, Name, Floor) VALUES (@EmployeeID, @Name, @Floor)", type);

        public override Department Read(int id) =>
            Connection.Query<Department>("SELECT * FROM Departments WHERE DepartmentID = @id",
                new {id}).FirstOrDefault();

        public override void Update(Department type) =>
            Connection.Execute(
                "UPDATE Departments SET EmployeeID = @EmployeeID, Name = @Name WHERE DepartmentID = @DepartmentID",
                type);

        public override List<Department> ReadAll()
            => Connection.Query<Department>("SELECT * FROM Departments").ToList();

        public override void Delete(int id)
        {
            Connection.Execute("DELETE FROM Departments WHERE DepartmentID = @id", new {id});
        }
    }
}