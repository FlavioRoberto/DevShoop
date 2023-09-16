using AutoMapper;
using DevShoop.ProductAPI.Application.ViewModels;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public interface IFindProductByIdUseCase : IUseCaseHandlerAsync<UseCaseResult<ProductViewModel>, FindProductByIdUseCase>
{
}

public class FindProductByIdUseCaseHandler : UseCaseWithValidationHandler<UseCaseResult<ProductViewModel>, FindProductByIdUseCase>, IFindProductByIdUseCase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public FindProductByIdUseCaseHandler(IProductRepository repository, IMapper mapper) : base(new FindProductByIdUseCaseValidator<ProductViewModel>())
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override async Task<UseCaseResult<ProductViewModel>> ExecuteUseCase(FindProductByIdUseCase useCase)
    {
        var product = await _repository.FindById(useCase.Id);

        var productViewModel = _mapper.Map<ProductViewModel>(product);

        ValidationResult.AddData(productViewModel);

        return ValidationResult;
    }
}
