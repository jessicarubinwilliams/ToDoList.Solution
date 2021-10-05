using Microsoft.AspNetCore.Mvc;
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
      List<Item> model = _db.Items.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
        return View(thisItem);
    }

    public ActionResult Edit(int id)
    {
        var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
        return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Item item)
    {
        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
        return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
        _db.Items.Remove(thisItem);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}