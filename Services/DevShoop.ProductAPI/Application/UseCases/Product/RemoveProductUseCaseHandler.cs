using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public class RemoveProductUseCaseHandler : IRemoveProductUseCase
{
    private readonly IProductRepository _productRepository;

    public RemoveProductUseCaseHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<UseCaseResult> Execute(RemoveProductUseCase useCase)
    {
        var useCaseResult = new UseCaseResult();

        if (useCase.Id == null || useCase.Id <= 0)
            useCaseResult.AddError("Id não foi informado!");

        var hasProdct = await _productRepository.FindById(useCase.Id);

        if(hasProdct == null){
            useCaseResult.AddError("Produto não encontrado!");
            return useCaseResult;
        }

        await _productRepository.Delete(useCase.Id);

        await _productRepository.Commit();

        return useCaseResult;
    }
}

