using System.Collections.Generic;
using System.Data;
using System.Linq;
using ArtsofteDAL.ConcreteRepositories;
using ArtsofteDAL.GenericInterfaces;
using ArtsofteDAL.Models;
using ArtsofteTestWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _rep;
        private readonly IDbConnection _conn;

        public EmployeesController(IRepository<Employee> rep, IDbConnection connection)
        {
            _rep = rep;
            _conn = connection;
        }

        [HttpPost]
        public IActionResult Post(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = employeeViewModel.Name,
                    Surname = employeeViewModel.Surname,
                    Age = employeeViewModel.Age,
                    Gender = employeeViewModel.Gender,
                    Department = new Department()
                    {
                        DepartmentID = EmployeeRepository.GetDepartmentIDByName(employeeViewModel.Department,_conn.ConnectionString),
                        Name = employeeViewModel.Department
                    },
                    Language = new Language()
                    {
                        LanguageID = EmployeeRepository.GetLanguageIDByName(employeeViewModel.Language, _conn.ConnectionString),
                        Name = employeeViewModel.Language
                    }
                };
                _rep.Create(employee);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _rep.ReadAll().ToList();
        }
        
        [HttpPut]
        public IActionResult Put(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    EmployeeID = employeeViewModel.EmployeeID ?? 0,
                    Name = employeeViewModel.Name,
                    Surname = employeeViewModel.Surname,
                    Age = employeeViewModel.Age,
                    Gender = employeeViewModel.Gender,
                    Department = new Department()
                    {
                        DepartmentID = EmployeeRepository.GetDepartmentIDByName(employeeViewModel.Department, _conn.ConnectionString),
                        Name = employeeViewModel.Department
                    },
                    Language = new Language()
                    {
                        LanguageID = EmployeeRepository.GetLanguageIDByName(employeeViewModel.Language,_conn.ConnectionString),
                        Name = employeeViewModel.Language
                    }
                };
                _rep.Update(employee);
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employee employee = _rep.Read(id);
            if (employee != null)
            {
                _rep.Delete(id);
            }
            return Ok();
        }
    }
}