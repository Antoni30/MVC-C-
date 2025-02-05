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
    }
}
