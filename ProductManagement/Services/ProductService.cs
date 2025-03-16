﻿using ProductManagement.Models;

namespace ProductManagement.Services
{
    public class ProductService
    {
        private readonly List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100 },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200 },
                new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300 },
                new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 400 },
                new Product { Id = 5, Name = "Product 5", Description = "Description 5", Price = 500 },
                new Product { Id = 6, Name = "Product 6", Description = "Description 6", Price = 600 }
            };
        }
        public void LoadProducts()
        {
            _products.Clear();
            _products.Add(new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100 });
            _products.Add(new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200 });
            _products.Add(new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300 });
            _products.Add(new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 400 });
            _products.Add(new Product { Id = 5, Name = "Product 5", Description = "Description 5", Price = 500 });
            _products.Add(new Product { Id = 6, Name = "Product 6", Description = "Description 6", Price = 600 });
        }
        public List<Product> GetProducts()
        {
            return _products;
        }
        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        
    }
}
