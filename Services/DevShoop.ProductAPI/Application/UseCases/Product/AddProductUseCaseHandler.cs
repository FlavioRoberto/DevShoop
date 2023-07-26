using AutoMapper;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Presentation.ViewModels;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public class AddProductUseCaseHandler : IAddProductUseCase
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public AddProductUseCaseHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    async Task<ProductViewModel> IUseCaseHandlerAsync<ProductViewModel, AddProductUseCase>.Execute(AddProductUseCase useCase)
    {
        var product = _mapper.Map<Domain.Models.Product>(useCase);
        _repository.Create(product);
        await _repository.Commit();
        return _mapper.Map<ProductViewModel>(product);
    }
}
