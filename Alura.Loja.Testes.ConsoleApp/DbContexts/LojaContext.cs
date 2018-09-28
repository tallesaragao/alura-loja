using Alura.Loja.Testes.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp.DbContexts
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }

        private bool disposed = false;

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>().HasOne(c => c.Produto).WithMany().IsRequired();

            modelBuilder.Entity<PromocaoProduto>()
                .HasKey(promocaoProduto => new { promocaoProduto.PromocaoId, promocaoProduto.ProdutoId });

            modelBuilder.Entity<PromocaoProduto>()
                .HasOne(promocaoProduto => promocaoProduto.Produto)
                .WithMany(promocao => promocao.PromocoesProdutos)
                .HasForeignKey(promocaoProduto => promocaoProduto.ProdutoId)
                .IsRequired();

            modelBuilder.Entity<PromocaoProduto>()
                .HasOne(promocaoProduto => promocaoProduto.Promocao)
                .WithMany(promocao => promocao.PromocoesProdutos)
                .HasForeignKey(promocaoProduto => promocaoProduto.PromocaoId)
                .IsRequired();
                
        }

        public bool IsDisposed()
        {
            return disposed;
        }

        public override void Dispose()
        {
            base.Dispose();
            disposed = true;
        }
    }
}