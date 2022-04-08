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
    class Program
    {
        static void Main(string[] args)
        {
            var list =  new List<User> () 
              {
            new Employee(){Id = 1, Name = "Javier", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = false},
            new Supervisor(){Id = 2,Name = "Catalino", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = true},
            new Employee(){Id = 3,Name = "Cheto", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = false},
            new Employee(){Id = 4,Name = "Michi", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = false},
            new Supervisor(){Id = 5,Name = "Ilse", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = true},
            new Employee(){Id = 6,Name = "Carlos", Pass = "123", EntryDate = DateTime.Today.AddDays(1), isSupervisor = false}
             };

            var tempEmp = list.Where(x => x.GetType() == typeof(Employee)).ToList();
            List<Employee> employees = new List<Employee>();
            foreach (var item in tempEmp)
            {
                var serializedParent = JsonConvert.SerializeObject(item);
                Employee c = JsonConvert.DeserializeObject<Employee>(serializedParent);
                employees.Add(c);
            }

            var band = true;
            do
            {
                WriteLine("Name: ");
                var name = ReadLine();
                WriteLine("Pass: ");
                var pass = ReadLine();
                User u = new User();
                var canPass = u.SignIn(name, pass, list).Item1;
                u = u.SignIn(name, pass, list).Item2;
                
                if (canPass)
                {
                    if (u.isSupervisor)
                    {
                        var userS = JsonConvert.SerializeObject(u);
                        Supervisor sup = JsonConvert.DeserializeObject<Supervisor>(userS);


                        var band2 = true;
                        do
                        {
                            WriteLine("\nWhat do you want to do?"
                                 + "\n 1.-CRUD options"
                                 + "\n 2.-Validate Hours"
                                 + "\n Please enter an option : "
                                 );

                            Int32.TryParse(ReadLine(), out int option);
                            switch (option)
                            {
                                case 1:
                                    sup.CRUD(employees);
                                    break;
                                case 2:
                                    WriteLine("Id: ");
                                    Int32.TryParse(ReadLine(), out int idDelete);
                                    var tempValidate = employees.Where(x => x.Id == idDelete).FirstOrDefault();
                                    sup.ValidateHours(tempValidate);
                                    break;
                                default:
                                    WriteLine("Invalid option!!!");
                                    break;

                            };
                            WriteLine("Do you want to do something else? (y/n)");
                            var respond2 = ReadLine();
                            if (respond2 == "n") band2 = false;
                        }
                        while (band2 == true);
                        
                    }
                    else
                    {
                        Employee empOld = employees.Where(x => x.Id == u.Id).FirstOrDefault();

                        WriteLine("Hours of this week: ");
                        Int32.TryParse(ReadLine(), out int hours);
                        empOld.SetHoursOfWeek(hours);
                        var empNew = empOld;
                        employees.Remove(empOld);
                        employees.Add(empNew);
                        WriteLine("Sended!!");
                    }
                }


                WriteLine("Do you want to do something else? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            } while (band == true);

        }
    }
}


