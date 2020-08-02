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
  public class OrderController : Controller
  {
    private readonly VeepeeDotNerfContext _context;

    // -------------------------------------------------------------------------
    public OrderController(VeepeeDotNerfContext context)
    {
      _context = context;
    }

    // -------------------------------------------------------------------------
    // GET: Order
    public async Task<IActionResult> Index()
    {
      var veepeeDotNerfContext = _context.Order
        .Include(o => o.client)
        .Include(o => o.product);

      return View(await veepeeDotNerfContext.ToArrayAsync());
    }

    // -------------------------------------------------------------------------
    // GET: Order/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = await _context.Order
          .Include(o => o.client)
          .Include(o => o.product)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (order == null)
      {
        return NotFound();
      }

      return View(order);
    }

    // -------------------------------------------------------------------------
    // GET: Order/Create
    public IActionResult Create()
    {
      ViewData["clientForeignKey"] = new SelectList(
        _context.Client, "Id", "email"
      );
      ViewData["productForeignKey"] = new SelectList(
        _context.Product, "Id", "description"
      );

      return View();
    }

    // -------------------------------------------------------------------------
    // POST: Order/Create
    // @todo Replace scaffolder generated binding
    //       see https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#update-httppost-edit-method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
      [Bind(@"Id,paymentMethod,total,ApiOrderId,status,clientForeignKey,
              productForeignKey")]
      Order order
    )
    {
      if (ModelState.IsValid)
      {
        _context.Add(order);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      ViewData["clientForeignKey"] = new SelectList(
        _context.Client, "Id", "email", order.clientForeignKey
      );
      ViewData["productForeignKey"] = new SelectList(
        _context.Product, "Id", "description", order.productForeignKey
      );

      return View(order);
    }

    // -------------------------------------------------------------------------
    // GET: Order/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = await _context.Order.FindAsync(id);
      if (order == null)
      {
        return NotFound();
      }

      ViewData["clientForeignKey"] = new SelectList(
        _context.Client, "Id", "email",
        order.clientForeignKey
      );
      ViewData["productForeignKey"] = new SelectList(
        _context.Product, "Id", "description",
        order.productForeignKey
      );

      return View(order);
    }

    // -------------------------------------------------------------------------
    // POST: Order/Edit/5
    // @todo Replace scaffolder generated binding
    //       see https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#update-httppost-edit-method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
      int id,
      [Bind(@"Id,paymentMethod,total,ApiOrderId,status,clientForeignKey,
              productForeignKey")]
      Order order
    )
    {
      if (id != order.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(order);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!OrderExists(order.Id))
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
        _context.Client, "Id", "email", order.clientForeignKey
      );
      ViewData["productForeignKey"] = new SelectList(
        _context.Product, "Id", "description", order.productForeignKey
      );

      return View(order);
    }

    // -------------------------------------------------------------------------
    // GET: Order/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = await _context.Order
          .Include(o => o.client)
          .Include(o => o.product)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (order == null)
      {
        return NotFound();
      }

      return View(order);
    }

    // -------------------------------------------------------------------------
    // POST: Order/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var order = await _context.Order.FindAsync(id);
      _context.Order.Remove(order);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    // -------------------------------------------------------------------------
    private bool OrderExists(int id)
    {
      return _context.Order.Any(e => e.Id == id);
    }
  }
}
