using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business
{
    public static class TestData
    {
        public static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product(1, "product1", 1.10m, "test product1", "testBrand1", "123abc",10),
            new Product(2, "product2", 10.10m, "test product2", "testBrand2", "123abc",30),
            new Product(3, "product3", 100.10m, "test product3", "testBrand1", "123abc",50),
            new Product(4, "product4", 1000.10m, "test product3", "testBrand2", "123abc",70),
            new Product(5, "product5", 1000.10m, "test product3", "testBrand3", "123abc",0),
            new Product(6, "product6", 1000.10m, "test product3", "testBrand1", "123abc",120),
            new Product(7, "product7", 1000.10m, "test product3", "testBrand1", "123abc",60),
            new Product(8, "Chair", 100.10m, "test product3", "testBrand", "123abc",15)
        };
        public static List<Department> Departments { get; set; } = new List<Department>()
        {
            new Department("Electronic", new List<Subdepartment>()
        {
            new Subdepartment("Tvs"),
            new Subdepartment("Speakers"),
            new Subdepartment("Headphones")
        }),
            new Department("Home", new List<Subdepartment>()
        {
            new Subdepartment("Tables"),
            new Subdepartment("Chairs"),
            new Subdepartment("Lamps")
        }),
            new Department("Meal", new List<Subdepartment>()
        {
            new Subdepartment("Fishes"),
            new Subdepartment("Fruits"),
            new Subdepartment("Vegtables")
        }),
        };
        
        public static List<Provider> GetProvider()
        {
            var providers = new List<Provider>();
            var p1 = new Provider(1, "Gamesa", "provedor@gamesa.com");
            p1.SetAddres("Islas 123", "Mexicali");
            p1.SetPhoneNumber("4731196870");
            providers.Add(p1);
            var p2 = new Provider(2, "Lg", "provedor@lg.com");
            p2.SetAddres("Islas 123", "Tijuana");
            p2.SetPhoneNumber("4731016884");
            providers.Add(p2);
            return providers;
        }
    }
}
