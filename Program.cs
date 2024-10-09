using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<DB>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/tasks", async (DB context, TodoItem task) =>
{
    context.Add(task);
    await context.SaveChangesAsync();
    return Results.Ok("با موفقیت ذخیره شد");
});

app.MapDelete("/api/tasks/{id}", async (DB context, int id) =>
{
    var task = await context.Tasks.FindAsync(id);
    if (task == null) return Results.NotFound();
    context.Tasks.Remove(task);
    await context.SaveChangesAsync();
    return Results.Ok("حذف شد");
});

app.MapPut("/api/tasks/{id}", async (DB context, int id, TodoItem task) =>
{
    var existingTask = await context.Tasks.FindAsync(id);
    if (existingTask == null) return Results.NotFound();
    existingTask.Title = task.Title;
    existingTask.Description = task.Description;
    existingTask.Status = task.Status;
    existingTask.Priority = task.Priority;
    existingTask.DueDate = task.DueDate;
    
    existingTask.LastModifiedDate = DateTime.UtcNow;
    existingTask.AssignedTo = task.AssignedTo;
    existingTask.IsComplete = task.IsComplete;
    await context.SaveChangesAsync();
    return Results.Ok("آپدیت شد");
});



app.MapGet("/api/tasks", async (DB context, bool flag, string? priority) =>
{
    IQueryable<TodoItem> tasksQuery;

    if (flag)
    {
        tasksQuery = context.Tasks.Where(t => t.IsComplete);
    }
    else
    {
        tasksQuery = context.Tasks.Where(t => !t.IsComplete);
    }

    if (!string.IsNullOrEmpty(priority))
    {
        tasksQuery = tasksQuery.Where(t => t.Priority.ToLower() == priority.ToLower());
    }

    var tasks = await tasksQuery.ToListAsync();

    if (!tasks.Any())
    {
        return Results.Ok("هیچ کاری پیدا نشد.");
    }

    return Results.Ok(tasks);
});

app.MapGet("/api/tasks/{id}", async (DB context, int id) => 
{
    var task = await context.Tasks.FindAsync(id);
    if(task == null)
    {
        return Results.NotFound("کار مورد نظر پیدا نشد");
    }
    return Results.Ok(task);
});

app.Run();
