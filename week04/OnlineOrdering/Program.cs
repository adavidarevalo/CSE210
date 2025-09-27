using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("John Smith", address1);
            Order order1 = new Order(customer1);

            Product product1 = new Product("Laptop", "LAP001", 999.99, 1);
            Product product2 = new Product("Mouse", "MOU001", 25.50, 2);
            Product product3 = new Product("Keyboard", "KEY001", 75.00, 1);

            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Jane Doe", address2);
            Order order2 = new Order(customer2);

            Product product4 = new Product("Tablet", "TAB001", 299.99, 1);
            Product product5 = new Product("Case", "CAS001", 15.99, 1);

            order2.AddProduct(product4);
            order2.AddProduct(product5);

            Console.WriteLine("=== ORDER 1 ===");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
            Console.WriteLine();

            Console.WriteLine("=== ORDER 2 ===");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
        }
    }
}