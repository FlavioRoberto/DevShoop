using AutoMapper;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Application.ViewModels;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public class AddProductUseCaseHandler : UseCaseWithValidationHandler<UseCaseResult<ProductViewModel>, AddProductUseCase>, IAddProductUseCase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public AddProductUseCaseHandler(IProductRepository repository, IMapper mapper) : base(new AddProductUseCaseValidator())
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override async Task<UseCaseResult<ProductViewModel>> ExecuteUseCase(AddProductUseCase useCase)
    {
        var product = _mapper.Map<Domain.Models.Product>(useCase);

        _repository.Create(product);

        await _repository.Commit();

        var products = _mapper.Map<ProductViewModel>(product);

        ValidationResult.AddData(products);

        return ValidationResult;
    }
}
