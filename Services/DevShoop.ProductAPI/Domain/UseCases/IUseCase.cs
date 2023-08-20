namespace DevShoop.ProductAPI.Domain.UseCases;

public interface UseCase { }

public class UseCaseResult<T>
{
    public T Data { private set; get; }
    public IList<string> Errors { private set; get; }

    public UseCaseResult()
    {
        Errors = new List<string>();
    }

    public UseCaseResult(T data)
    {
        Errors = new List<string>();
        Data = data;
    }

    public bool IsValid()
    {
        return !Errors.Any();
    }

    public void AddError(string error){
        Errors.Add(error);
    }

    public void AddData(T data){
        Data = data;
    }
}


public interface IUseCaseHandlerAsync<TResult, T> where T : UseCase
{
    Task<UseCaseResult<TResult>> Execute(T useCase);
}

public interface IUseCaseHandlerAsync<TResult>
{
    Task<UseCaseResult<TResult>> Execute();
}