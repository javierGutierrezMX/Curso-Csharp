using ECommerce_Business.Services.Abstractions;
using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce_Business.Services.Implementations
{
    public class ProductService : IProductService
    {

        public  List<Product> Products { get; set; } = TestData.Products;
        public  List<Department> Departments { get; set; } = TestData.Departments;

        public void AddProduct(Product product)
        {
            try
            {
                Products.Add(product);
            }
            catch (Exception e)
            {
                e = new InvalidOperationException("No Add");
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var product = Products.FirstOrDefault(p => p.Id == id);
                if(product != null)
                Products.Remove(product);
                else
                    throw new InvalidOperationException("No Delete");
            }
            catch (Exception e)
            {
                e = new InvalidOperationException("No Delete");
                throw;
            }
        }

        public void EditProdcut(Product product)
        {
            try
            {
                DeleteProduct(product.Id);
                AddProduct(product);
            }
            catch (Exception e)
            {
                e = new InvalidOperationException("No Edit");
                throw;
            }
        }

        public Product GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            return product != null ? product : throw new InvalidOperationException("No Found"); ;
        }

        public List<Product> GetProducts()
        {
            Departments.ForEach(d => d.Subdepartments.ForEach(sd => sd.AddDep(d)));
            var tempsd = Departments.Where(d => d.Name == "Home").FirstOrDefault().Subdepartments.Select(sb => sb).FirstOrDefault();
            Products.ForEach(p => p.Subdepartment = p.Subdepartment != null ? p.Subdepartment : tempsd);
            return Products;
        }
       

       
    }
}
