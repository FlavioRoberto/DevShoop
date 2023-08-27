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

public class UpdateProductUseCaseValidator : IUseCaseValidator<UpdateProductUseCase, UseCaseResult<ProductViewModel>>
{
    public UseCaseResult<ProductViewModel> Validate(UpdateProductUseCase useCase)
    {
        var useCaseResult = new UseCaseResult<ProductViewModel>();

        if (useCase.Id == null || useCase.Id <= 0)
            useCaseResult.AddError("Campo Id não foi informado");

        return useCaseResult;
    }
}

public interface IUpdateProductUseCase : IUseCaseHandlerAsync<UseCaseResult<ProductViewModel>, UpdateProductUseCase>
{
}
