namespace DevShoop.ProductAPI.Domain.UseCases;

public interface UseCase { }

public class UseCaseResult
{
    public IList<string> Errors { protected set; get; }
    
    public UseCaseResult()
    {
        Errors = new List<string>();
    }

    public bool IsValid()
    {
        return !Errors.Any();
    }

    public void AddError(string error)
    {
        Errors.Add(error);
    }

}

public class UseCaseResult<T> : UseCaseResult
{
    public T Data { private set; get; }

    public UseCaseResult()
    {
        Errors = new List<string>();
    }

    public UseCaseResult(T data)
    {
        Errors = new List<string>();
        Data = data;
    }

    public void AddData(T data)
    {
        Data = data;
    }
}

public interface IUseCaseHandlerAsync<TResult, T> where T : UseCase
{
    Task<UseCaseResult<TResult>> Execute(T useCase);
}

public interface IUseCaseHandlerWithouDataAsync<T> where T : UseCase
{
    Task<UseCaseResult> Execute(T useCase);
}


public interface IUseCaseHandlerAsync<TResult>
{
    Task<UseCaseResult<TResult>> Execute();
}