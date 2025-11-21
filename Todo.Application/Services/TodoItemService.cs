using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                UserId = request.UserId
            };

            var results = context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            var res = new TodoItemResponse
            {
                Id = results.Entity.Id,
                Title = results.Entity.Title,
                Description = results.Entity.Description,
                IsCompleted = results.Entity.IsCompleted,
                UserId = results.Entity.UserId
            };

            return res;
        }

        public async Task<bool> DeleteTodoItemAsync(Guid id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                throw new KeyNotFoundException("Todo item not found.");
            }

            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TodoItemResponse>> GetAllTodoItemsAsync(Guid userId)
        {
            return context.TodoItems.Where(t=>t.UserId == userId).Select(i => new TodoItemResponse
            {
                Id = i.Id,
                UserId = i.UserId,
                Title = i.Title,
                Description = i.Description,
                IsCompleted = i.IsCompleted
            });
        }

        public async Task<TodoItemResponse> GetTodoItemByIdAsync(Guid id, Guid userId)
        {
            var result = await context.TodoItems
                .FirstOrDefaultAsync(i => i.Id == id && i.UserId == userId);

            if (result == null)
            {
                throw new KeyNotFoundException("Todo item not found.");
            }

            return new TodoItemResponse
            {
                Id = result.Id,
                UserId = result.UserId,
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
                throw new KeyNotFoundException("Todo item not found.");
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
