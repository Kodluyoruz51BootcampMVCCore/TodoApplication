using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(); //async
        Task<bool> AddItemAsync(TodoItem item);
    }
}