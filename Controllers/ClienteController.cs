using Microsoft.AspNetCore.Mvc;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteDataAccessLayer clietDataAcessLayer = new ClienteDataAccessLayer();
        public IActionResult Index()
        {
            List<Cliente> clientes = [];
            clientes = clietDataAcessLayer.getAllCliente();
            return View(clientes);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente client)
        {
            if (ModelState.IsValid)
            {
                clietDataAcessLayer.AddClient(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

    }
}
