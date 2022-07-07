using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using avaliacao2.Data;
using avaliacao2.Models;

namespace avaliacao2.Controllers
{
    public class PostagensController : Controller
    {
        private readonly avaliacao2Context _context;

        public PostagensController(avaliacao2Context context)
        {
            _context = context;
        }

        // GET: Postagens
        public async Task<IActionResult> Index()
        {
              return _context.Postagens != null ? 
                          View(await _context.Postagens.ToListAsync()) :
                          Problem("Entity set 'avaliacao2Context.Postagens'  is null.");
        }

        // GET: Postagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postagens == null)
            {
                return NotFound();
            }

            var postagens = await _context.Postagens
                .FirstOrDefaultAsync(m => m.idPost == id);
            if (postagens == null)
            {
                return NotFound();
            }

            return View(postagens);
        }

        // GET: Postagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPost,Titulo,Descricao,DataPostagem")] Postagens postagens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postagens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postagens);
        }

        // GET: Postagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Postagens == null)
            {
                return NotFound();
            }

            var postagens = await _context.Postagens.FindAsync(id);
            if (postagens == null)
            {
                return NotFound();
            }
            return View(postagens);
        }

        // POST: Postagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPost,Titulo,Descricao,DataPostagem")] Postagens postagens)
        {
            if (id != postagens.idPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postagens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostagensExists(postagens.idPost))
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
            return View(postagens);
        }

        // GET: Postagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postagens == null)
            {
                return NotFound();
            }

            var postagens = await _context.Postagens
                .FirstOrDefaultAsync(m => m.idPost == id);
            if (postagens == null)
            {
                return NotFound();
            }

            return View(postagens);
        }

        // POST: Postagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postagens == null)
            {
                return Problem("Entity set 'avaliacao2Context.Postagens'  is null.");
            }
            var postagens = await _context.Postagens.FindAsync(id);
            if (postagens != null)
            {
                _context.Postagens.Remove(postagens);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostagensExists(int id)
        {
          return (_context.Postagens?.Any(e => e.idPost == id)).GetValueOrDefault();
        }
    }
}
