using Todo.Application.Services.Interface;
using Todo.Core.Models.Request;
using Todo.Core.Models.Response;
using Todo.Infrastructure.Repository;

namespace Todo.Application.Services
{
    public class TodoItemService(AppDbContext context) : ITodoItemService
    {
        public async Task<TodoItemResponse> CreateTodoItemAsync(TodoItemRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTodoItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoItemResponse>> GetAllTodoItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TodoItemResponse> GetTodoItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoItemResponse> UpdateTodoItemAsync(Guid id, TodoItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
