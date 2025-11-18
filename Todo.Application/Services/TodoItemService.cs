using Todo.Application.Services.Interface;
using Todo.Core.Models.Request;
using Todo.Core.Models.Response;
using Todo.Core.Models.TodoItem;
using Todo.Infrastructure.Repository;

namespace Todo.Application.Services
{
    public class TodoItemService(AppDbContext context) : ITodoItemService
    {
        public async Task<TodoItemResponse> CreateTodoItemAsync(TodoItemRequest request)
        {
            var todoItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted
            };

            var results = context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            var res = new TodoItemResponse
            {
                Id = results.Entity.Id,
                Title = results.Entity.Title,
                Description = results.Entity.Description,
                IsCompleted = results.Entity.IsCompleted
            };

            return res;
        }

        public async Task<bool> DeleteTodoItemAsync(Guid id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return false;
            }

            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TodoItemResponse>> GetAllTodoItemsAsync()
        {
            return context.TodoItems.Select(i => new TodoItemResponse
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                IsCompleted = i.IsCompleted
            });
        }

        public async Task<TodoItemResponse> GetTodoItemByIdAsync(Guid id)
        {
            var result = await context.TodoItems.FindAsync(id);

            if (result == null)
            {
                return null;
            }

            return new TodoItemResponse
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                IsCompleted = result.IsCompleted
            };
        }

        public async Task<TodoItemResponse> UpdateTodoItemAsync(Guid id, TodoItemRequest request)
        {
            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            todoItem.Title = request.Title;
            todoItem.Description = request.Description;
            todoItem.IsCompleted = request.IsCompleted;

            await context.SaveChangesAsync();

            return new TodoItemResponse
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted
            };
        }
    }
}
