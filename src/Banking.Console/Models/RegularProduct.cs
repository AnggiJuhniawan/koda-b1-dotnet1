namespace Banking.Console.Models;

public class RegularProduct : Product
{
    public RegularProduct(string name, decimal price, string? description, int stock) : base(name, price, description, stock)
    {
    }
}