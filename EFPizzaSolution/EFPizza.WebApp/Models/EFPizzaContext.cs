using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFPizza.WebApp.Models
{
    public partial class EFPizzaContext : DbContext
    {
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Orgins> Orgins { get; set; }
        public virtual DbSet<PizzaIngredients> PizzaIngredients { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFPizza;Trusted_Connection=True;");
        //}

        public EFPizzaContext(DbContextOptions<EFPizzaContext> options) : base(options)
        {

        }

        public EFPizzaContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orgins>(entity =>
            {
                entity.HasIndex(e => e.PizzaId)
                    .HasName("IX_Orgins_PizzaId")
                    .IsUnique();

                entity.HasOne(d => d.Pizza)
                    .WithOne(p => p.Orgins)
                    .HasForeignKey<Orgins>(d => d.PizzaId);
            });

            modelBuilder.Entity<PizzaIngredients>(entity =>
            {
                entity.HasIndex(e => e.IngredientId)
                    .HasName("IX_PizzaIngredients_IngredientId");

                entity.HasIndex(e => e.PizzaId)
                    .HasName("IX_PizzaIngredients_PizzaId");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.IngredientId);

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.PizzaId);
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.Property(e => e.Prize).HasColumnType("decimal");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasIndex(e => e.PizzaId)
                    .HasName("IX_Reviews_PizzaId");

                entity.Property(e => e.Date).HasDefaultValueSql("'0001-01-01T00:00:00.000'");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PizzaId);
            });
        }
    }
}