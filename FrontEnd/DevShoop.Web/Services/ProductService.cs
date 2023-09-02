using DevShoop.Web.Extensions;
using DevShoop.Web.Models;

namespace DevShoop.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private const string PATH = "api/v1/product";

    public ProductService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel)
    {
        var response = await _client.PostAsJson(PATH, productViewModel);
        return await response.ReadContentAsync<ProductViewModel>();
    }

    public async Task<bool> DeleteProduct(long id)
    {
        var response = await _client.DeleteAsync($"{PATH}/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<ProductViewModel> FindProductById(long id)
    {
        var response = await _client.Get($"{PATH}/{id}");
        return await response.ReadContentAsync<ProductViewModel>();
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        var response = await _client.Get(PATH);
        return await response.ReadContentAsync<IEnumerable<ProductViewModel>>();
    }

    public async Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel)
    {
        var response = await _client.PutAsJson(PATH, productViewModel);
        return await response.ReadContentAsync<ProductViewModel>();
    }
}
