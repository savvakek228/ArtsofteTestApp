using System.Collections.Generic;
using System.Linq;
using ArtsofteDAL.GenericInterfaces;
using ArtsofteDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArtsofteTestWebApp.Controllers
{
    [ApiController]
    [Route("/languages")]
    public class LanguagesController : ControllerBase
    {
        private readonly IRepository<Language> _rep;

        public LanguagesController(IRepository<Language> rep)
        {
            _rep = rep;
        }

        [HttpPost]
        public IActionResult Post(Language language)
        {
            if (ModelState.IsValid)
            {
                _rep.Create(language);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public IEnumerable<Language> Get()
        {
            var res = _rep.ReadAll().ToList();
            if (!res.Any())
            {
                _rep.Create(new Language {Name = "C#"});
                _rep.Create(new Language {Name = "JavaScript"});
            }
            return res;
        }

        [HttpPut]
        public IActionResult Put(Language language)
        {
            if (ModelState.IsValid)
            {
                _rep.Update(language);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Language language = _rep.Read(id);
            if (language != null)
            {
                _rep.Delete(id);
            }
            return Ok();
        }
    }
}