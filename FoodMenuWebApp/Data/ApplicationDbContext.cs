using Microsoft.EntityFrameworkCore;
using FoodMenuWebApp.Models;

namespace FoodMenuWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set many to many relationshop between MenuItem and Ingredient
            modelBuilder.Entity<MenuItemIngredient>()
                .HasKey(mi => new { mi.MenuItemId, mi.IngredientId });
            modelBuilder.Entity<MenuItemIngredient>().HasOne(mi => mi.MenuItem)
                .WithMany(m => m.MenuItemIngredients)
                .HasForeignKey(mi => mi.MenuItemId);
            modelBuilder.Entity<MenuItemIngredient>().HasOne(mi => mi.Ingredient)
                .WithMany(i => i.MenuItemIngredients)
                .HasForeignKey(mi => mi.IngredientId);
            
            AddTestData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuItemIngredient> MenuItemIngredients { get; set; }

        private static void AddTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasData(
                            new MenuItem { Id = 1, Name = "Pepperoni", Price = 10.0, ImageUrl = "https://the-cafe.ru/wp-content/uploads/2020/11/523c10a1-464d-41ad-9d28-f414a009ae22.jpg" },
                            new MenuItem { Id = 2, Name = "Margherite", Price = 5.0, ImageUrl = "https://the-cafe.ru/wp-content/uploads/2020/11/147c3814bbb34a77afdbc66e9ef20ed7_584x584.jpeg" }
                        );

            modelBuilder.Entity<Ingredient>().HasData(
                    new Ingredient { Id = 1, Name = "Pepperoni" },
                    new Ingredient { Id = 2, Name = "Cheese" },
                    new Ingredient { Id = 3, Name = "Tomato" },
                    new Ingredient { Id = 4, Name = "Basil" }
                );
            modelBuilder.Entity<MenuItemIngredient>().HasData(
                new MenuItemIngredient { MenuItemId = 1, IngredientId = 1 },
                new MenuItemIngredient { MenuItemId = 1, IngredientId = 2 },
                new MenuItemIngredient { MenuItemId = 1, IngredientId = 3 },
                new MenuItemIngredient { MenuItemId = 2, IngredientId = 2 },
                new MenuItemIngredient { MenuItemId = 2, IngredientId = 3 },
                new MenuItemIngredient { MenuItemId = 2, IngredientId = 4 }
            );
        }
    }
}
