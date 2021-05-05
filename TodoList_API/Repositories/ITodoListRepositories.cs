using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList_API.Models;

namespace TodoList_API.Repositories
{
    public interface ITodoListRepositories
    {
        Task<IEnumerable<TodoList>> Get();

        Task<TodoList> Get(int id);

        Task<TodoList> Create(TodoList todoList);

        Task Update(TodoList todoList);

        Task Delete(int id);
    }
}
