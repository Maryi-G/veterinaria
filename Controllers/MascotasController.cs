using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veterinaria.Data;
using Veterinaria.Models;

namespace veterinaria.Controllers
{
    public class MascotasController : Controller
    {
        private readonly veterinariaContext _context;

        public MascotasController(veterinariaContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Mascotas.ToListAsync();
            return View(lista);
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var mascota = await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mascota == null)
                return NotFound();

            return View(mascota);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mascotas/Create
        [HttpPost]
        public async Task<IActionResult> Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Mascotas.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
                return NotFound();

            return View(mascota);
        }

        // POST: Mascotas/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Mascota mascota)
        {
            if (id != mascota.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
                return NotFound();

            return View(mascota);
        }

        // POST: Mascotas/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);

            if (mascota == null)
                return NotFound();

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
