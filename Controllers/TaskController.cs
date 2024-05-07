using Microsoft.AspNetCore.Mvc;
using ToDo_List.Models;
using ToDo_List.Data;


namespace ToDo_List.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public  class TaskController: ControllerBase
{
     private readonly DB _context;

    public TaskController(DB context)
    {
        _context = context;
    }


         [HttpPost]
                 public string Create(TodoItem t)
            {

                
                _context.Add(t);
                 _context.SaveChanges();
                return"با موفقیت ذخیره شد";



                }

                [HttpDelete]
                public string Delete(int id){

                    var q = from i in  _context.Tasks where i.id == id select i;
                     _context.Tasks.Remove(q.Single());

                    return "حذف شد.";


                }

               [HttpPut]
                public string Update(int id,TodoItem task){
                    

                    var q = from i in  _context.Tasks where i.id == id select i;
                    TodoItem T = q.Single();
                    T.Name = task.Name;
                    T.IsComplete = task.IsComplete;
                     _context.SaveChanges();

                    return "آپدیت شد.";
                }

                [HttpGet]
                public List<TodoItem> Read(bool flag){

                    if(flag){
                        var q = from i in  _context.Tasks where i.IsComplete == true select i;
                        return q.ToList();
                    }

                    else{
                         var q = from i in  _context.Tasks  select i;
                         return q.ToList();
                    
                    }






                }




        
    }
    
}