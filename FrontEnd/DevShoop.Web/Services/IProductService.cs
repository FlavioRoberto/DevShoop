using DevShoop.Web.Models;

namespace DevShoop.Web.Services;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();
    Task<ProductViewModel> FindProductById(long id);
    Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);
    Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);
    Task<bool> DeleteProduct(long id);
}
