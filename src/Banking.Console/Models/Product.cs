namespace Banking.Console.Models;

public class Product
{
    public string Name;
    public decimal Price;
    public int Stock;
    public string? Description;

    public Product(string name, decimal price, string? description, int stock)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }
        if (price <= 0)
        {
            throw new ArgumentException("Price must be positive");
        }
        if (stock < 0)
        {
            throw new ArgumentException("Stock cannot be negative");
        }
        Name = name;
        Price = price;
        Description = description;
        Stock = stock;
    }

    public string GetInformation()
    {
        return $"Product: {Name}, Price: {Price}, Stock: {Stock}, Description: {Description}";
    }
}