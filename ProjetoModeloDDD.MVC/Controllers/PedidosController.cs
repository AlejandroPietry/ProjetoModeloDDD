using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC.Controllers
{
    [Route("pedidos")]
    public class PedidosController : Controller
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IMapper _mapper;
        public PedidosController(IPedidoAppService pedidoAppService, IMapper mapper)
        {
            _pedidoAppService = pedidoAppService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()     
        {
            IEnumerable<PedidoViewModel> listaPedidos =
                _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoAppService.GetPedidosFromIndex());

            return View(listaPedidos);
        }
        [HttpGet, Route("criar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("criar")]
        public IActionResult Create(PedidoViewModel pedidoViewModel)
        {
            var pedidoDomain = _mapper.Map<PedidoViewModel, Pedido>(pedidoViewModel);
            _pedidoAppService.Add(pedidoDomain);
            TempData["alertaSucessoNoEnvio"] = "Salvo com sucesso";
            return RedirectToAction("Index");

        }
        [HttpGet, Route("add/{index}")]
        public IActionResult Add(int index)
        {
            return PartialView("_EmptyRow", new ProdutoViewModel { Index = index, Nome = "Pao de pedra" });
        }
    }
}
