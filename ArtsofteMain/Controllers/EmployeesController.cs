using System.Collections.Generic;
using System.Linq;
using ArtsofteDAL.Concrete_Repositories;
using ArtsofteDAL.Interfaces;
using ArtsofteDAL.POCO_Entities;
using ArtsofteTestWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public EmployeesController(IUnitOfWork uow)
        {
            _uow = uow;
            var employeeRepository = new EmployeeRepository(_uow);
            _uow.RegisterRepo(employeeRepository);
        }

        [HttpPost]
        public IActionResult Post(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var rep = _uow.GetRepo("EmployeeRepository") as EmployeeRepository;
                var employee = new Employee
                {
                    Name = employeeViewModel.Name,
                    Surname = employeeViewModel.Surname,
                    Age = employeeViewModel.Age,
                    Gender = employeeViewModel.Gender,
                    Department = new Department()
                    {
                        DepartmentID = rep.GetDepartmentIDByName(employeeViewModel.Department),
                        Name = employeeViewModel.Department
                    },
                    Language = new Language()
                    {
                        LanguageID = rep.GetLanguageIDByName(employeeViewModel.Language),
                        Name = employeeViewModel.Language
                    }
                };
                rep.Create(employee);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var rep = _uow.GetRepo("EmployeeRepository") as EmployeeRepository;
            return rep.ReadAll().ToList();
        }
        
        [HttpPut]
        public IActionResult Put(Language language)
        {
            if (ModelState.IsValid)
            {
                var rep = _uow.GetRepo("LanguageRepository") as LanguageRepository;
                rep.Update(language);
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rep = _uow.GetRepo("EmployeeRepository") as EmployeeRepository;
            Employee employee = rep.Read(id);
            if (employee != null)
            {
                rep.Delete(id);
            }
            return Ok();
        }
    }
}