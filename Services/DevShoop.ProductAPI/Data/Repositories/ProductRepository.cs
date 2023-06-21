using Microsoft.EntityFrameworkCore;

namespace DevShoop.ProductAPI;

public class ProductRepository : IProductRepository
{
    private readonly ProductApiContext _productApiContext;

    public ProductRepository(ProductApiContext productApiContext)
    {
        _productApiContext = productApiContext;
    }

    public DbSet<Product> ProductDbSet { get { return _productApiContext.Products; } }    

    public void Create(Product product)
    {
        ProductDbSet.Add(product);
    }

    public async Task Delete(long id)
    {
        var productToRemove = await FindById(id);

        if (productToRemove != null)
            ProductDbSet.Remove(productToRemove);  
    }

    public async Task<Product> FindById(long id)
    {
        return await ProductDbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await ProductDbSet.ToListAsync();
    }

    public void Update(Product product)
    {
        ProductDbSet.Update(product);
    }

    public async Task<bool> Commit()
    {
        return await _productApiContext.SaveChangesAsync() > 0;
    }
}
