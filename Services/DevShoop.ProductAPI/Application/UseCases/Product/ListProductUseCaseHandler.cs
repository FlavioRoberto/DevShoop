using AutoMapper;
using DevShoop.ProductAPI.Application.ViewModels;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public class ListProductUseCaseHandler : IListProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductUseCaseHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UseCaseResult<IEnumerable<ProductViewModel>>> Execute()
    {
        var products = await _productRepository.GetAll();
        var productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(products);
        return new UseCaseResult<IEnumerable<ProductViewModel>>(productsViewModel);
    }
}
