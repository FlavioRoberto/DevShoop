using DevShoop.ProductAPI.Application.ViewModels;

namespace DevShoop.ProductAPI.Domain.UseCases.Product;

public interface IListProductUseCase : IUseCaseHandlerAsync<IEnumerable<ProductViewModel>>
{
}
