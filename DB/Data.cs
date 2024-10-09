using ToDo_List.Models;
using Microsoft.EntityFrameworkCore; 

namespace ToDo_List.Data
{

    public class DB(DbContextOptions<DB> options) : DbContext(options)
    {
        public DbSet<TodoItem> Tasks{get;set;}

    }
    
}