using System;
using System.Collections.Generic;

public class ShoppingBasket
{
    public int BasketID { get; set; }
    private List<Product> Products = new List<Product>();

    public ShoppingBasket(int basketID)
    {
        BasketID = basketID;
    }

    public void DisplayAllItems()
    {
        Console.WriteLine($"Basket ID: {BasketID}");

        if (Products.Count == 0)
        {
            Console.WriteLine("Basket is empty.");
            return;
        }

        foreach (var product in Products)
        {
            Console.WriteLine($"- {product.ProductName}, Qty: {product.Quantity}, Price: ${product.Price}");
        }
    }

    public void AddProduct(Product product, int quantity)
    {
        if (quantity <= 0)
        {
            Console.WriteLine("Invalid quantity. Please add at least 1 item.");
            return;
        }

        product.Quantity = quantity;
        Products.Add(product);
        Console.WriteLine($"Added {quantity} of '{product.ProductName}' to the basket.");
    }

    public void RemoveProduct(Product product)
    {
        var item = Products.Find(p => p.ProductName == product.ProductName);

        if (item != null)
        {
            Products.Remove(item);
            Console.WriteLine($"Removed '{product.ProductName}' from the basket.");
        }
        else
        {
            Console.WriteLine("Product not found in the basket.");
        }
    }
}

public class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, double price)
    {
        ProductName = name;
        Price = price;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var basket = new ShoppingBasket(1);
        var apple = new Product("Apple", 0.5);

        basket.AddProduct(apple, 3);
        basket.DisplayAllItems();

        var orange = new Product("Orange", 0.8);
        basket.AddProduct(orange, 2);
        basket.DisplayAllItems();

        basket.RemoveProduct(apple);
        basket.DisplayAllItems();
    }
}

public class Admin : User
{
    public DateTime LastLogin { get; set; }
    public Admin(int userId, string userName, string password, DateTime lastLogin)
        : base(userId, userName, password)
    {
        LastLogin = lastLogin;
    }
    public void UpdateLastLogin()
    {
        LastLogin = DateTime.Now;
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Last Login: {LastLogin}");
    }
}
public class Customer : User
{
    public string Role { get; set; }
    public string Status { get; set; }
    public Customer(int userId, string userName, string password, string role, string status)
        : base(userId, userName, password)
    {
        Role = role;
        Status = status;
    }
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
    }
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Role: {Role}, Status: {Status}");
    }
}
