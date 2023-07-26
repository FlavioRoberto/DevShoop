using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevShoop.ProductAPI.Controllers;

[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly string[] summaries;

    public ProductController()
    {
    }

    [HttpPost]
    public async Task<ActionResult<ProductViewModel>> AddProduct([FromBody] AddProductUseCase addProduct, [FromServices] IAddProductUseCase addProductUseCase)
    {
        var product = await addProductUseCase.Execute(addProduct);
        return Ok(product);
    }

}
