using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var domain = "https://www.something.com";

            Regex regex = new Regex("^https?://(www.)?([\\w]+)((\\.[A-Za-z]{2,3})+)$");
            WriteLine(regex.IsMatch(domain));

            var phone = "+52 (686) 405 4720";

            Regex regexphone = new Regex(@"^\+\d{2}\s\(\d{3}\)\s\d{3}\s\d{4}");
            WriteLine(regexphone.IsMatch(phone));

            WriteLine("Ingresa contraseña: ");
            var pass = ReadLine();

            Regex regexpass = new Regex(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})\S*$");
            WriteLine(regexpass.IsMatch(pass));

        }
    }
}
