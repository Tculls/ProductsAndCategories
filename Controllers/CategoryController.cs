using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

public class CategoryController : Controller 
{

    private ORMContext _context;

    public CategoryController(ORMContext context)
    {
        _context = context;
    }

    [HttpGet("/categories")]
    public IActionResult Categories()
    {
        List<Category> categories = _context.Categories.ToList();
        return View("Categories", categories);
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid == false)
        {
            List<Category> categories = _context.Categories.ToList();
            return View("Categories", categories);
        }
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("Categories");
    }

    // [HttpGet("/categories/{categoryId}")]
    // public IActionResult Category(int categoryId)
    // {
    //     Category cgory = _context.Categories
    //     .Include(categoryProduct => categoryProduct.CategoryProducts)
    // }
}