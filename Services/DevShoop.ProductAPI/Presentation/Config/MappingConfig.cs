﻿using AutoMapper;
using DevShoop.ProductAPI.Domain.Models;
using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Presentation.ViewModels;

namespace DevShoop.ProductAPI.Presentation.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps(){
        return  new MapperConfiguration(config => {
            config.CreateMap<ProductViewModel, Product>()
                  .ReverseMap();

            config.CreateMap<AddProductUseCase, Product>();                  
        });
    }
}
