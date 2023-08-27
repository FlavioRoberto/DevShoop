using DevShoop.ProductAPI.Application.ViewModels;

namespace DevShoop.ProductAPI.Domain.UseCases.Product;

public class AddProductUseCase : UseCase
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string ImageUrl { get; set; }
}

public class AddProductUseCaseValidator<T> : IUseCaseValidator<AddProductUseCase, UseCaseResult<T>>
{
    public UseCaseResult<T> Validate(AddProductUseCase useCase)
    {
        var useCaseResult = new UseCaseResult<T>();

        if (useCase.Price < 1)
            useCaseResult.AddError("O preço deve ser superior a 1");

        if (useCase.Price > 10000)
            useCaseResult.AddError("O preço deve ser inferior a 10000");

        return useCaseResult;
    }
}


