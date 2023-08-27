namespace DevShoop.ProductAPI.Domain.UseCases.Product;

public class RemoveProductUseCase : UseCase
{
    public int Id {private set; get;}

    public RemoveProductUseCase(int id)
    {
        this.Id = id;
    }
}

public class RemoveProductUseCaseValidator : IUseCaseValidator<RemoveProductUseCase, UseCaseResult>
{
    public UseCaseResult Validate(RemoveProductUseCase useCase)
    {
        var useCaseResult = new UseCaseResult();

        if (useCase.Id == null || useCase.Id <= 0)
            useCaseResult.AddError("Id não foi informado!");

        return useCaseResult;
    }
}

public interface IRemoveProductUseCase : IUseCaseHandlerAsync<UseCaseResult, RemoveProductUseCase>
{
}