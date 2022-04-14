using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Services.Abstractions
{
    public interface IProductService
    {

        public List<Product> GetProducts();
        //public List<Department> GetDepartments();
        //public List<Subdepartment> GetSubdepartments(Department dep);
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void EditProdcut(Product product);
        public void DeleteProduct(int id);
    }
}
