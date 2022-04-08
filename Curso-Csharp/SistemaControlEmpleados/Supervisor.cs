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
    public class Supervisor : User
    {
        public void CRUD(List<Employee> list)
        {
            var band = true;
            do
            {
                WriteLine("\nWhat do you want to do?"
                     + "\n 1.-See Employees"
                     + "\n 2.-Add Employee"
                     + "\n 3.-Delete Employee"
                     + "\n 4.-Edit Employee"
                     + "\n Please enter an option : "
                     );

                Int32.TryParse(ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        foreach (var item in list)
                        {
                            WriteLine($"Id : {item.Id}  Name : {item.Name}   Pending check : {item.PendingHours}");
                        }
                        break;
                    case 2:
                        WriteLine("Id: ");
                        Int32.TryParse(ReadLine(), out int id);
                        WriteLine("Name: ");
                        var name = ReadLine();
                        WriteLine("Pass: ");
                        var pass = ReadLine();
                        Employee tempNew = new Employee() {Id = (int) id, Name = name, Pass = pass, EntryDate = DateTime.Today, isSupervisor = false};
                        list.Add(tempNew);
                        WriteLine("Employee added succefully!!");
                        break;
                    case 3:
                        WriteLine("Id: ");
                        Int32.TryParse(ReadLine(), out int idDelete);
                        var tempDelete = list.Where(x => x.Id == idDelete).FirstOrDefault();
                        list.Remove(tempDelete);
                        WriteLine("Employee deleted succefully!!");
                        break;
                    case 4:
                        WriteLine("Id of Employee: ");
                        Int32.TryParse(ReadLine(), out int idEdit);
                        var tempEdit1 = list.Where(x => x.Id == idEdit).FirstOrDefault();
                        WriteLine("New Name: ");
                        var nameEdit = ReadLine();
                        WriteLine("New Pass: ");
                        var passEdit = ReadLine();
                        Employee tempEdit2 = new Employee() { Id = idEdit, Name = nameEdit, Pass = passEdit, EntryDate = tempEdit1.EntryDate, isSupervisor = false };
                        list.Remove(tempEdit1);
                        list.Add(tempEdit2);
                        WriteLine("Employee edited succefully!!");
                        break;
                    default:
                        WriteLine("Invalid option!!!");
                        break;

                };
                WriteLine("Do you want to do something else? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);
        }

        public void ValidateHours(Employee emp)
        {
            WriteLine("The pending hours are ok? (y/n): ");
            var respond = ReadLine();
            if (respond != "n")
            {
                emp.RegistredWeeks.Last().isChecked = true;
                emp.RegistredWeeks.Last().isAproved = true;
            }
            else
            {
                emp.RegistredWeeks.Last().isChecked = true;
                emp.RegistredWeeks.Last().isAproved = false;
            }
            WriteLine("The task is done!!!");
        }
    }
}
