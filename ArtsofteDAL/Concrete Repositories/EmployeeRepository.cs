﻿﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ArtsofteDAL.Base_Classes;
using ArtsofteDAL.Generic_Interfaces;
using ArtsofteDAL.Interfaces;
using ArtsofteDAL.POCO_Entities;
using Dapper;

namespace ArtsofteDAL.Concrete_Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>
    {
        public IDbConnection Connection => new SqlConnection(@"Server=LAPTOP-RNC7R08Q\SQLExpress;Database=EmployeesDB;Trusted_Connection=true");
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Connection.Open();
        }
        public override void Create(Employee type)
        {
            Connection.Execute("INSERT INTO Employees (Name, Surname, Gender, Age, DepartmentID, LanguageID) VALUES (@Name, @Surname, @Gender, @Age, @Department.DepartmentID, @Language.LanguageID)",type);
        }

        public override void Delete(int id)
        {
            Connection.Execute("DELETE FROM Employees WHERE EmployeeID = @id", new {id});
        }

        public override Employee Read(int id)
        {
            return Connection.Query<Employee>("SELECT * FROM Employees WHERE EmployeeID = @id", new {id}).FirstOrDefault();
        }

        public override List<Employee> ReadAll()
        {
            var SQL =
                @"SELECT * FROM Employees AS E INNER JOIN Departments AS D on D.DepartmentID = E.DepartmentID INNER JOIN Languages AS L on E.LanguageID = L.LanguageID";
            var result = Connection.Query<Employee, Department, Language, Employee>(SQL, (employee, department, language) =>
            {
                employee.Department = department;
                employee.Language = language;
                return employee;
            },
                splitOn: "DepartmentID, LanguageID")
                .Distinct()
                .ToList();
            return result;
        }

        public override void Update(Employee type)
        {
            Connection.Execute("UPDATE Employees SET" +
                               "Name = @Name, "+
                               "Surname = @Surname,"+
                               "Gender = @Gender,"+
                               "Age = @Age,"+
                               "DepartmentID = @Department.DepartmentID,"+
                               "LanguageID = @Language.LanguageID"+
                               "WHERE EmployeeID = @EmployeeID",type);
        }
    }
}