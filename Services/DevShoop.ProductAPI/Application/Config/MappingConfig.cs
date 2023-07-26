using AutoMapper;
using DevShoop.ProductAPI.Domain.Models;
using DevShoop.ProductAPI.Domain.UseCases.Product;
using DevShoop.ProductAPI.Application.ViewModels;

namespace DevShoop.ProductAPI.Application.Config;

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
