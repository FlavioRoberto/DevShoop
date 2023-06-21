using AutoMapper;

namespace DevShoop.ProductAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps(){
        return  new MapperConfiguration(config => {
            config.CreateMap<ProductViewModel, Product>()
                  .ReverseMap();
        });
    }
}
