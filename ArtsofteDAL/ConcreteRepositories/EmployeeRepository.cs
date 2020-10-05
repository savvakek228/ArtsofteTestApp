using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ArtsofteDAL.GenericInterfaces;
using ArtsofteDAL.Models;
using Dapper;

namespace ArtsofteDAL.ConcreteRepositories
{
    public class EmployeeRepository : IRepository<Employee>
    {

        private readonly IDbConnection _connection;

        /// <summary>
        /// Конструктор репозитория сотрудников. Зависимость внедрена в Startup.
        /// </summary>
        /// <param name="connection">Текущее соединение. Зависимость внедрена в Startup.</param>
        public EmployeeRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        ///<inheritdoc/>
        public void Create(Employee type)
        { 
            _connection.Execute("INSERT INTO Employees (Name, Surname, Gender, Age, DepartmentID, LanguageID) VALUES (@Name, @Surname, @Gender, @Age, @DepartmentID, @LanguageID)",
                new { type.Name, type.Surname, type.Gender, type.Age, type.Department.DepartmentID, type.Language.LanguageID});
        }

        ///<inheritdoc/>
        public void Delete(int id)
        { 
            _connection.Execute("DELETE FROM Employees WHERE EmployeeID = @id", new {id});
        }

        ///<inheritdoc/>
        public Employee Read(int id)
        {
            return _connection.Query<Employee>("SELECT * FROM Employees WHERE EmployeeID = @id", new {id}).FirstOrDefault();
        }
        
        /// <summary>
        /// Вернуть ID отдела по названию отдела
        /// </summary>
        /// <param name="name">Название отдела</param>
        /// <param name="connectionString">Строка подключения</param>
        /// <returns>ID отдела, название которого мы указали</returns>
        public static int GetDepartmentIDByName(string name, string connectionString)//я понимаю, что это костыль, но лучшего решения проблемы пока не нашел
        {
            using IDbConnection _connection = new SqlConnection(connectionString);
            return _connection.Query<Department>("SELECT * FROM Departments WHERE Name = @name", new {name}).FirstOrDefault().DepartmentID;
        }
        
        
        /// <summary>
        /// Вернуть ID языка по названию языка
        /// </summary>
        /// <param name="name">Название языка</param>
        /// <param name="connectionString">Строка подключения</param>
        /// <returns>ID языка, название которого указали</returns>
        public static int GetLanguageIDByName(string name, string connectionString)//я понимаю, что это костыль, но лучшего решения проблемы пока не нашел
        {
            using IDbConnection _connection = new SqlConnection(connectionString);
            return _connection.Query<Language>("SELECT * FROM Languages WHERE Name = @name", new {name}).FirstOrDefault().LanguageID;
        }

        ///<inheritdoc/>
        public List<Employee> ReadAll()
        {
            const string SQL = @"SELECT * FROM Employees AS E INNER JOIN Departments AS D on D.DepartmentID = E.DepartmentID INNER JOIN Languages AS L on E.LanguageID = L.LanguageID";
            var result = _connection.Query<Employee, Department, Language, Employee>(SQL, (employee, department, language) =>
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

        ///<inheritdoc/>
        public void Update(Employee type)
        { 
            _connection.Execute(@"UPDATE Employees SET Name = @Name, Surname = @Surname, Gender = @Gender, Age = @Age, DepartmentID = @DepartmentID, LanguageID = @LanguageID WHERE EmployeeID = @EmployeeID",
                new { type.EmployeeID, type.Name, type.Surname, type.Age, type.Gender, type.Department.DepartmentID, type.Language.LanguageID});
        }
    }
}