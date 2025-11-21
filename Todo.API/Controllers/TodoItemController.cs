using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            try
            {
                var userId = HttpContext.User.Claims.First().Value;
                request.UserId = Guid.Parse(userId);

                var result = await todoItemService.CreateTodoItemAsync(request);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        [HttpGet("GetItemById/{id}")]
        public async Task<IActionResult> GetTodoItemByIdAsync([FromRoute]Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.First().Value);
                
            var result = await todoItemService.GetTodoItemByIdAsync(id, userId);

            if (result == null)
            {
                return NotFound("Item with the provided Id cannot be found");
            }

            return Ok(result);
        }

        [HttpGet("GetAllItems")]
        [Authorize]
        public async Task<IActionResult> GetAllTodoItemsAsync()
        {
            var userId = Guid.Parse(HttpContext.User.Claims.First().Value);
            var result = await todoItemService.GetAllTodoItemsAsync(userId);

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
