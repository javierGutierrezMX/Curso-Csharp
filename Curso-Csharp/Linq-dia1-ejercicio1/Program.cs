using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;

namespace Linq_dia1_ejercicio1
{
    class Program
    {
        #region Lists
        private static List<Student> students = new List<Student>
            {
                new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };
        // Find the words in the collection that start with the letter 'L'
        //private static List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

        // Which of the following numbers are multiples of 4 or 6
        // private static List<int> mixedNumbers = new List<int>()
        // {
        //     15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        // };

        // Output how many numbers are in this list
        // private static List<int> numbers = new List<int>()
        // {
        //     15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        // };


        //private static List<Customer> customers = new List<Customer>() {
        //        new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
        //        new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
        //        new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
        //        new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
        //        new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
        //        new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
        //        new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
        //        new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
        //        new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
        //        new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        //    };

        //private static string[] cities =
        //    {
        //        "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
        //    };

        //private static int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

        #endregion

        static void Main(string[] args)
        {
            #region 1
            //WriteLine("Find the words in the collection that start with the letter 'L'");
            //var fruitsL = fruits.Where(f => f.StartsWith("L"));
            //foreach (var f in fruitsL)
            //{
            //    WriteLine(f);
            //}
            //WriteLine("Which of the following numbers are multiples of 4 or 6");
            //var multi4or6 = mixedNumbers.Where(n => n%4 == 0 || n%6 == 0);
            //foreach (var n in multi4or6)
            //{
            //    WriteLine(n);
            //}
            //WriteLine("\nOutput how many numbers are in this list");
            //var amountNumbers = numbers.Count();
            //    WriteLine(amountNumbers);
            #endregion

            #region 2
            //cuantos milloranios hay por banco
            //WriteLine("\tcuantos milloranios hay por banco");
            //var millonariosXbanco = customers.Where(c => c.Balance >= 1000000).GroupBy(c => c.Bank);
            //foreach(var b in millonariosXbanco)
            //{
            //    WriteLine(b.Key);
            //    foreach (var m in b)
            //    {
            //        WriteLine($"Customer: {m.Name} Amount : {m.Balance} ");
            //    }
            //}
            ////clientes con balance mayor a 100,000
            //WriteLine("\n\n\n\tclientes con balance mayor a 100,000");
            //var customerPlus100 = customers.Where(c => c.Balance >= 100000).GroupBy(c => c.Bank);
            //foreach (var b in customerPlus100)
            //{
            //    WriteLine(b.Key);
            //    foreach (var m in b)
            //    {
            //        WriteLine($"Customer: {m.Name} Amount : {m.Balance} ");
            //    }
            //}
            ////ordenar a los clientes por su balance
            //WriteLine("\n\n\n\tclientes con balance mayor a 100,000");
            //var customerOrderBalance = from c in customers
            //                           orderby c.Balance descending
            //                           select c;
            //foreach (var c in customerOrderBalance)
            //{
            //    WriteLine($"Customer: {c.Name} Amount : {c.Balance} ");
            //}
            ////sumatoria de riqueza por cada banco
            //WriteLine("\n\n\n\tsumatoria de riqueza por cada banco");
            //var sumMoney = customers.GroupBy(c => c.Bank).Select(s => new { Name = s.Key, Amount = s.Sum(c => c.Balance) });

            //foreach (var b in sumMoney)
            //{
            //        WriteLine($"Bank: {b.Name} Amount : {b.Amount} ");
            //}
            //// nombre de clientes que su balance sea menor a 100,000 y su banco (3 char)
            //WriteLine("\n\n\n\tnombre de clientes que su balance sea menor a 100,000 y su banco");
            //var customerMinus100 = customers.Where(c => c.Balance <= 100000).GroupBy(c => c.Bank);
            //foreach (var b in customerMinus100)
            //{
            //    WriteLine(b.Key);
            //    foreach (var m in b)
            //    {
            //        WriteLine($"Customer: {m.Name} Amount : {m.Balance} ");
            //    }
            //}
            #endregion

            #region 3
            //// B.1 Find the string which starts and ends with a specific character : AM
            //WriteLine("\tB.1 Find the string which starts and ends with a specific character : AM");
            //var citiesQ = cities.Where(c => c.StartsWith("AM") && c.EndsWith("AM")).Select(c => $"Name : {c}").ToList();
            //citiesQ.ForEach(c => WriteLine(c));

            //// B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            //WriteLine("\n\n\n\tB.2 Write a program in C# Sharp to display the list of items in the array according " +
            //          "\n\tto the length of the string then by name in ascending order.");
            //var citiesQ2 = cities.OrderBy(c => c.Replace(" ", "").Length).Select(c => $"Citie : {c} Amount of character: {c.Replace(" ", "").Length}").Reverse().ToList();
            //citiesQ2.ForEach(c => WriteLine(c));
            //// B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.
            //WriteLine("\n\n\n\tB.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.");
            //var citiesQ3 = cities.GroupBy(c => c.Length).Select(s => new { Name = s.Key, Citie = s }).ToList();
            //citiesQ3.ForEach(c => {
            //    WriteLine(c.Name);
            //    foreach (var item in c.Citie)
            //    {
            //        WriteLine(item);
            //    }
            //});
            #endregion

            #region 4

            //// C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            //WriteLine("C.1 Write a program in C# Sharp to display the number and frequency of number from given array.");
            //var arr1Q = arr1.GroupBy(c => c).Select(s => new { Num = s.Key, Amount = s.Count() }).ToList();
            //arr1Q.ForEach(c => WriteLine($"Number : {c.Num} Amount : {c.Amount}"));

            //// C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
            //WriteLine("\n\nC.2 Write a program in C# Sharp to display a list of unrepeated numbers.");
            //var arr1Q2 = arr1.GroupBy(c => c).Select(s => new { Num = s.Key, Amount = s.Count() }).Where(n => n.Amount == 1).ToList();
            //arr1Q2.ForEach(c => WriteLine($"Number : {c.Num} "));

            //// C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            //WriteLine("\n\nC.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.");
            //var arr1Q3 = arr1.GroupBy(c => c).Select(s => new { Num = s.Key, Amount = s.Count(), Mult = s.Key * s.Count() }).ToList();
            //arr1Q3.ForEach(c => WriteLine($"Number : {c.Num} Amount : {c.Amount} Mult : {c.Mult}"));
            #endregion

            #region 5
            // D.1 Get the top student of the list making an average of their scores.
            WriteLine("D.1 Get the top student of the list making an average of their scores.");
            var studentsQ = students.OrderByDescending(s => s.Scores.Average()).Select(s => $" Alumno: {s.FirstName}  {s.LastName} Promedio : {s.Scores.Average()}").FirstOrDefault();
            WriteLine(studentsQ);
            // D.2 Get the student with the lowest average score.
            WriteLine("D.2 Get the student with the lowest average score.");
            var studentsQ2 = students.OrderBy(s => s.Scores.Average()).Select(s => $" Alumno: {s.FirstName}  {s.LastName} Promedio : {s.Scores.Average()}").FirstOrDefault();
            WriteLine(studentsQ2);
            // D.3 Get the last name of the student that has the ID 117
            WriteLine("D.3 Get the last name of the student that has the ID 117");
            var studentsQ3 = students.Single(s => s.ID == 117);
            WriteLine($" LastName: {studentsQ3.LastName} ");
            // D.4 Get the first name of the students that have any score more than 90
            WriteLine("D.4 Get the first name of the students that have any score more than 90");
            var studentsQ4 = students.Where(x => x.Scores.Any(x => x >= 90)).FirstOrDefault();
            WriteLine($" LastName: {studentsQ4.FirstName} ");

            #endregion
        }
        //internal class Customer
        //{
        //    public string Name { get; internal set; }
        //    public double Balance { get; internal set; }
        //    public string Bank { get; internal set; }
        //}
        internal  class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public List<int> Scores { get; set; }
        }
    }

}

