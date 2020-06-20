using System.Collections.Generic;
using TodoApplication.Data;

namespace TodoApplication.Models
{
    public class TodoViewModel //MVC -> MVVM
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}
