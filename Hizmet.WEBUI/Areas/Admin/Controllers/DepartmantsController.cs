using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hizmet.Core.Entities;
using Hizmet.Data;

using Hizmet.WEBUI.Models;

namespace Hizmet.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmantsController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmantsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Departmants
        public async Task<IActionResult> Index()
        {
            var departmants=await _context.Departmants.Select
                (d=> new DepartmantViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    IsActive = d.IsActive,
                    IsTopDepartmant = d.IsTopDepartmant,
                    ParentName = d.ParentId != null ? _context.Departmants
                    .Where(p => p.Id == d.ParentId)
                    .Select(p => p.Name)
                    .FirstOrDefault() ?? "Yok" : "Yok"
                }).ToListAsync();
               
            //return View(await _context.Departmants.ToListAsync());

 
              return View(departmants);
        }

        // GET: Admin/Departmants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var departmant = await _context.Departmants
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (departmant == null)
            //{
            //    return NotFound();
            //} 

            //return View(departmant );    

            var departmant = await _context.Departmants
                .Where(d => d.Id == id)
                .Select(d => new DepartmantViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    IsActive = d.IsActive,
                    IsTopDepartmant = d.IsTopDepartmant,
                    ParentName = d.ParentId != null ? _context.Departmants
                        .Where(p => p.Id == d.ParentId)
                        .Select(p => p.Name)
                        .FirstOrDefault() ?? "Yok" : "Yok"
                })
                .FirstOrDefaultAsync();

            if (departmant == null)
            {
                return NotFound();
            }

            return View(departmant);

       
        }

        // GET: Admin/Departmants/Create
        public IActionResult Create()
        {
            ViewBag.Departmants = new SelectList(_context.Departmants, "Id", "Name");//_context.Departmants.ToList();    

            return View();
        }

        // POST: Admin/Departmants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsActive,IsTopDepartmant,ParentId")] Departmant departmant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departmants = new SelectList(_context.Departmants, "Id", "Name");//_context.Departmants.ToList();    

            return View(departmant);
        }

        // GET: Admin/Departmants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmant = await _context.Departmants.FindAsync(id);
            if (departmant == null)
            {
                return NotFound();
            }
            ViewBag.Departmants = new SelectList(_context.Departmants, "Id", "Name");//_context.Departmants.ToList();    
            return View(departmant);
        }

        // POST: Admin/Departmants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsActive,IsTopDepartmant,ParentId")] Departmant departmant)
        {
            if (id != departmant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmantExists(departmant.Id))
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
            ViewBag.Departmants = new SelectList(_context.Departmants, "Id", "Name");//_context.Departmants.ToList();    

            return View(departmant);
        }

        // GET: Admin/Departmants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmant = await _context.Departmants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmant == null)
            {
                return NotFound();
            }

            return View(departmant);
        }

        // POST: Admin/Departmants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmant = await _context.Departmants.FindAsync(id);
            if (departmant != null)
            {
                _context.Departmants.Remove(departmant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmantExists(int id)
        {
            return _context.Departmants.Any(e => e.Id == id);
        }
    }
}
