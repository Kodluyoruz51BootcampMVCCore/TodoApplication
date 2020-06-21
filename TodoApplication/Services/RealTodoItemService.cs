using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public class RealTodoItemService : ITodoItemService
    {
        //TODO: DBContext bağımlılığı giderilecek. Teknik Borç (Technical Debt) (TAMAMLANDI)
        private readonly TodoDbContext _context;

        public RealTodoItemService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem item)
        {
            var entity = new TodoItem
            {
                Id = Guid.NewGuid(),
                IsDone = false,
                Title = item.Title,
                DueAt = DateTimeOffset.Now.AddDays(3) //TODO: view'a eklenecek
            };

            _context.TodoItems.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            var items = await _context.TodoItems.Where(x => x.IsDone == false).ToListAsync();

            return items;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.TodoItems.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}
