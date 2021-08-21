using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext(DbContextOptions<ProjetoModeloContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }
            return base.SaveChanges();
        }
    }
}
