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

namespace SistemaControlEmpleados
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public DateTime EntryDate { get; set; }
        public bool isSupervisor { get; set; }
        public Tuple<bool, User> SignIn(string name, string pass, List<User> list)
        {
            var user = list.Where(x => x.Name == name && x.Pass == pass).FirstOrDefault();
            if (user != null)
            {
                WriteLine(Seed.WelcomMessage + user.Name + (user.isSupervisor ? " (Supervisor) " : ""));
                if (user.EntryDate == DateTime.Today)
                    WriteLine(Seed.YearCelebrationMessage);
                return new Tuple<bool, User>(true, user);
            }
            else
            {
                WriteLine(Seed.AccessDenied);
                return new Tuple<bool, User>(false, user);
            }
        }
    }
}
