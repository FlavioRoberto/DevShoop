using DevShoop.ProductAPI.Application.ViewModels;

namespace DevShoop.ProductAPI.Domain.UseCases.Product;

public class AddProductUseCase : UseCase{
     public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string ImageUrl { get; set; }
}

public interface IAddProductUseCase : IUseCaseHandlerAsync<ProductViewModel, AddProductUseCase>
{
}
