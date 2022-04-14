
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;

namespace LinQ_dia1
{
    class Program
    {
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
            static void Main(string[] args)
             {
            //int[] scores = { 51, 56, 84, 12 };
            //var scoresQuery = (from c in scores
            //                 where c > 55
            //                 select c).ToList();
            //foreach (var item in scoresQuery)
            //{
            //    WriteLine(item);
            //}
            WriteLine("1");
            var studentQuery = from s in students
                               where s.Scores.Average() > 85
                               orderby s.Scores.Average() descending
                               select s;
            foreach (var item in studentQuery)
            {
                WriteLine($"Alumno: {item.FirstName} {item.LastName} Promedio: {item.Scores.Average()}");
            }
            WriteLine("2");
            var studentQuery2 = from student in students
                               group student by student.LastName[0]
                               into studentGroup
                               orderby  studentGroup.Key 
                               select studentGroup;
            var studentQuery2Lambda = students
                .GroupBy(s => s.LastName[0])
                .OrderBy(s => s.Key);


            foreach (var sg in studentQuery2Lambda)
            {
                WriteLine(sg.Key);
                foreach (var s in sg)
                {
                    WriteLine($"Alumno: {s.FirstName} {s.LastName} ");
                }
                
            }
            WriteLine("3");
            var studentQuery3 = from s in students
                                let totalScore = s.Scores.Sum()
                                where totalScore / 4 < s.Scores[0]
                                select $"Alumno {s.FirstName} {s.LastName}";
            foreach (var item in studentQuery3)
            {
                WriteLine(item);
            }
            WriteLine("4.-mayores a 80");
            var studentQuery4 = from s in students
                               where s.Scores.All(x => x >80)
                               select s;
            foreach (var item in studentQuery4)
            {
                WriteLine($"Alumno: {item.FirstName} {item.LastName} ");
            }
            WriteLine("5");
            var sq5 = students
                .Where(s => s.Scores.Sum() > (80 / 4))
                .Select(s => new
                {
                    Id = s.ID,
                    Score = s.Scores.Sum()
                } );
            foreach (var item in sq5)
            {
                WriteLine($"Id: {item.Id} {item.Score} ");
            }

        }
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public List<int> Scores { get; set; }
        }
    }
}
