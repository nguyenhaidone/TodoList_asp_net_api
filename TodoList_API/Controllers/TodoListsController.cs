using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList_API.Models;
using TodoList_API.Repositories;

namespace TodoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly ITodoListRepositories _todoListRepositories;

        public TodoListsController(ITodoListRepositories todoListRepositories)
        {
            _todoListRepositories = todoListRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoList>> GetTodoLists()
        {
            return await _todoListRepositories.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetTodoListById(int id)
        {
            return await _todoListRepositories.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<TodoList>> Post([FromBody] TodoList todoList)
        {
            var newTask = await _todoListRepositories.Create(todoList);
            return CreatedAtAction(nameof(GetTodoLists), new { id = newTask.Id }, newTask);
        }

        [HttpPut]
        public async Task<ActionResult> PutTask(int id,[FromBody] TodoList todoList)
        {
            if(id != todoList.Id)
            {
                return BadRequest();
            }

            await _todoListRepositories.Update(todoList);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var taskToDelete = await _todoListRepositories.Get(id);
            if (taskToDelete == null)
                return NotFound();

            await _todoListRepositories.Delete(taskToDelete.Id);
            return NoContent();
        }
    }
}
