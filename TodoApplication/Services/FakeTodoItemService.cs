using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        private readonly TodoDbContext _context;

        public FakeTodoItemService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem item)
        {
            var entity = new TodoItem
            {
                Id = Guid.NewGuid(),
                IsDone = false,
                Title = "Fake service title",
                DueAt = DateTimeOffset.Now.AddDays(3)
            };

            _context.TodoItems.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            IEnumerable<TodoItem> items = new[]
            {
                new TodoItem //object initializer
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new TodoItem
                {
                    Title = "Build awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }
            };

            return Task.FromResult(items);
        }
    }
}
