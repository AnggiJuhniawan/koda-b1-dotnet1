using Banking.Console.Models;
using Banking.Console.Interface;
using Banking.Console.Services;

Product product1 = new RegularProduct("Mouse", 350_000, "Mouse Rifai Warna Hitam", 10, true);

Product productDiscount = new DiscountProduct("Keyboard", 1000, "Mechanical Keyboard Rifai Warna Pink", 20, true, 20);

List<Product> products = new List<Product>()
{
new RegularProduct("Mouse", 350_000, "Mouse Rifai Warna Hitam", 10, true),
new DiscountProduct("Keyboard", 1000, "Mechanical Keyboard Rifai Warna Pink", 20, true, 20),
new DiscountProduct("Monitor", 25000, "Monitor Layar 4K", 10, true, 50),
new RegularProduct("Speaker", 5000, "Speaker 4K", 15, true),
};

// Tolong Tambahkan 
// Dictionary<TKey, TValue>
// HashSet<T>
// Queue<T>

Console.WriteLine("Munculin Product");
foreach (Product product in products)
{
    Console.WriteLine(product.GetInformation());
}

Console.WriteLine("Transaksi");
decimal total1 = product1.Sell(3);
decimal total2 = productDiscount.Sell(3);
Console.WriteLine($"Total Mouse: {total1:N2}");
Console.WriteLine($"Total Keyboard: {total2:N0}");

if (productDiscount is IDiscountable discountable)
{
    Console.WriteLine($"Discount: {discountable.CalculateDiscount():N0}");
}

Console.WriteLine("Sisa Stok");
foreach (Product product in products)
{
    Console.WriteLine($"{product.Name} : {product.Stock}");
}

Console.WriteLine("==== WHERE ====");
var activeProduct = products.Where(product => product.IsActive).ToList();

foreach (var productAlias in activeProduct)
{
    Console.WriteLine(productAlias.Name);
}

Console.WriteLine("==== FIRST DEFAULT ====");
Product? foundProject = products.FirstOrDefault(product => product.Name == "Salah");

if (foundProject != null)
{
    Console.WriteLine(foundProject.GetInformation());
}
else
{
    Console.WriteLine("Product Not Found");
}

Console.WriteLine("==== FIRST DEFAULT ====");
var sortedProducts = products.OrderBy(product => product.Price).ToList();
// Console.WriteLine(sortedProducts);
foreach (var productAliasLagi in sortedProducts)
{
    Console.WriteLine($"{productAliasLagi.Name} - Rp {productAliasLagi.Price:N0}");
}

Console.WriteLine("==== SELECT ====");
var productName = products.Select(product => product.Name).ToList();

foreach (var name in productName)
{
    Console.WriteLine(name);
}

System.Console.WriteLine("=========== ASYNC PRODUCT SEARCH =============");

var queryService = new ProductQueryService(products);
Product? resultAsync = await queryService.findProductAsync("Keyboard");
Task<Product?> task1 = queryService.findProductAsync("Keyboard");
Task<Product?> task2 = queryService.findProductAsync("Mouse");
Task<Product?> task3 = queryService.findProductAsync("Panci");

Product?[] results = await Task.WhenAll(task1, task2, task3);

foreach (Product? product in results)
{
    Console.WriteLine(product?.GetInformation() ?? "Product not found");
}

if (resultAsync is null)
{
    System.Console.WriteLine("Product not Found");
}
else
{
    System.Console.WriteLine(resultAsync.GetInformation());
}





// Console.WriteLine("\n=== TOTAL STOCK VALUE ===");

// decimal totalStockValue = products
//     .Sum(product =>
//         product.GetSellingPrice() * product.Stock
//     );

// Console.WriteLine(
//     $"Total Stock Value: Rp{totalStockValue:N0}"
// );

// Console.WriteLine("\n=== PRODUCT DICTIONARY ===");

// Dictionary<string, Product> productMap =
//     products.ToDictionary(
//         product => product.Name
//     );

// if (productMap.TryGetValue("Keyboard", out Product? result))
// {
//     Console.WriteLine(result.GetInformation());
// }
// else
// {
//     Console.WriteLine("Product not found");
// }


// Console.WriteLine("\n=== NULLABLE PRODUCT ===");

// Product? producti = products
//     .FirstOrDefault(p =>
//         p.Name == "Mouse"
//     );

// if (producti is null)
// {
//     Console.WriteLine("Product not found");
// }
// else
// {
//     Console.WriteLine(producti.GetInformation());
// }

// Console.WriteLine(product1.Stock);
// product1.Restock(5);

// product1.UpdatePrice(10000);
// Console.WriteLine($"Harga Update: {product1.Price}");

// decimal total = product1.Sell(2);

// Console.WriteLine($"Total Pembelian: Rp. {total}");
// Console.WriteLine($"Sisa Stok : {product1.Stock}");

// Console.WriteLine(product1.GetInformation());