using Todo.Core.Models.Request;
using Todo.Core.Models.Response;

namespace Todo.Application.Services.Interface
{
    public interface ITodoItemService
    {
        Task<TodoItemResponse> CreateTodoItemAsync(TodoItemRequest request);
        Task<TodoItemResponse> GetTodoItemByIdAsync(Guid id, Guid userId);
        Task<IEnumerable<TodoItemResponse>> GetAllTodoItemsAsync(Guid userId);
        Task<TodoItemResponse> UpdateTodoItemAsync(Guid id, TodoItemRequest request);
        Task<bool> DeleteTodoItemAsync(Guid id);
    }
}
