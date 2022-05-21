using Ispit.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Data
{
    public class ToDoContext : DbContext
    {

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<ToDoList> ToDoLists { get; set; }

    }
}
