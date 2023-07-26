using DevShoop.ProductAPI.Data.Context;
using DevShoop.ProductAPI.Domain.Models;
using DevShoop.ProductAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevShoop.ProductAPI.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductApiContext _productApiContext;
    private readonly DbSet<Product> _productDbSet;

    public ProductRepository(ProductApiContext productApiContext)
    {
        _productApiContext = productApiContext;
        _productDbSet = _productApiContext.Products;
    }

    public void Create(Product product)
    {
        _productDbSet.Add(product);
    }

    public async Task Delete(long id)
    {
        var productToRemove = await FindById(id);

        if (productToRemove != null)
            _productDbSet.Remove(productToRemove);  
    }

    public async Task<Product> FindById(long id)
    {
        return await _productDbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _productDbSet.ToListAsync();
    }

    public void Update(Product product)
    {
        _productDbSet.Update(product);
    }

    public async Task<bool> Commit()
    {
        return await _productApiContext.SaveChangesAsync() > 0;
    }
}
