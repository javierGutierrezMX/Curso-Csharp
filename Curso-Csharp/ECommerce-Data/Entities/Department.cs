using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Data.Entities
{
    public class Department
    {
        public string Name{ get; private set; }
        public List<Subdepartment> Subdepartments { get; set; } = new List<Subdepartment>();

        public Department(string name, List<Subdepartment> subdepartments)
        {
           Name = name == null ? throw new InvalidOperationException("  Null value in \"name\"") : name;
            Subdepartments = subdepartments == null ? throw new InvalidOperationException("  Null value in \"subdepartments\"") : subdepartments;
        }
    }
}
