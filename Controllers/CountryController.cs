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
  public class CountryController : Controller
  {
    private readonly VeepeeDotNerfContext _context;
    
    // -------------------------------------------------------------------------
    public CountryController(VeepeeDotNerfContext context)
    {
      _context = context;
    }

    // -------------------------------------------------------------------------
    // GET: Country
    public async Task<IActionResult> Index()
    {
      return View(await _context.Country.ToArrayAsync());
    }
    // -------------------------------------------------------------------------
    // GET: Country/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var country = await _context.Country
          .FirstOrDefaultAsync(m => m.Id == id);
      if (country == null)
      {
        return NotFound();
      }

      return View(country);
    }

    // -------------------------------------------------------------------------
    // GET: Country/Create
    public IActionResult Create()
    {
      return View();
    }

    // -------------------------------------------------------------------------
    // POST: Country/Create
    // @todo Replace scaffolder generated binding
    //       see https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#update-httppost-edit-method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,name")] Country country)
    {
      if (ModelState.IsValid)
      {
        _context.Add(country);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(country);
    }

    // -------------------------------------------------------------------------
    // GET: Country/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var country = await _context.Country.FindAsync(id);
      if (country == null)
      {
        return NotFound();
      }
      return View(country);
    }

    // -------------------------------------------------------------------------
    // POST: Country/Edit/5
    // @todo Replace scaffolder generated binding
    //       see https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#update-httppost-edit-method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
      int id, [Bind("Id,name")] Country country
    )
    {
      if (id != country.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(country);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CountryExists(country.Id))
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
      return View(country);
    }

    // -------------------------------------------------------------------------
    // GET: Country/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var country = await _context.Country
          .FirstOrDefaultAsync(m => m.Id == id);
      if (country == null)
      {
        return NotFound();
      }

      return View(country);
    }

    // -------------------------------------------------------------------------
    // POST: Country/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var country = await _context.Country.FindAsync(id);
      _context.Country.Remove(country);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    // -------------------------------------------------------------------------
    private bool CountryExists(int id)
    {
      return _context.Country.Any(e => e.Id == id);
    }
  }
}
