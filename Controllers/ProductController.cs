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
        return View("Products");
    }

    [HttpPost("/products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid == false)
        {
            ViewBag.products = _context.Products.ToList();
            return View("Products");
        }
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Products");
    }

    [HttpGet("/products/{productId")]
    public IActionResult Product(int productId)
    {
        Product? productDetails = _context.Products.FirstOrDefault(prod => prod.ProductId == productId);
        ViewBag.ProductDetails = productDetails;

        var productCategory = _context.Products
        .Include(prod => prod.Association)
        .ThenInclude(cat => cat.Category)
        .
    }
}
