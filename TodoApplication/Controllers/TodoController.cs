using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Models;
using TodoApplication.Services;

namespace TodoApplication.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService service;

        public TodoController(ITodoItemService _service) //constructor based dependency injection (constructor injection)
        {
            service = _service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            // Database'den değerleri getir
            //IEnumerable<TodoItem> items = service.GetIncompleteItemsAsync().Result;
            IEnumerable<TodoItem> items = await service.GetIncompleteItemsAsync();

            // Gelen değerleri yeni modele koy
            TodoViewModel vm = new TodoViewModel(); //design decision
            vm.Items = items;

            ViewBag.Title = "Yapılacaklar Listesini Yönet";

            // Modeli Görünyüye ekle ve sayfayı göster.
            return View(vm);
        }
    }
}