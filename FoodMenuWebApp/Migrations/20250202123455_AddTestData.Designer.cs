﻿// <auto-generated />
using FoodMenuWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodMenuWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250202123455_AddTestData")]
    partial class AddTestData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoodMenuWebApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tomato"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Basil"
                        });
                });

            modelBuilder.Entity("FoodMenuWebApp.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://the-cafe.ru/wp-content/uploads/2020/11/523c10a1-464d-41ad-9d28-f414a009ae22.jpg",
                            Name = "Pepperoni",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://the-cafe.ru/wp-content/uploads/2020/11/147c3814bbb34a77afdbc66e9ef20ed7_584x584.jpeg",
                            Name = "Margherite",
                            Price = 5.0
                        });
                });

            modelBuilder.Entity("FoodMenuWebApp.Models.MenuItemIngredient", b =>
                {
                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.HasKey("MenuItemId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("MenuItemIngredients");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            IngredientId = 1
                        },
                        new
                        {
                            MenuItemId = 1,
                            IngredientId = 2
                        },
                        new
                        {
                            MenuItemId = 1,
                            IngredientId = 3
                        },
                        new
                        {
                            MenuItemId = 2,
                            IngredientId = 2
                        },
                        new
                        {
                            MenuItemId = 2,
                            IngredientId = 3
                        },
                        new
                        {
                            MenuItemId = 2,
                            IngredientId = 4
                        });
                });

            modelBuilder.Entity("FoodMenuWebApp.Models.MenuItemIngredient", b =>
                {
                    b.HasOne("FoodMenuWebApp.Models.Ingredient", "Ingredient")
                        .WithMany("MenuItemIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodMenuWebApp.Models.MenuItem", "MenuItem")
                        .WithMany("MenuItemIngredients")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("FoodMenuWebApp.Models.Ingredient", b =>
                {
                    b.Navigation("MenuItemIngredients");
                });

            modelBuilder.Entity("FoodMenuWebApp.Models.MenuItem", b =>
                {
                    b.Navigation("MenuItemIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
