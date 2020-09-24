using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArtsofteDAL;
using ArtsofteDAL.Concrete_Repositories;
using ArtsofteDAL.Implementations;
using ArtsofteDAL.POCO_Entities;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/departments")]
    public class DepartmentsController : ControllerBase
    {
        private string connectionString = @"Server=LAPTOP-RNC7R08Q\SQLExpress;Database=EmployeesDB;Trusted_Connection=true";
        private UnitOfWork UOW;
        private DepartmentRepository _departmentRepository;
        public DepartmentsController()
        {
            UOW = new UnitOfWork(connectionString);
            _departmentRepository = new DepartmentRepository(UOW,UOW.Connection);
            UOW.RegisterRepo(_departmentRepository);
        }
        [HttpPost]
        public IActionResult Post(Department department)
        {
            department.EmployeeID = 3;
            if (ModelState.IsValid)
            {
                var rep = UOW.GetRepo("DepartmentRepository") as DepartmentRepository;
                rep.Create(department);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            var rep = UOW.GetRepo("DepartmentRepository") as DepartmentRepository;
            return rep.ReadAll().ToList();
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            if (ModelState.IsValid)
            {
                var rep = UOW.GetRepo("DepartmentRepository") as DepartmentRepository;
                rep.Update(department);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rep = UOW.GetRepo("DepartmentRepository") as DepartmentRepository;
            Department department = rep.Read(id);
            if (department != null)
            {
                rep.Delete(id);
            }
            return Ok();
        }
    }
}