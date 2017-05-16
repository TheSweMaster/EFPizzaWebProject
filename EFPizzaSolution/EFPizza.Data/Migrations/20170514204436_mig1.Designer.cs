using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFPizza.Data;
using EFPizza.Domain;

namespace EFPizza.Data.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20170514204436_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFPizza.Domain.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Gluten");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("EFPizza.Domain.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Date");

                    b.Property<int>("PizzaId");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId")
                        .IsUnique();

                    b.ToTable("Orgins");
                });

            modelBuilder.Entity("EFPizza.Domain.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Prize");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("EFPizza.Domain.PizzaIngredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IngredientId");

                    b.Property<int>("PizzaId");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaIngredients");
                });

            modelBuilder.Entity("EFPizza.Domain.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("Grade");

                    b.Property<int>("PizzaId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("EFPizza.Domain.Origin", b =>
                {
                    b.HasOne("EFPizza.Domain.Pizza", "Pizza")
                        .WithOne("Origin")
                        .HasForeignKey("EFPizza.Domain.Origin", "PizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFPizza.Domain.PizzaIngredients", b =>
                {
                    b.HasOne("EFPizza.Domain.Ingredient", "Ingredients")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFPizza.Domain.Pizza", "Pizzas")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFPizza.Domain.Review", b =>
                {
                    b.HasOne("EFPizza.Domain.Pizza", "Pizzas")
                        .WithMany("Reviews")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
