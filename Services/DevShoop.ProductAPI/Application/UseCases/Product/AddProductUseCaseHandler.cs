using AutoMapper;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Application.ViewModels;

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

    public async Task<UseCaseResult<ProductViewModel>> Execute(AddProductUseCase useCase)
    {
        var useCaseResult = new UseCaseResult<ProductViewModel>();

        if (useCase.Price < 1)
            useCaseResult.AddError("O preço deve ser superior a 1");

        if (useCase.Price > 10000)
            useCaseResult.AddError("O preço deve ser inferior a 10000");

        var product = _mapper.Map<Domain.Models.Product>(useCase);
       
        _repository.Create(product);
       
        await _repository.Commit();
       
        var products = _mapper.Map<ProductViewModel>(product);

        useCaseResult.AddData(products);

        return useCaseResult;
    }

}
