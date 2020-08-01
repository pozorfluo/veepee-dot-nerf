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
  public class Coffee { }
  public class Egg { }
  public class Bacon { }
  public class Toast { }
  public class Juice { }

  public class AddressController : Controller
  {
    private readonly VeepeeDotNerfContext _context;

    public AddressController(VeepeeDotNerfContext context)
    {
      _context = context;
    }

    // GET: Address
    public async Task<IActionResult> Index()
    {
      var stopwatch = new System.Diagnostics.Stopwatch();
      Console.WriteLine("/* ---------------------------------------------------------------------*/");
      stopwatch.Reset();
		  stopwatch.Start();

      Console.WriteLine("Morning's here !");

      Coffee cup = PourCoffee();
      Console.WriteLine("coffee is ready");

      Egg eggs = FryEggs(2);
      Console.WriteLine("eggs are ready");

      Bacon bacon = FryBacon(3);
      Console.WriteLine("bacon is ready");

      Toast toast = ToastBread(2);
      ApplyButter(toast);
      ApplyJam(toast);
      Console.WriteLine("toast is ready");

      Juice oj = PourOJ();
      Console.WriteLine("oj is ready");
      Console.WriteLine("Breakfast is ready!");
      Console.WriteLine(stopwatch.Elapsed);
      Console.WriteLine("/* ---------------------------------------------------------------------*/");
      stopwatch.Reset();
		  stopwatch.Start();
      
      Console.WriteLine("Naive Async Morning's here !");
      Coffee acup = PourCoffee();
      Console.WriteLine("coffee is ready");

      Egg aeggs = await FryEggsAsync(2);
      Console.WriteLine("eggs are ready");

      Bacon abacon = await FryBaconAsync(3);
      Console.WriteLine("bacon is ready");

      Toast atoast = await ToastBreadAsync(2);
      ApplyButter(atoast);
      ApplyJam(atoast);
      Console.WriteLine("toast is ready");

      Juice aoj = PourOJ();
      Console.WriteLine("oj is ready");
      Console.WriteLine("Breakfast is ready!");
      Console.WriteLine(stopwatch.Elapsed);
      Console.WriteLine("/* ---------------------------------------------------------------------*/");

      stopwatch.Reset();
		  stopwatch.Start();
      Console.WriteLine("Async Morning's here !");
      Coffee bcup = PourCoffee();
      Console.WriteLine("coffee is ready");

      Task<Egg> eggsTask = FryEggsAsync(2);
      Task<Bacon> baconTask = FryBaconAsync(3);


      Task<Toast> toastTask = ToastBreadAsync(2);
      Toast btoast = await toastTask;
      ApplyButter(atoast);
      ApplyJam(atoast);
      Console.WriteLine("toast is ready");

      Juice boj = PourOJ();
      Console.WriteLine("oj is ready");

      Egg beggs = await eggsTask;
      Console.WriteLine("eggs are ready");
      Bacon bbacon = await baconTask;
      Console.WriteLine("bacon is ready");

      Console.WriteLine("Breakfast is ready!");
      Console.WriteLine(stopwatch.Elapsed);
      Console.WriteLine("/* ---------------------------------------------------------------------*/");

      stopwatch.Reset();
		  stopwatch.Start();
      Console.WriteLine("Async Composition Morning's here !");
      Coffee ccup = PourCoffee();
      Console.WriteLine("coffee is ready");

      var beggsTask = FryEggsAsync(2);
      var bbaconTask = FryBaconAsync(3);
      var btoastTask = MakeToastsAsync(2);

      var ctoast = await btoastTask;
      Console.WriteLine("toast is ready");
      var ceggs = await beggsTask;
      Console.WriteLine("eggs are ready");
      var cbacon = await bbaconTask;
      Console.WriteLine("bacon is ready");
      
      var coj = PourOJ();
      Console.WriteLine("oj is ready");
      Console.WriteLine("Breakfast is ready!");
      Console.WriteLine(stopwatch.Elapsed);
      Console.WriteLine("/* ---------------------------------------------------------------------*/");

      stopwatch.Reset();
		  stopwatch.Start();
      Console.WriteLine("WhenAll Async Composition Morning's here !");
      Coffee dcup = PourCoffee();
      Console.WriteLine("coffee is ready");

      var ceggsTask = FryEggsAsync(2);
      var cbaconTask = FryBaconAsync(3);
      var ctoastTask = MakeToastsAsync(2);

      await Task.WhenAll(ctoastTask, ceggsTask, cbaconTask);
      var dtoast = await ctoastTask;
      var deggs = await ceggsTask;
      var dbacon = await cbaconTask;
      Console.WriteLine("toast is ready");
      Console.WriteLine("eggs are ready");
      Console.WriteLine("bacon is ready");
      
      var doj = PourOJ();
      Console.WriteLine("oj is ready");
      Console.WriteLine("Breakfast is ready!");
      Console.WriteLine(stopwatch.Elapsed);
      Console.WriteLine("/* ---------------------------------------------------------------------*/");

      stopwatch.Reset();
		  stopwatch.Start();
      Console.WriteLine("WhenAny Async Composition Morning's here !");
      Coffee ecup = PourCoffee();
      Console.WriteLine("coffee is ready");

      var deggsTask = FryEggsAsync(2);
      var dbaconTask = FryBaconAsync(3);
      var dtoastTask = MakeToastsAsync(2);

      var breakfastTasks = new List<Task> { deggsTask, dbaconTask, dtoastTask};

      while (breakfastTasks.Count > 0)
      {
        Task doneTask = await Task.WhenAny(breakfastTasks);
        if (doneTask == deggsTask) {Console.WriteLine("eggs are ready");}
        if (doneTask == dtoastTask) {Console.WriteLine("toast is ready");}
        if (doneTask == dbaconTask) {Console.WriteLine("bacon is ready");}
        breakfastTasks.Remove(doneTask);
      }

      var etoast = await dtoastTask;
      var eeggs = await deggsTask;
      var ebacon = await dbaconTask;
      
      var eoj = PourOJ();
      Console.WriteLine("oj is ready");
      Console.WriteLine("Breakfast is ready!");
      Console.WriteLine(stopwatch.Elapsed);
      Console.WriteLine("/* ---------------------------------------------------------------------*/");

      return View(await _context.Address.ToArrayAsync());
    }

    private static Juice PourOJ()
    {
      Console.WriteLine("Pouring orange juice");
      return new Juice();
    }

    private static void ApplyJam(Toast toast) =>
        Console.WriteLine("Putting jam on the toast");

    private static void ApplyButter(Toast toast) =>
        Console.WriteLine("Putting butter on the toast");

    private static Toast ToastBread(int slices)
    {
      for (int slice = 0; slice < slices; slice++)
      {
        Console.WriteLine("Putting a slice of bread in the toaster");
      }
      Console.WriteLine("Start toasting...");
      Task.Delay(3000).Wait();
      Console.WriteLine("Remove toast from toaster");

      return new Toast();
    }

    private static async Task<Toast> ToastBreadAsync(int slices)
    {
      for (int slice = 0; slice < slices; slice++)
      {
        Console.WriteLine("Putting a slice of bread in the toaster");
      }
      Console.WriteLine("Start toasting...");
      await Task.Delay(3000);
      Console.WriteLine("Remove toast from toaster");

      return new Toast();
    }

    private static async Task<Toast> MakeToastsAsync(int count)
    {
      var toast = await ToastBreadAsync(count);
      ApplyButter(toast);
      ApplyJam(toast);

      return toast;
    }

    private static Bacon FryBacon(int slices)
    {
      Console.WriteLine($"putting {slices} slices of bacon in the pan");
      Console.WriteLine("cooking first side of bacon...");
      Task.Delay(3000).Wait();
      for (int slice = 0; slice < slices; slice++)
      {
        Console.WriteLine("flipping a slice of bacon");
      }
      Console.WriteLine("cooking the second side of bacon...");
      Task.Delay(3000).Wait();
      Console.WriteLine("Put bacon on plate");

      return new Bacon();
    }

    private static async Task<Bacon> FryBaconAsync(int slices)
    {
      Console.WriteLine($"putting {slices} slices of bacon in the pan");
      Console.WriteLine("cooking first side of bacon...");
      await Task.Delay(3000);
      for (int slice = 0; slice < slices; slice++)
      {
        Console.WriteLine("flipping a slice of bacon");
      }
      Console.WriteLine("cooking the second side of bacon...");
      await Task.Delay(3000);
      Console.WriteLine("Put bacon on plate");

      return new Bacon();
    }

    private static Egg FryEggs(int howMany)
    {
      Console.WriteLine("Warming the egg pan...");
      Task.Delay(3000).Wait();
      Console.WriteLine($"cracking {howMany} eggs");
      Console.WriteLine("cooking the eggs ...");
      Task.Delay(3000).Wait();
      Console.WriteLine("Put eggs on plate");

      return new Egg();
    }

    private static async Task<Egg> FryEggsAsync(int howMany)
    {
      Console.WriteLine("Warming the egg pan...");
      await Task.Delay(3000);
      Console.WriteLine($"cracking {howMany} eggs");
      Console.WriteLine("cooking the eggs ...");
      await Task.Delay(3000);
      Console.WriteLine("Put eggs on plate");

      return new Egg();
    }

    private static Coffee PourCoffee()
    {
      Console.WriteLine("Pouring coffee");
      return new Coffee();
    }
    // // GET: Address
    // public IActionResult Index()
    // {
    //     return View(_context.Address.ToArray());
    // }

    // GET: Address/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var address = await _context.Address
          .FirstOrDefaultAsync(m => m.Id == id);
      if (address == null)
      {
        return NotFound();
      }

      return View(address);
    }

    // GET: Address/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Address/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,type,firstName,lastName,email,line1,line2,city,zipCode,country,phone,createdAt,updatedAt")] Address address)
    {
      if (ModelState.IsValid)
      {
        _context.Add(address);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(address);
    }

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
      return View(address);
    }

    // POST: Address/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,type,firstName,lastName,email,line1,line2,city,zipCode,country,phone,createdAt,updatedAt")] Address address)
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
      return View(address);
    }

    // GET: Address/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var address = await _context.Address
          .FirstOrDefaultAsync(m => m.Id == id);
      if (address == null)
      {
        return NotFound();
      }

      return View(address);
    }

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

    private bool AddressExists(int id)
    {
      return _context.Address.Any(e => e.Id == id);
    }
  }
}
