﻿using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DevShoop.ProductAPI.Application.UseCases.Product;

namespace DevShoop.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
public class ProductController : MainController
{
    public ProductController()
    {
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> AddProduct([FromBody] AddProductUseCase addProduct, [FromServices] IAddProductUseCase addProductUseCase)
    {
        var addProductResult = await addProductUseCase.Execute(addProduct);
        return Execute(addProductResult);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> ListProducts([FromServices] IListProductUseCase listProductsUseCase)
    {
        var productResult = await listProductsUseCase.Execute();
        return Execute(productResult);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductViewModel>> GetProduct([FromServices] IFindProductByIdUseCase findProductByIdUseCase, int id)
    {
        var productResult = await findProductByIdUseCase.Execute(new FindProductByIdUseCase(id));
        return Execute(productResult);
    }

    [HttpPut]
    public async Task<ActionResult<ProductViewModel>> UpdateProduct([FromBody] UpdateProductUseCase updateProduct, [FromServices] IUpdateProductUseCase updateProductUseCase)
    {
        var updateProductResult = await updateProductUseCase.Execute(updateProduct);
        return Execute(updateProductResult);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Remove(int Id, [FromServices] IRemoveProductUseCase removeProductUseCase)
    {
        var removeProductResult = await removeProductUseCase.Execute(new RemoveProductUseCase(Id));
        return Execute(removeProductResult);
    }
}
