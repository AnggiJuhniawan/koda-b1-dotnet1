using System.Dynamic;

namespace Banking.Console.Models;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Description { get; set; }
    public bool IsActive { get; private set; }
    public string Status => IsActive ? "Active" : "Inactive";
    public Product(string name, decimal price, string? description, int stock, bool isActive = true)
    {
        if (string.IsNullOrWhiteSpace(name))
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
        IsActive = isActive;
    }

    public virtual decimal GetSellingPrice()
    {
        return Price;
    }

    public virtual string GetInformation()
    {
        return $"Product: {Name}, Price: {Price:N0}, Stock: {Stock}, Description: {Description}, Status: {IsActive}";
    }

    public void Restock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be positive");
        }

        Stock = checked(Stock + quantity);
    }

    public decimal Sell(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be positive");
        }
        if (!IsActive)
        {
            throw new InvalidOperationException("Product is Inactive");
        }
        if (quantity > Stock)
        {
            throw new InvalidOperationException("Kelebihan Woe");
        }
        decimal totalPrice = GetSellingPrice() * quantity;
        Stock -= quantity;
        return totalPrice;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
        {
            throw new ArgumentException("Price must be positive");
        }
        Price = newPrice;
    }
}