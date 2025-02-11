using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress = new Address("123 Jane St", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("3110 Valle del Nogal", "Culiacan", "SIN", "Mexico");

        // Create customers
        Customer usCustomer = new Customer("John Miller", usaAddress);
        Customer internationalCustomer = new Customer("Juan Perez", internationalAddress);

        // Create some products
        Product laptop = new Product("iPhone 15 Pro Max", "TECH001", 999.99, 1);
        Product mouse = new Product("Apple Magic Keyboard", "TECH002", 29.99, 2);
        Product headphones = new Product("Apple Airpods Pro", "TECH003", 149.99, 1);

        // Create and process first order (USA)
        Order order1 = new Order(usCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);

        Console.WriteLine("Order 1 (USA Customer):");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}");
        Console.WriteLine();

        // Create and process second order (International)
        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(headphones);
        order2.AddProduct(mouse);

        Console.WriteLine("Order 2 (International Customer):");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}