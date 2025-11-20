using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interface;
using Todo.Core.Models.Request;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(ITodoItemService todoItemService) : ControllerBase
    {

        [HttpPost("addItem")]
        [Authorize]
        public async Task<IActionResult> CreateTodoItemAsync([FromBody] TodoItemRequest request)
        {
            var result = await todoItemService.CreateTodoItemAsync(request);

            return Ok(result);
        }

        [HttpGet("GetItemById/{id}")]
        public async Task<IActionResult> GetTodoItemByIdAsync([FromRoute]Guid id)
        {
            var result = await todoItemService.GetTodoItemByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetAllItems")]
        [Authorize]
        public async Task<IActionResult> GetAllTodoItemsAsync()
        {
            var result = await todoItemService.GetAllTodoItemsAsync();

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTodoItemAsync(Guid id, [FromBody] TodoItemRequest request)
        {
            var result = await todoItemService.UpdateTodoItemAsync(id, request);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("DeleteItemById/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteTodoItemAsync([FromRoute] Guid id)
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
