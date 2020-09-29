using ArtsofteDAL.Concrete_Repositories;
using ArtsofteDAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        
        public EmployeesController(IUnitOfWork uow)
        {
            _uow = uow;
            var employeeRepository = new EmployeeRepository(_uow);
            _uow.RegisterRepo(employeeRepository);
        }
        
        //TODO
    }
}