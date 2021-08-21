using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IMapper _mapper;
        public PedidosController(IPedidoAppService pedidoAppService, IMapper mapper)
        {
            _pedidoAppService = pedidoAppService;
            _mapper = mapper;
        }
        public IActionResult Index()     
        {
            var a = _pedidoAppService.GetPedidosFromIndex();

            IEnumerable<PedidoViewModel> listaPedidos =
                _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoAppService.GetPedidosFromIndex());

            return View(listaPedidos);
        }
    }
}
