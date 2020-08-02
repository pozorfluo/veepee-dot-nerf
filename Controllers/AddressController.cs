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
  public class AddressController : Controller
  {
    private readonly VeepeeDotNerfContext _context;

    // -------------------------------------------------------------------------
    public AddressController(VeepeeDotNerfContext context)
    {
      _context = context;
    }

    // -------------------------------------------------------------------------
    // GET: Address
    public async Task<IActionResult> Index()
    {
      var veepeeDotNerfContext = _context.Address
        .Include(a => a.client)
        .Include(a => a.country);

      return View(await veepeeDotNerfContext.ToArrayAsync());
    }

    // -------------------------------------------------------------------------
    // GET: Address/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var address = await _context.Address
          .Include(a => a.client)
          .Include(a => a.country)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (address == null)
      {
        return NotFound();
      }

      return View(address);
    }

    // -------------------------------------------------------------------------
    // GET: Address/Create
    public IActionResult Create()
    {
      ViewData["clientForeignKey"] = new SelectList(
        _context.Client, "Id", "email"
      );
      ViewData["countryForeignKey"] = new SelectList(
        _context.Country, "Id", "name"
      );

      return View();
    }

    // -------------------------------------------------------------------------
    // POST: Address/Create
    // @todo Replace scaffolder generated binding
    //       see https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#update-httppost-edit-method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
      [Bind(@"Id,type,firstName,lastName,email,line1,line2,city,zipCode,phone,
              createdAt,updatedAt,countryForeignKey,clientForeignKey")]
      Address address
    )
    {
      if (ModelState.IsValid)
      {
        _context.Add(address);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      ViewData["clientForeignKey"] = new SelectList(
        _context.Client, "Id", "email", address.clientForeignKey
      );
      ViewData["countryForeignKey"] = new SelectList(
        _context.Country, "Id", "name", address.countryForeignKey
      );

      return View(address);
    }

    // -------------------------------------------------------------------------
    // GET: Address/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var address = await _context.Address.FindAsync(id);
      if (address == null)
      {
        return NotFound();
      }

      ViewData["clientForeignKey"] = new SelectList(
        _context.Client, "Id", "email", address.clientForeignKey
      );

      ViewData["countryForeignKey"] = new SelectList(
        _context.Country, "Id", "name", address.countryForeignKey
      );

      return View(address);
    }

    // -------------------------------------------------------------------------
    // POST: Address/Edit/5
    // @todo Replace scaffolder generated binding
    //       see https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#update-httppost-edit-method
    //       see https://rachelappel.com/2014/09/02/use-viewmodels-to-manage-data-amp-organize-code-in-asp-net-mvc-applications/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
      int id,
      [Bind(@"Id,type,firstName,lastName,email,line1,line2,city,zipCode,phone,
              createdAt,updatedAt,countryForeignKey,clientForeignKey")]
      Address address
    )
    {
      if (id != address.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(address);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!AddressExists(address.Id))
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

      ViewData["clientForeignKey"] = new SelectList(
        _context.Client, "Id", "email", address.clientForeignKey
      );
      ViewData["countryForeignKey"] = new SelectList(
        _context.Country, "Id", "name", address.countryForeignKey
      );

      return View(address);
    }

    // -------------------------------------------------------------------------
    // GET: Address/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var address = await _context.Address
          .Include(a => a.client)
          .Include(a => a.country)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (address == null)
      {
        return NotFound();
      }

      return View(address);
    }
    // -------------------------------------------------------------------------
    // POST: Address/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var address = await _context.Address.FindAsync(id);
      _context.Address.Remove(address);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    // -------------------------------------------------------------------------
    private bool AddressExists(int id)
    {
      return _context.Address.Any(e => e.Id == id);
    }
  }
}
