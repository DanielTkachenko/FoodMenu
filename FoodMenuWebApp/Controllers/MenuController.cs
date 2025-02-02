using FoodMenuWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuWebApp.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var items = await _context.MenuItems
                    .Where(i => i.Name.Contains(searchString))
                    .ToListAsync();
                return View(items);
            }

            return View(await _context.MenuItems.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.MenuItems
                .Include(i => i.MenuItemIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(i => i.Id == id);
            return View(item);
        }
    }
}
