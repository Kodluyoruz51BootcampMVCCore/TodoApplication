using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApplication.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            // Database'den değerleri getir

            // Gelen değerleri yeni modele koy

            // Modeli Görünyüye ekle ve sayfayı göster.

            ViewBag.Title = "Yapılacaklar Listesini Yönet";
            return View();
        }
    }
}
