using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Customer GetCustomer()
        {
            return _customer;
        }

        public double GetTotalCost()
        {
            double totalCost = 0;
            foreach (Product product in _products)
            {
                totalCost += product.GetTotalCost();
            }

            if (_customer.IsInUSA())
            {
                totalCost += 5;
            }
            else
            {
                totalCost += 35;
            }

            return totalCost;
        }

        public string GetPackingLabel()
        {
            string packingLabel = "Packing Label:\n";
            foreach (Product product in _products)
            {
                packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
            }
            return packingLabel;
        }

        public string GetShippingLabel()
        {
            string shippingLabel = "Shipping Label:\n";
            shippingLabel += $"{_customer.GetName()}\n";
            shippingLabel += _customer.GetAddress().GetFullAddress();
            return shippingLabel;
        }
    }
}
