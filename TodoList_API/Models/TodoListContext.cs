using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList_API.Models
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TodoList> TodoLists{ get; set; }
    }
}
