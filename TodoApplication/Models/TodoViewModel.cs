using System.Collections.Generic;

namespace TodoApplication.Models
{
    public class TodoViewModel //MVC -> MVVM
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}
