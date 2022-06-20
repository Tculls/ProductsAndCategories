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
        ViewBag.categories = _context.Categories.ToList();
        return View("AddCategory");
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid == false)
        {
            return View("Categories");
        }
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return Categories();
    }

    [HttpGet("/categories/{categoryId}")]
    public IActionResult OneCategory(int categoryId)
    {
        Category? categoryDetails = _context.Categories.FirstOrDefault( cat => cat.CategoryId == categoryId);
        ViewBag.CategoryDetail = categoryDetails;

        var categoryProduct = _context.Categories
        .Include(cat => cat.Associations)
        .ThenInclude(cat => cat.Product)
        .FirstOrDefault(cI => cI.CategoryId == categoryId);
        ViewBag.CategoryProduct = categoryProduct;

        if (categoryDetails == null)
        {
            return Categories();
        }

        return View("Categories");

    }
}