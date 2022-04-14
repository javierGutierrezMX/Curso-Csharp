using ECommerce_Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_Business.Services.Abstractions
{
    interface IDepartmentServices
    {
        public List<Department> GetDepartments();
        public List<Subdepartment> GetSubdepartments(Department dep);
    }
}
