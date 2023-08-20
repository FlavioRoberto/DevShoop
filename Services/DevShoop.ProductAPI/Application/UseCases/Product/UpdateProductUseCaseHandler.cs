using AutoMapper;
using DevShoop.ProductAPI.Application.ViewModels;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public class UpdateProductUseCaseHandler : IUpdateProductUseCase
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public UpdateProductUseCaseHandler(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public async Task<UseCaseResult<ProductViewModel>> Execute(UpdateProductUseCase useCase)
    {
        var useCaseResult = new UseCaseResult<ProductViewModel>();

        if (useCase.Id == null || useCase.Id <= 0)
            useCaseResult.AddError("Campo Id não foi informado");

        var product = mapper.Map<Domain.Models.Product>(useCase);

        productRepository.Update(product);

        await productRepository.Commit();

        var ProductViewModel = mapper.Map<ProductViewModel>(product);

        useCaseResult.AddData(ProductViewModel);

        return useCaseResult;
    }
}
