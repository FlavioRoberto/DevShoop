using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public class RemoveProductUseCaseHandler : UseCaseWithValidationHandler<UseCaseResult, RemoveProductUseCase>, IRemoveProductUseCase
{
    private readonly IProductRepository _productRepository;

    public RemoveProductUseCaseHandler(IProductRepository productRepository) : base(new RemoveProductUseCaseValidator())
    {
        _productRepository = productRepository;
    }

    protected override async Task<UseCaseResult> ExecuteUseCase(RemoveProductUseCase useCase)
    {
        var hasProdct = await _productRepository.FindById(useCase.Id);

        if (hasProdct == null)
        {
            ValidationResult.AddError("Produto não encontrado!");
            return ValidationResult;
        }

        await _productRepository.Delete(useCase.Id);

        await _productRepository.Commit();

        return ValidationResult;
    }
}

