using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
        [HttpGet("/categories")]
        public ActionResult Index()
        {
          List<Category> allCategories = Category.GetAll();
          return View(allCategories);
        }
    }
}