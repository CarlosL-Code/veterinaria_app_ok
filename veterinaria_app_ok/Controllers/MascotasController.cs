using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using veterinaria_app_ok.Data;
using veterinaria_app_ok.Models;

namespace veterinaria_app_ok.Controllers
{
    [Authorize]
    public class MascotasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MascotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            ViewData["AppName"] = "Mascota";

            var mascotas = _context.Mascotas.Include(m => m.Categoria);
            var categorias = await _context.Categorias.Where(c => c.IsCategoria).ToListAsync();

            ViewBag.Categorias = categorias;

            return View(await mascotas.ToListAsync());
        }


        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias.Where(c=> c.IsCategoria), "Id", "Name");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mascota mascota, IFormFile AvatarFile)
        {
            if (ModelState.IsValid)
            {
                // Si se subió una imagen
                if (AvatarFile != null && AvatarFile.Length > 0)
                {
                    var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(AvatarFile.FileName);
                    var filePath = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await AvatarFile.CopyToAsync(stream);
                    }

                    mascota.AvatarPath = "/img/" + fileName;
                }

                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias.Where(c => c.IsCategoria), "Id", "Name", mascota.CategoriaId);
            return View(mascota);
        }


        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias.Where(c => c.IsCategoria), "Id", "Name", mascota.CategoriaId);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mascota mascota, IFormFile AvatarFile)
        {
            if (id != mascota.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener mascota existente
                    var mascotaExistente = await _context.Mascotas.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                    if (mascotaExistente == null)
                        return NotFound();

                    // Si se subió nueva imagen
                    if (AvatarFile != null && AvatarFile.Length > 0)
                    {
                        var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(AvatarFile.FileName);
                        var filePath = Path.Combine(folder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await AvatarFile.CopyToAsync(stream);
                        }

                        mascota.AvatarPath = "/img/" + fileName;
                    }
                    else
                    {
                        // Mantener imagen anterior si no se sube nueva
                        mascota.AvatarPath = mascotaExistente.AvatarPath;
                    }

                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.Id))
                        return NotFound();
                    else
                        throw;
                }
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias.Where(c => c.IsCategoria), "Id", "Name", mascota.CategoriaId);
            return View(mascota);
        }


        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.Id == id);
        }
    }
}
