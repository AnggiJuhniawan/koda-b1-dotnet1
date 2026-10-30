using Banking.Console.Models;

namespace Banking.Console.Services;

public class ProductQueryService
{
    private readonly IReadOnlyList<Product> _products;

    public ProductQueryService(IReadOnlyList<Product> products)
    {
        _products = products;
    }
    public async Task<Product?> findProductAsync(
        string productName
    )
    {
        await Task.Delay(300);

        return _products.FirstOrDefault(
            product => product.Name == productName
        );
    }
}