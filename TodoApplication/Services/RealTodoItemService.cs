using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync()
        {
            var items = await _context.TodoItems.Where(x => x.IsDone == false).ToArrayAsync();

            return items;
        }
    }
}
