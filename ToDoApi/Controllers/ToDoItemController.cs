using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ToDoItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> Get()
        {
            return Ok(await _context.ToDoItems.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> Post(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.ToDoItems.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<ToDoItem>> UpdateTask(ToDoItem item)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(item.Id);

            if (toDoItem == null)
                return NotFound();

            toDoItem.Task = item.Task;
            toDoItem.IsDone = item.IsDone;
            toDoItem.DateCompleted = item.DateCompleted;

            return Ok(toDoItem);
        }

        [HttpPut("CompleteTask/")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);

            if (item == null)
                return NotFound();

            item.IsDone = true;
            item.DateCompleted = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);

            if (toDoItem == null)
                return NotFound();

            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.ToDoItems.ToListAsync());
        }
    }

}
