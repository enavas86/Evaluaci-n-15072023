using Microsoft.AspNetCore.Mvc;
using webAppClientes.Data;
using webAppClientes.Models;

namespace webAppClientes.Controllers
{
    public class ClienteController : Controller
    {
        CRUDCliente _Cliente = new CRUDCliente();

        public IActionResult ListaCliente()
        {
            List<ClienteModel> oLista = _Cliente.ListaCliente();
            return View(oLista);
        }

        public IActionResult GuardarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarCliente(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();

            bool _respuesta = _Cliente.GuardarCliente(oCliente);

            if (_respuesta)
                return RedirectToAction("ListaCliente");
            else
                return View();
        }

        public IActionResult EditarCliente(int id)
        {
            ClienteModel oCliente = _Cliente.ObtenerCliente(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult EditarCliente(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();

            bool _respuesta = _Cliente.ActualizarCliente(oCliente);

            if (_respuesta)
                return RedirectToAction("ListaCliente");
            else
                return View();
        }

        public IActionResult EliminarCliente(int id)
        {
            ClienteModel oCliente = _Cliente.ObtenerCliente(id);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult EliminarCliente(ClienteModel oCliente)
        {
            bool _respuesta = _Cliente.EliminarCliente(oCliente.Id);

            if (_respuesta)
                return RedirectToAction("ListaCliente");
            else
                return View();
        }
    }
}
