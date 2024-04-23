using ToDo_List.Models;
using Microsoft.EntityFrameworkCore; 

namespace ToDo_List.Data
{

    public class DB:DbContext
    {
       public DB(DbContextOptions<DB> options) : base(options)
        {
        }
        





public DbSet<TodoItem> Tasks{get;set;}

    }
    
}