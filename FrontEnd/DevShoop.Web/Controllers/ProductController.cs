using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevShoop.Web.Models;
using DevShoop.Web.Services;

namespace DevShoop.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
        var products = await _productService.GetAllProducts();
        return View(products);
    }

    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Error));

        var response = await _productService.CreateProduct(productViewModel);

        if (response != null)
            return RedirectToAction(nameof(ProductIndex));

        return View(productViewModel);
    }

    public async Task<IActionResult> ProductUpdate(int id)
    {
        var product = await _productService.FindProductById(id);
       
        if (product != null)
            return View(product);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductViewModel productViewModel)
    {
        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Error));

        var response = await _productService.UpdateProduct(productViewModel);

        if (response != null)
            return RedirectToAction(nameof(ProductIndex));

        return View(productViewModel);
    }

    public async Task<IActionResult> ProductDelete(int id)
    {
        var product = await _productService.FindProductById(id);

        if (product != null)
            return View(product);

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ProductDelete(ProductViewModel productViewModel)
    {
        if (productViewModel.Id <= 0)
            return RedirectToAction(nameof(Error));

        var response = await _productService.DeleteProduct(productViewModel.Id);

        if (response)
            return RedirectToAction(nameof(ProductIndex));

        return View(productViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
