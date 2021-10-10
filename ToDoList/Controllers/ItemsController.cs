using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Items.ToList());
    }

//     public ActionResult Create()
//     {
//         ViewBag.Categories = _db.Categories.ToList();
//         return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Item item)
//     {
//         _db.Items.Add(item);
//         _db.SaveChanges();
//         return RedirectToAction("Index");
//     }

    public ActionResult Details(int id)
    {
        var thisItem = _db.Items
          .Include(item => item.JoinEntities)
          .ThenInclude(join => join.Category)
          .FirstOrDefault(item => item.ItemId == id);
        return View(thisItem);
    }

//     public ActionResult Edit(int id)
//     {
//         var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
//          ViewBag.Categories = _db.Categories.ToList();
//         return View(thisItem);
//     }

//     [HttpPost]
//     public ActionResult Edit(Item item)
//     {
//         _db.Entry(item).State = EntityState.Modified;
//         _db.SaveChanges();
//         return RedirectToAction("Index");
//     }

//     public ActionResult Delete(int id)
//     {
//         var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
//         return View(thisItem);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//         var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
//         _db.Items.Remove(thisItem);
//         _db.SaveChanges();
//         return RedirectToAction("Index");
//     }
  }
}