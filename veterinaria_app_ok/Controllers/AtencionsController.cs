using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using veterinaria_app_ok.Data;
using veterinaria_app_ok.Models;

namespace veterinaria_app_ok.Controllers
{
    [Authorize]
    public class AtencionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtencionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atencions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Atenciones
                .Include(a => a.Mascota)
                .Include(a => a.Usuario);  // carga también al usuario relacionado

            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Atencions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atenciones
                .Include(a => a.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // GET: Atencions/Create
        // GET: Atencions/Create
        public IActionResult Create()
        {
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Name");
            ViewData["Servicios"] = new SelectList(_context.Servicios, "Id", "Nombre"); // CORREGIDO
            return View();
        }


        // POST: Atencions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Observaciones,MascotaId")] Atencion atencion, List<int> Servicios)
        {
            if (ModelState.IsValid)
            {
                atencion.Fecha = DateTime.Now;

                // Obtener los servicios seleccionados
                var serviciosSeleccionados = await _context.Servicios.Where(s => Servicios.Contains(s.Id)).ToListAsync();

                // Asignar servicios y calcular total
                atencion.Servicios = serviciosSeleccionados;
                atencion.Total = serviciosSeleccionados.Sum(s => s.Precio);

                // Asignar usuario
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                atencion.UserId = userId;

                _context.Add(atencion);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Name", atencion.MascotaId);
            ViewData["Servicios"] = new SelectList(_context.Servicios, "Id", "Nombre");
            return View(atencion);
        }


        // GET: Atencions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atenciones.FindAsync(id);
            if (atencion == null)
            {
                return NotFound();
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Name", atencion.MascotaId);
            return View(atencion);
        }

        // POST: Atencions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Observaciones,Total,MascotaId,UserId")] Atencion atencion)
        {
            if (id != atencion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atencion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtencionExists(atencion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Celular", atencion.MascotaId);
            return View(atencion);
        }

        // GET: Atencions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencion = await _context.Atenciones
                .Include(a => a.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atencion == null)
            {
                return NotFound();
            }

            return View(atencion);
        }

        // POST: Atencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atencion = await _context.Atenciones.FindAsync(id);
            if (atencion != null)
            {
                _context.Atenciones.Remove(atencion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtencionExists(int id)
        {
            return _context.Atenciones.Any(e => e.Id == id);
        }
    }
}
