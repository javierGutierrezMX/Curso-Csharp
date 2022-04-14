using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Data.Entities
{
    public class Subdepartment
    {
        public string Name { get; set; }
        public Department Department { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public Subdepartment(string name)
        {
            Name = name == null ? throw new InvalidOperationException("  Null value in \"name\"") : name;
        }
        public void AddDep(Department dep)
        {
            this.Department = dep;
        }
        
    }
}
