using JsonParse.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JsonParse.Data
{
    public class ContasDbContext : DbContext
    {
        public ContasDbContext(DbContextOptions<ContasDbContext> options) : base(options) { }

        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>()
                .HasOne<Usuario>(c => c.Usuario)
                .WithMany(u => u.Contas)
                .HasForeignKey(c => c.UsuarioId);

            string dir = System.IO.Directory.GetCurrentDirectory();
            var wc = new WebClient();
            var json = wc.DownloadString(@"https://raw.githubusercontent.com/softcomtecnologia/workwithus_step1/master/contas.json");
            var usuario = JsonConvert.DeserializeObject<Usuario>(json);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { UsuarioId = 1, Nome = usuario.Nome, Email = usuario.Email, Fone = usuario.Fone});

            int ContaId = 1;
            foreach(Conta conta in usuario.Contas)
            {
                conta.ContaId = ContaId++;
                conta.UsuarioId = 1;
                modelBuilder.Entity<Conta>().HasData(conta);
            }
        }
    }
}
