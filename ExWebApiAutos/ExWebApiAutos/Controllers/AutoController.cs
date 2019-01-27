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
            return repositorio.Items;
        }
        // GET api/<controller>/5
        [HttpGet("{AutoId}")]
        public Autos Get(Guid AutoId)
        {
            return repositorio.Items.Where(p => p.Id == AutoId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Autos auto)
        {
            repositorio.Save(auto);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{AutoId}")]
        public IActionResult Put(Guid AutoId, [FromBody]Autos auto)
        {
            auto.Id = AutoId;
            repositorio.Save(auto);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{AutoId}")]
        public IActionResult Delete(Guid AutoId)
        {
            repositorio.Delete(AutoId);
            return Ok(true);
        }

        [HttpGet("{pageSize}/{page}")]
        public IQueryable<Autos> Get(int pageSize, int page)
        {
            return repositorio.FilterAutos(pageSize, page);
        }
    }
}
