using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Models;
using TodoApplication.Services;
using TodoApplication.Utilities.Loggers;
using TodoApplication.Data;
using System;

namespace TodoApplication.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _service;
        private readonly IKodluyoruzLogger _logger;

        public TodoController(ITodoItemService service, IKodluyoruzLogger logger) //constructor based dependency injection (constructor injection)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet] //Attribute
        public async Task<IActionResult> Index()
        {
            // Database'den değerleri getir
            //IEnumerable<TodoItem> items = service.GetIncompleteItemsAsync().Result;
            IEnumerable<TodoItem> items = await _service.GetIncompleteItemsAsync();

            // Gelen değerleri yeni modele koy
            TodoViewModel vm = new TodoViewModel(); //design decision
            vm.Items = items;

            ViewBag.Title = "Yapılacaklar Listesini Yönet";

            // Modeli Görünyüye ekle ve sayfayı göster.
            //logger.Write();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(TodoItem item)
        {
            bool x = TryValidateModel(item);

            if (!ModelState.IsValid) //if(TryValidateModel(item))
            {
                return BadRequest(ModelState);
            }

            var result = await _service.AddItemAsync(item); //TODO: Geri dönen bilgiye göre yeşil renkte onay mesajı gösterilmesi.
            if (!result)
            {
                return BadRequest(new { error = "Eklenemedi." });
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var successful = await _service.MarkDoneAsync(id);

            if (!successful) return BadRequest();

            return Ok();
        }
    }
}