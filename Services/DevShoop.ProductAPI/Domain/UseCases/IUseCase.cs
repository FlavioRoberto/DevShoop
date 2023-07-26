namespace DevShoop.ProductAPI.Domain.UseCases;

public interface UseCase { }

public interface IUseCaseHandlerAsync<TResult, T> where T : UseCase
{
       Task<TResult> Execute(T useCase);
}
