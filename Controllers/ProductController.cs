using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller

{
    private ORMContext _context;

    public ProductController(ORMContext context)
    {
        _context = context;
    }

    [HttpGet("/products")]
    public IActionResult Products()
    {
        ViewBag.products = _context.Products.ToList();
        return View("AddProduct");
    }

    [HttpPost("/products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid == false)
        {
            return View("Products");
        }
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return Products();
    }

    [HttpGet("/products/{productId}")]
    public IActionResult OneProduct(int productId)
    {
        Product? productDetails = _context.Products.FirstOrDefault(prod => prod.ProductId == productId);
        ViewBag.ProductDetails = productDetails;

        var productCategory = _context.Products
        .Include(prod => prod.Associations)
        .ThenInclude(cat => cat.Category)
        .FirstOrDefault(pI => pI.ProductId == productId);
        ViewBag.ProductCategory = productCategory;

        List<Category> selectCategory = _context.Categories
        .Include(cat => cat.Associations)
        .Where(cats => cats.Associations.All(cat => cat.ProductId != productId))
        .ToList();
        ViewBag.selectCategory = selectCategory;

        if (productDetails == null )
        {
            return Products();
        }

        return View("Products");
    }
}
