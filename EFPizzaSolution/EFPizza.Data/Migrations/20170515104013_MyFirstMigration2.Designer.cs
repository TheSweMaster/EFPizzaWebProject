using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFPizza.Data;

namespace EFPizza.Data.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20170515104013_MyFirstMigration2")]
    partial class MyFirstMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("EFPizza.Domain.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Grade");

                    b.Property<int>("PizzaId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("Reviews");
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
