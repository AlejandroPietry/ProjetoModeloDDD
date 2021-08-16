using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext(DbContextOptions<ProjetoModeloContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
