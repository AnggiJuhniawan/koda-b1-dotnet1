using Banking.Console.Models;
using Banking.Console.Interface;

Product product1 = new RegularProduct("Mouse", 350_000, "Mouse Rifai Warna Hitam", 10);

Product productDiscount = new DiscountProduct("Keyboard", 1000, "Mechanical Keyboard Rifai Warna Pink", 20, 20);

List<Product> products = new List<Product>()
{
    product1, productDiscount
};


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
// Console.WriteLine(product1.Stock);
// product1.Restock(5);

// product1.UpdatePrice(10000);
// Console.WriteLine($"Harga Update: {product1.Price}");

// decimal total = product1.Sell(2);

// Console.WriteLine($"Total Pembelian: Rp. {total}");
// Console.WriteLine($"Sisa Stok : {product1.Stock}");

// Console.WriteLine(product1.GetInformation());