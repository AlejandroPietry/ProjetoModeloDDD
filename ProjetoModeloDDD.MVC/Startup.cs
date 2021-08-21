using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoModeloDDD.Application;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositorios;
using ProjetoModeloDDD.Domain.Interfaces.Servicos;
using ProjetoModeloDDD.Domain.Services;
using ProjetoModeloDDD.Infra.Data.Context;
using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.MVC.AutoMapper;
using System.Collections.Generic;

namespace ProjetoModeloDDD.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjetoModeloContext>(options => options.UseInMemoryDatabase("testez"));
            services.AddControllersWithViews();

            //injecao de dependencia
            services.AddTransient(typeof(IClienteAppService), typeof(ClienteAppService));
            services.AddTransient(typeof(IProdutoAppService), typeof(ProdutoAppService));
            services.AddTransient(typeof(IPedidoAppService), typeof(PedidoAppService));
            services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));

            services.AddTransient(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddTransient(typeof(IProdutoRepository), typeof(ProdutoRepository));
            services.AddTransient(typeof(IPedidoRepository), typeof(PedidoRepository));
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddTransient(typeof(IClienteService), typeof(ClienteService));
            services.AddTransient(typeof(IProdutoService), typeof(ProdutoService));
            services.AddTransient(typeof(IPedidoService), typeof(PedidoService));
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using(var scope  = serviceScopeFactory.CreateScope())
            {
                var handler = scope.ServiceProvider.GetService<ProjetoModeloContext>();
                AdicionarDadosTeste(handler);

            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void AdicionarDadosTeste(ProjetoModeloContext context)
        {
            var produto = new Produto
            {
                Disponivel = true,
                Nome = "Pão",
                Valor = 2
            };
            context.Produtos.Add(produto);

            var listProduto = new List<Produto>();
            listProduto.Add(produto);

            var cliente = new Cliente
            {
                Nome = "Joao",
                SobreNome = "Silva",
                Email = "Joaozinhohotwells@gmail.com",
                Ativo = true
            };

            context.Clientes.Add(cliente);
            var pedido = new Pedido
            {
                StatusPagamento = Domain.Enums.StatusPagamento.EmProcessamento,
                Produtos = listProduto,
                Cliente = cliente,
                DetalhesPedido = "Cliente vem buscar entre as 15h - 17h",
                ValorTotal = 2
            };

            context.Pedidos.Add(pedido);
            context.SaveChanges();
        }
    }
}
