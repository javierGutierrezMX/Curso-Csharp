using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Data.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Stock { get;  set; }
        public decimal Price { get; private set; }
        public string Sku { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public Subdepartment Subdepartment { get;  set; }

        public Product() { }
        public Product(int id, string name, decimal price, string description, string brand, string sku, int stock = 1)
        {
            Id = id;
            Name = name == null ? throw new InvalidOperationException(" Null value in  \"Name\"") : name;
            Price = price < 0 ? throw new InvalidOperationException(" Price less than 0") : price;
            Description = description == null ? throw new InvalidOperationException("  Null value in \"description\"") : description;
            Brand = brand == null ? throw new InvalidOperationException("  Null value in  \"brand\"") : brand;
            Sku = sku == null ? throw new InvalidOperationException("  Null value in  \"sku\"") : sku;
            Stock = stock < 0 ? throw new InvalidOperationException(" Price less than 0") : stock;
        }

        public void AddSubd(Subdepartment subd)
        {
            Subdepartment = subd == null ? throw new InvalidOperationException(" subd null") : subd;
        }
    }
}
