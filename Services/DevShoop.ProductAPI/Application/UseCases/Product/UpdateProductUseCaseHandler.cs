using AutoMapper;
using DevShoop.ProductAPI.Application.ViewModels;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public interface IUpdateProductUseCase : IUseCaseHandlerAsync<UseCaseResult<ProductViewModel>, UpdateProductUseCase>
{
}

public class UpdateProductUseCaseHandler : UseCaseWithValidationHandler<UseCaseResult<ProductViewModel>, UpdateProductUseCase>, IUpdateProductUseCase
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public UpdateProductUseCaseHandler(
            IProductRepository productRepository, 
            IMapper mapper) : base(new UpdateProductUseCaseValidator<ProductViewModel>())
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    protected override async Task<UseCaseResult<ProductViewModel>> ExecuteUseCase(UpdateProductUseCase useCase)
    {
        var product = mapper.Map<Domain.Models.Product>(useCase);

        productRepository.Update(product);

        await productRepository.Commit();

        var ProductViewModel = mapper.Map<ProductViewModel>(product);

        ValidationResult.AddData(ProductViewModel);

        return ValidationResult;
    }
}
