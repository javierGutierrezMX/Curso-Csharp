using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using System.Threading;
using Newtonsoft.Json;

namespace SistemaControlEmpleados
{
    public static class Seed
    {
        public static string YearCelebrationMessage { get; set; } = "Congratulation today one year go we started this jounrey.!!!";
        public static string AccessDenied { get; set; } = "User or Pass incorrect";
        public static string WelcomMessage { get; set; } = "Welcome : ";

        public static List<User> GetUsers()
        {
            var list = new List<User>()
              {
            new Employee(){Id = 1, Name = "Javier", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = false},
            new Supervisor(){Id = 2,Name = "Catalino", Pass = "123", EntryDate = DateTime.Today.AddDays(3), isSupervisor = true},
            new Employee(){Id = 3,Name = "Cheto", Pass = "123", EntryDate = DateTime.Today.AddDays(5), isSupervisor = false},
            new Employee(){Id = 4,Name = "Michi", Pass = "123", EntryDate = DateTime.Today.AddDays(2), isSupervisor = false},
            new Supervisor(){Id = 5,Name = "Ilse", Pass = "123", EntryDate = DateTime.Today, isSupervisor = true},
            new Employee(){Id = 6,Name = "Carlos", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = false}
             };
            return list;
        }
        public static List<Employee> GetEmployee(List<User> list)
        {
            var tempEmp = list.Where(x => x.GetType() == typeof(Employee)).ToList();
            List<Employee> employees = new List<Employee>();
            foreach (var item in tempEmp)
            {
                var serializedParent = JsonConvert.SerializeObject(item);
                Employee c = JsonConvert.DeserializeObject<Employee>(serializedParent);
                employees.Add(c);
            }
            return employees;
        }
    }
}
