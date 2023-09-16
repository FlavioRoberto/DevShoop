namespace DevShoop.ProductAPI.Domain.UseCases.Product;

public class FindProductByIdUseCase : UseCase
{
    public int Id { get; private set; }
    public FindProductByIdUseCase(int id)
    {
        Id = id;
    }
}

public class FindProductByIdUseCaseValidator<T> : IUseCaseValidator<FindProductByIdUseCase, UseCaseResult<T>>
{
    public UseCaseResult<T> Validate(FindProductByIdUseCase useCase)
    {
        var useCaseResult = new UseCaseResult<T>();

        if (useCase.Id == null || useCase.Id == 0)
            useCaseResult.AddError("O identificador do produto não foi informado!");

        return useCaseResult;
    }
}


