using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(); //async
    }
}