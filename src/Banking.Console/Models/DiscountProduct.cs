using Banking.Console.Interface;

namespace Banking.Console.Models;

public class DiscountProduct : Product, IDiscountable
{
    public decimal DiscountPercent { get; set; }
    public DiscountProduct(string name, decimal price, string? description, int stock, bool isActive, decimal discountPercent) : base(name, price, description, stock, isActive)
    {
        if (discountPercent < 0 || discountPercent > 100)
        {
            throw new ArgumentException("Discount must be between 0 and 100");
        }
        DiscountPercent = discountPercent;
    }

    public decimal CalculateDiscount()
    {
        return Price * DiscountPercent / 100;
    }

    public override decimal GetSellingPrice()
    {
        return Price - CalculateDiscount();
    }

    public override string GetInformation()
    {
        return base.GetInformation() + $"| Discount: {DiscountPercent:N0}" + $"| Selling Price: Rp. {GetSellingPrice():N0}, Status : {IsActive}";
    }
}