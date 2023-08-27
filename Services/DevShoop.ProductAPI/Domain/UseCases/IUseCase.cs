﻿namespace DevShoop.ProductAPI.Domain.UseCases;

public interface UseCase { }

public interface IUseCaseResult
{
    IList<string> Errors { get; }
    bool IsValid();
}

public class UseCaseResult : IUseCaseResult
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
    public T Data { set; get; }

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

public interface IUseCaseHandlerAsync<TResult> where TResult : IUseCaseResult
{
    Task<TResult> Execute();
}

public interface IUseCaseHandlerAsync<TResult, T> where T : UseCase where TResult : IUseCaseResult
{
    Task<TResult> Execute(T useCase);
}

public interface IUseCaseValidator<TUseCase, TUseCaseResult> where TUseCase : UseCase where TUseCaseResult : IUseCaseResult
{
    TUseCaseResult Validate(TUseCase useCase);
}

