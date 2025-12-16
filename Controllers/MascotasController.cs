using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veterinaria.Data;
using Veterinaria.Models;

namespace veterinaria.Controllers
{
    [Authorize]
    public class MascotasController : Controller
    {
        private readonly veterinariaContext _context;

        public MascotasController(veterinariaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Mascotas.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var mascota = await _context.Mascotas.FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null) return NotFound();
            return View(mascota);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Mascota mascota)
        {
            if (!ModelState.IsValid)
                return View(mascota);

            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null) return NotFound();
            return View(mascota);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Mascota mascota)
        {
            if (id != mascota.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(mascota);

            _context.Update(mascota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null) return NotFound();
            return View(mascota);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null) return NotFound();

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
