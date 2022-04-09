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
    class Program
    {
        static void Main(string[] args)
        {
            //cambiar list
            var list = Seed.GetUsers();
            var employees = Seed.GetEmployee(list);
            var band = true;
            do
            {
                WriteLine("\tWelcome to the HourManager System.");
                WriteLine("\nSign In......");
                WriteLine("Name: ");
                var name = ReadLine();
                WriteLine("Pass: ");
                var pass = ReadLine();
                User u = new User();
                Tuple<bool, User> result = u.SignIn(name, pass, list);
                bool canPass = result.Item1;
                u = result.Item2;
                //user != null, y borramos la tupla en sign in, try catch, con excepcion en signin
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
                                    sup.ValidateHours(employees);
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
                        WriteLine("Register your hours...");
                        WriteLine("Hours of this week: ");
                        Int32.TryParse(ReadLine(), out int hours);
                        WriteLine("what did you do ?: ");
                        var description = ReadLine();
                        empOld.SetHoursOfWeek(hours, description);
                        var empNew = empOld;
                        employees.Remove(empOld);
                        employees.Add(empNew);
                        WriteLine("Submitted!!");
                    }
                }
                WriteLine("Do you want to return to Sign in menu? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            } while (band == true);
        }
    }
}
