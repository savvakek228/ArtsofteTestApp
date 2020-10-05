using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ArtsofteDAL.GenericInterfaces;
using ArtsofteDAL.Models;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IRepository<Department> _rep;

        public DepartmentsController(IRepository<Department> rep)
        {
            _rep = rep;
        }

        [HttpPost]
        public IActionResult Post(Department department)
        {
            if (ModelState.IsValid)
            {
                _rep.Create(department);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            var departments = _rep.ReadAll().ToList();
            if (!departments.Any())
            {
                _rep.Create(new Department{Name = "Отдел А", Floor = 4});
                _rep.Create(new Department{Name = "Отдел Б", Floor = 6});
            }
            return departments;
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            if (ModelState.IsValid)
            {
                _rep.Update(department);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Department department = _rep.Read(id);
            if (department != null)
            {
                _rep.Delete(id);
            }
            return Ok();
        }
    }
}