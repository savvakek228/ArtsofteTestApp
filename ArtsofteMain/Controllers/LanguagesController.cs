using System;
using System.Collections.Generic;
using System.Linq;
using ArtsofteDAL.Concrete_Repositories;
using ArtsofteDAL.Interfaces;
using ArtsofteDAL.POCO_Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/languages")]
    public class LanguagesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public LanguagesController(IUnitOfWork uow)
        {
            _uow = uow;
            var languagesRepository = new LanguageRepository(_uow);
            _uow.RegisterRepo(languagesRepository);
        }
        
        [HttpPost]
        public IActionResult Post(Language language)
        {
            language.EmployeeID = new Random().Next(4);
            if (ModelState.IsValid)
            {
                var rep = _uow.GetRepo("LanguageRepository") as LanguageRepository;
                rep.Create(language);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<Language> Get()
        {
            var rep = _uow.GetRepo("LanguageRepository") as LanguageRepository;
            var res = rep.ReadAll().ToList();
            return res;
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
            var rep = _uow.GetRepo("LanguageRepository") as LanguageRepository;
            Language language = rep.Read(id);
            if (language != null)
            {
                rep.Delete(id);
            }
            return Ok();
        }
    }
}