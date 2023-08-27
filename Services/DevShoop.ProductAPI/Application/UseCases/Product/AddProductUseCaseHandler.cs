﻿using AutoMapper;
using DevShoop.ProductAPI.Domain.Repositories;
using DevShoop.ProductAPI.Domain.UseCases;
using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Application.ViewModels;

namespace DevShoop.ProductAPI.Application.UseCases.Product;

public class AddProductUseCaseHandler : IAddProductUseCase
{
    private readonly IProductRepository _repository;
    private readonly AddProductUseCaseValidator _validator;
    private readonly IMapper _mapper;

    public AddProductUseCaseHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = new AddProductUseCaseValidator();
    }

    public async Task<UseCaseResult<ProductViewModel>> Execute(AddProductUseCase useCase)
    {
        var useCaseResult = _validator.Validate(useCase);

        if (!useCaseResult.IsValid())
            return useCaseResult;

        var product = _mapper.Map<Domain.Models.Product>(useCase);

        _repository.Create(product);

        await _repository.Commit();

        var products = _mapper.Map<ProductViewModel>(product);

        useCaseResult.AddData(products);

        return useCaseResult;
    }

}
