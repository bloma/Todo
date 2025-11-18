using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interface;
using Todo.Core.Models.Request;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(ITodoItemService todoItemService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItemRequest request)
        {
            var result = await todoItemService.CreateTodoItemAsync(request);
            return CreatedAtAction(nameof(GetTodoItemById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItemById(Guid id)
        {
            var result = await todoItemService.GetTodoItemByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodoItems()
        {
            var result = await todoItemService.GetAllTodoItemsAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(Guid id, [FromBody] TodoItemRequest request)
        {
            var result = await todoItemService.UpdateTodoItemAsync(id, request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            var success = await todoItemService.DeleteTodoItemAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
