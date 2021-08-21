using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IMapper _mapper;
        public ClientesController(IClienteAppService clienteAppService, IMapper mapper)
        {
            _clienteAppService = clienteAppService;
            _mapper = mapper;
        }

        // GET: ClientesController
        public ActionResult Index()
        {
            var listaClientesViewModel =
                _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteAppService.GetAll());

            return View(listaClientesViewModel);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = _mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

                _clienteAppService.Add(clienteDomain);
                RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
