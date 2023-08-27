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

public class UpdateProductUseCaseValidator<T> : IUseCaseValidator<UpdateProductUseCase, UseCaseResult<T>>
{
    public UseCaseResult<T> Validate(UpdateProductUseCase useCase)
    {
        var useCaseResult = new UseCaseResult<T>();

        if (useCase.Id == null || useCase.Id <= 0)
            useCaseResult.AddError("Campo Id não foi informado");

        return useCaseResult;
    }
}
