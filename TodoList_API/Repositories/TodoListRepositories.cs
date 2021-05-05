using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList_API.Models;

namespace TodoList_API.Repositories
{
    public class TodoListRepositories : ITodoListRepositories
    {
        private readonly TodoListContext _context;
        public TodoListRepositories(TodoListContext context)
        {
            _context = context;
        }

        public async Task<TodoList> Create(TodoList todoList)
        {
            _context.TodoLists.Add(todoList);
            await _context.SaveChangesAsync();

            return todoList;
        }

        public async Task Delete(int id)
        {
            var taskToDelete = await _context.TodoLists.FindAsync(id);
            _context.TodoLists.Remove(taskToDelete);

            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<TodoList>> Get()
        {
            return await _context.TodoLists.ToListAsync();
        }

        public async Task<TodoList> Get(int id)
        {
            return await _context.TodoLists.FindAsync(id);
        }

        public async Task Update(TodoList todoList)
        {
            _context.Entry(todoList).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
