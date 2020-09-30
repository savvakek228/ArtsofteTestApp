using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArtsofteDAL;
using ArtsofteDAL.Concrete_Repositories;
using ArtsofteDAL.Implementations;
using ArtsofteDAL.Interfaces;
using ArtsofteDAL.POCO_Entities;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public DepartmentsController(IUnitOfWork uow)
        {
            _uow = uow;
            var departmentRepository = new DepartmentRepository(_uow);
            _uow.RegisterRepo(departmentRepository);
        }
        [HttpPost]
        public IActionResult Post(Department department)
        {
            if (ModelState.IsValid)
            {
                var rep = _uow.GetRepo("DepartmentRepository") as DepartmentRepository;
                rep.Create(department);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            var rep = _uow.GetRepo("DepartmentRepository") as DepartmentRepository;
            return rep.ReadAll().ToList();
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            if (ModelState.IsValid)
            {
                var rep = _uow.GetRepo("DepartmentRepository") as DepartmentRepository;
                rep.Update(department);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rep = _uow.GetRepo("DepartmentRepository") as DepartmentRepository;
            Department department = rep.Read(id);
            if (department != null)
            {
                rep.Delete(id);
            }
            return Ok();
        }
    }
}