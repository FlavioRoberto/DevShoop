using DevShoop.ProductAPI.Application.ViewModels;

namespace DevShoop.ProductAPI.Domain.UseCases.Product;

public class UpdateProductUseCase : UseCase
{
    public long Id { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string ImageUrl { get; set; }
}

public interface IUpdateProductUseCase : IUseCaseHandlerAsync<ProductViewModel, UpdateProductUseCase>
{
}
