using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
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
                        PrintEmployee(list);
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
                        PrintEmployee(list);
                        break;
                    case 3:
                        PrintEmployee(list);
                        WriteLine("Id: ");
                        Int32.TryParse(ReadLine(), out int idDelete);
                        var tempDelete = list.Where(x => x.Id == idDelete).FirstOrDefault();
                        list.Remove(tempDelete);
                        WriteLine("Employee deleted succefully!!");
                        PrintEmployee(list);
                        break;
                    case 4:
                        PrintEmployee(list);
                        WriteLine("Id of Employee: ");
                        Int32.TryParse(ReadLine(), out int idEdit);
                        var tempEdit1 = list.Where(x => x.Id == idEdit).FirstOrDefault();
                        WriteLine("New Name: ");
                        var nameEdit = ReadLine();
                        WriteLine("New Pass: ");
                        var passEdit = ReadLine();
                        // no borrar y editar elemento de lista
                        Employee tempEdit2 = new Employee() { Id = idEdit, Name = nameEdit, Pass = passEdit, EntryDate = tempEdit1.EntryDate, isSupervisor = false };
                        list.Remove(tempEdit1);
                        list.Add(tempEdit2);
                        WriteLine("Employee edited succefully!!");
                        PrintEmployee(list);
                        break;
                    default:
                        WriteLine("Invalid option!!!");
                        break;

                };
                WriteLine("Do you want to return to CRUD menu (y) or validate hours (n)? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);
        }

        public void ValidateHours(List<Employee> list)
        {
            WriteLine("Select an Employee for approve the hours: ");
            PrintEmployee(list);
            WriteLine("Id for approve : ");
            Int32.TryParse(ReadLine(), out int idValidate);
            var tempValidate = list.Where(x => x.Id == idValidate).FirstOrDefault();
            if (tempValidate != null)
            {
                PrintEmployeeHours(tempValidate.RegistredWeeks);
                WriteLine($"The pending hours ( {tempValidate.WeekInProgress.AmountHours} ) from {tempValidate.Name} are ok? (y/n): ");
                var respond = ReadLine();
                if (respond != "n")
                {
                    tempValidate.RegistredWeeks.Last().isChecked = true;
                    tempValidate.RegistredWeeks.Last().isAproved = true;
                }
                else
                {
                    tempValidate.RegistredWeeks.Last().isChecked = true;
                    tempValidate.RegistredWeeks.Last().isAproved = false;
                }
                WriteLine("The task is done!!!");
            }
            else WriteLine("Error with the selected id, try it again");
        }
        protected void PrintEmployee(List<Employee> list)
        {
            foreach (var item in list)
            {
                WriteLine($"Id : {item.Id} ---" +
                          $" Name : {item.Name} ---" +
                          $"  Pending check : {item.PendingHours} ---");
            }
        }
        protected void PrintEmployeeHours(List<RegistredWeeks> list)
        {
            foreach (var item in list)
            {
                WriteLine($"" +
                    $"Hours : {item.AmountHours}  " +
                    $"Description : {item.Description}  " +
                    $"Date : {item.RegisDate.ToShortDateString()} " +
                    $"Check : {(item.isChecked ? "Yes" : "No")} " +
                    $"Approved: { (item.isAproved ? "Yes" : "No")} ");
            }
        }
    }
}
