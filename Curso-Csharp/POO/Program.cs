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

namespace POO
{
    class Program
    {
        static void Main(string[] args)
        {
            Polygon polygon = new Polygon() { Base = 5.5m, Height= 4.5m };
            WriteLine("Polygono base: " + polygon.GetArea());
            Square square = new Square() { Base = 5 };
            WriteLine("Cuadrado: " + square.GetArea());
            Triangle triangle = new Triangle() { Base = 5, Height = 10 };
            WriteLine("Triangulo: " + triangle.GetArea());

        }
    }
    /// <summary>
    ///  virtual no obliga a la modificacion, abstract si.
    /// </summary>
    class   Polygon
    {
        public decimal Base { get; set; }
        public decimal? Height { get; set; }

        public virtual decimal GetArea() { return Base * (decimal) Height; }
        
    }

    class Square : Polygon
    {
        public override decimal GetArea() {  return Base * Base;}
    }

    class Triangle : Polygon
    {
        public override decimal GetArea() {return base.GetArea(); }
    }
}
