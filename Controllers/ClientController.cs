using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeepeeDotNerf.Data;
using VeepeeDotNerf.Models;

namespace veepee_dot_nerf.Controllers
{
  public class ClientController : Controller
  {
    private readonly VeepeeDotNerfContext _context;

    // -------------------------------------------------------------------------
    public ClientController(VeepeeDotNerfContext context)
    {
      _context = context;
    }

    // -------------------------------------------------------------------------
    // GET: Client
    public async Task<IActionResult> Index()
    {
      return View(await _context.Client.ToArrayAsync());
    }

    // -------------------------------------------------------------------------
    // GET: Client/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var client = await _context.Client
          .FirstOrDefaultAsync(m => m.Id == id);
      if (client == null)
      {
        return NotFound();
      }

      return View(client);
    }

    // -------------------------------------------------------------------------
    // GET: Client/Create
    public IActionResult Create()
    {
      return View();
    }

    // -------------------------------------------------------------------------
    // POST: Client/Create
    // To protect from overposting attacks, enable the specific properties you 
    // want to bind to, for more details, 
    // see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
      [Bind("Id,email,createdAt,updatedAt")] Client client
    )
    {
      if (ModelState.IsValid)
      {
        _context.Add(client);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(client);
    }

    // -------------------------------------------------------------------------
    // GET: Client/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var client = await _context.Client.FindAsync(id);
      if (client == null)
      {
        return NotFound();
      }
      return View(client);
    }

    // -------------------------------------------------------------------------
    // POST: Client/Edit/5
    // To protect from overposting attacks, enable the specific properties you 
    // want to bind to, for more details, 
    // see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
      int id,
      [Bind("Id,email,createdAt,updatedAt")] Client client)
    {
      if (id != client.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(client);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ClientExists(client.Id))
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
      return View(client);
    }

    // -------------------------------------------------------------------------
    // GET: Client/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var client = await _context.Client
          .FirstOrDefaultAsync(m => m.Id == id);
      if (client == null)
      {
        return NotFound();
      }

      return View(client);
    }
    // -------------------------------------------------------------------------
    // POST: Client/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var client = await _context.Client.FindAsync(id);
      _context.Client.Remove(client);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    // -------------------------------------------------------------------------
    private bool ClientExists(int id)
    {
      return _context.Client.Any(e => e.Id == id);
    }
  }
}
