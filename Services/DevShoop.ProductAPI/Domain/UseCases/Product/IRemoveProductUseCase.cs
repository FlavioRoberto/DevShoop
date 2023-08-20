namespace DevShoop.ProductAPI.Domain.UseCases.Product;

public class RemoveProductUseCase : UseCase
{
    public int Id {private set; get;}

    public RemoveProductUseCase(int id)
    {
        this.Id = id;
    }
}

public interface IRemoveProductUseCase : IUseCaseHandlerWithouDataAsync<RemoveProductUseCase>
{
}