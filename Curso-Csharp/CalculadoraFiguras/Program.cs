using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LambdaExpressions
{
    class Program
    {

        static void Main(string[] args)
        {

            bool band = true;
            do
            {
                WriteLine("\tWelcome to HappyPet Hospital System");
                WriteLine("\nWhat do you want to do?"
                    + "\n 1.-Cuadrado"
                    + "\n 2.-Rectangulo"
                    + "\n 3.-Triangulo"
                    + "\n 4.-Circulo"
                    + "\n Please enter an option : "
                    );

                Int32.TryParse(ReadLine(), out int option);
                switch (option)
                {
                    case 1:
                        WriteLine("\nPlease enter your value: ");
                        double.TryParse(ReadLine(), out double inputC);
                        DelegateCalculator.Operator(option, inputC);
                        FunctionCalculator.Lambda(option, inputC);
                        break;
                    case 2:
                        WriteLine("\nPlease enter width: ");
                        double.TryParse(ReadLine(), out double inputR1);
                        WriteLine("\nPlease enter length: ");
                        double.TryParse(ReadLine(), out double inputR2);
                        DelegateCalculator.Operator(option, inputR1,inputR2);
                        FunctionCalculator.Lambda(option, inputR1, inputR2);
                        break;
                    case 3:

                        WriteLine("\nPlease enter value1 (start with the base): ");
                        double.TryParse(ReadLine(), out double inputT1);
                        WriteLine("\nPlease enter value2 (height): ");
                        double.TryParse(ReadLine(), out double inputT2);
                        WriteLine("\nPlease enter value3 (second side) : ");
                        double.TryParse(ReadLine(), out double inputT3);
                        WriteLine("\nPlease enter value3 (third side) : ");
                        double.TryParse(ReadLine(), out double inputT4);
                        DelegateCalculator.Operator(option, inputT1, inputT2, inputT3, inputT4);
                        FunctionCalculator.Lambda(option, inputT1, inputT2, inputT3, inputT4);
                        break;
                    case 4:
                        WriteLine("\nPlease enter your number: ");
                        double.TryParse(ReadLine(), out double inputCirc);
                        DelegateCalculator.Operator(option, inputCirc);
                        FunctionCalculator.Lambda(option, inputCirc);
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



    }

    class DelegateCalculator
    {
        public delegate double SelfOperatorCuadradoA(double x);
        public delegate double SelfOperatorCuadradoP(double x);
        public delegate double SelfOperatorRectanguloA(double x, double y);
        public delegate double SelfOperatorRectanguloP(double x, double y);
        public delegate double SelfOperatorTrainguloA(double x, double y);
        public delegate double SelfOperatorTrainguloP(double x, double z, double side3);
        public delegate double SelfOperatorCirculoA(double x);
        public delegate double SelfOperatorCirculoP(double x);



        public static void Operator(int option, double num, double num2 = 0, double num3 = 0, double num4 = 0)
        {
            switch (option)
            {
                case 1:
                    SelfOperatorCuadradoA squareA = new SelfOperatorCuadradoA(x => x * x);
                    SelfOperatorCuadradoP squareP = new SelfOperatorCuadradoP(x => 4 * x);
                    WriteLine("Delegate Area: " + squareA(num));
                    WriteLine("Delegate Perimetro: " + squareP(num));
                    break;
                case 2:
                    SelfOperatorRectanguloA rectA = new SelfOperatorRectanguloA((x, y) => x * y);
                    SelfOperatorRectanguloP rectP = new SelfOperatorRectanguloP((x, y) => (2*x) + (2*y));
                    WriteLine("Delegate Area: " + rectA(num, num2));
                    WriteLine("Delegate Perimetro: " + rectP(num, num2));
                    break;
                case 3:
                    SelfOperatorTrainguloA triangA = new SelfOperatorTrainguloA((x, y) => (x*y)/2);
                    SelfOperatorTrainguloP triangP = new SelfOperatorTrainguloP((x, y, side3) => x+y+side3);
                    WriteLine("Delegate Area: " + triangA(num, num2));
                    WriteLine("Delegate Perimetro: " + triangP(num, num3 , num4));
                    break;
                case 4:
                    SelfOperatorCirculoA cirA = new SelfOperatorCirculoA((x) => (Math.PI * Math.Sqrt(x)));
                    SelfOperatorCirculoP cirP = new SelfOperatorCirculoP((x) => 2*Math.PI*x);
                    WriteLine("Delegate Area " + cirA(num));
                    WriteLine("Delegate Perimetro: " + cirP(num));
                    break;
                default:
                    WriteLine("Invalid numbers!!!");
                    break;

            };
        }
    }

    class FunctionCalculator
    {
        public static void Lambda(int option, double num, double num2 = 0, double num3 = 0, double num4 = 0)
        {
            switch (option)
            {
                case 1:
                    Func<double, double> squareA = (x => x * x);
                    Func<double, double> squareP = (x => 4 * x);
                    WriteLine("Func Area: " + squareA(num));
                    WriteLine("Func Perimetro: " + squareP(num));
                    break;
                case 2:
                    Func<double, double, double> rectA =  ((x, y) => x * y);
                    Func<double, double, double> rectP =  ((x, y) => (2 * x) + (2 * y));
                    WriteLine("Func Area: " + rectA(num, num2));
                    WriteLine("Func Perimetro: " + rectP(num, num2));
                    break;
                case 3:
                    Func<double, double, double> triangA =  ((x, y) => (x * y) / 2);
                    Func<double, double, double, double> triangP =  ((x, y, side3) => x + y + side3);
                    WriteLine("Func Area: " + triangA(num, num2));
                    WriteLine("Func Perimetro: " + triangP(num, num3,num4));
                    break;
                case 4:
                    Func<double, double> cirA =  ((x) => (Math.PI * Math.Sqrt(x)));
                    Func<double, double> cirP =  ((x) => 2 * Math.PI * x);
                    WriteLine("Func Area " + cirA(num));
                    WriteLine("Func Perimetro: " + cirP(num));
                    break;
                default:
                    WriteLine("Invalid numbers!!!");
                    break;
            };








        }

    }
    class ActionCalculator
    {
        public static void ActionLambda(double x, double y)
        {
            Action<double, double> addition = (x, y) => 
            {
                WriteLine(x + y);
            };
            addition(x, y);
        }
       
    }
}

