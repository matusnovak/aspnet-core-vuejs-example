using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Example.Api.Models;
using Example.Api.Data;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository repository;

        public TodoController(TodoRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<IEnumerable<Todo>> Get()
        {
            return await repository.FindAll();
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            Todo item = await repository.FindById(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Todo>> Post([FromBody] Todo item)
        {
            item.CreatedAt = DateTime.Now;
            await repository.Create(item);
            return Ok(item);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> Put(int id, [FromBody] Todo item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            await repository.Update(item);
            return item;
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Todo item = await repository.FindById(id);
            if (item == null) return NotFound();
            await repository.Delete(item);
            return Ok();
        }
    }
}
