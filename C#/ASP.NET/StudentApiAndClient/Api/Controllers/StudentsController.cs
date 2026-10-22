using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPHW6.Domain;
using DataModels;

namespace ASPHW6.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IRepository<Student, Guid> repo;

        public StudentsController(IRepository<Student, Guid> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return repo.GetAll();
        }

        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student value)
        {
            var saved = repo.Save(value);
            return Created($"api/v1/student/{saved.Id}", saved);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Student value)
        {
            value.Id = id;
            repo.Update(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        { 
            repo.Remove(id);
            return StatusCode(204);
        }
    }
}
