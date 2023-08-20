using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        return await Execute(addProductResult);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> ListProducts([FromServices] IListProductUseCase listProductsUseCase)
    {
        var productResult = await listProductsUseCase.Execute();
        return await Execute(productResult);
    }

    [HttpPut]
    public async Task<ActionResult<ProductViewModel>> UpdateProduct([FromBody] UpdateProductUseCase updateProduct, [FromServices] IUpdateProductUseCase updateProductUseCase)
    {
        var updateProductResult = await updateProductUseCase.Execute(updateProduct);
        return await Execute(updateProductResult);
    }
}
