using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExWebApiAutos.Model.AutosDb;
using ExWebApiAutos.Model.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExWebApiAutos.Controllers
{
    [Route("api/[controller]")]
    public class AutoController : Controller
    {
        private IAutoRepository repositorio;
        public AutoController(IAutoRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        [HttpGet]
        public IQueryable<Autos> Get()
        {
            return repositorio.Autos;
        }
        // GET api/<controller>/5
        [HttpGet("{AutoId}")]
        public Autos Get(Guid AutoId)
        {
            return repositorio.Autos.Where(p => p.AutoId == AutoId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Autos auto)
        {
            repositorio.SaveProject(auto);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{AutoId}")]
        public IActionResult Put(Guid AutoId, [FromBody]Autos auto)
        {
            auto.AutoId = AutoId;
            repositorio.SaveProject(auto);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{AutoId}")]
        public IActionResult Delete(Guid AutoId)
        {
            repositorio.DeleteAuto(AutoId);
            return Ok(true);
        }
    }
}
