using ECommerce_Business.Services.Abstractions;
using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Services.Implementations
{
    public class DepartmentServices : IDepartmentServices
    {
        public static List<Department> Departments { get; set; } = TestData.Departments;
        public List<Department> GetDepartments()
        {
            return Departments;
        }
        public List<Subdepartment> GetSubdepartments(Department dep)
        {
            return dep.Subdepartments;
        }
    }
}
