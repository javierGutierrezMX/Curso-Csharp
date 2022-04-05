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
                    + "\n 1.-Square"
                    + "\n 2.-Adition"
                    + "\n 3.-Substraction"
                    + "\n 4.-Multi"
                    + "\n 5.-Div"
                    + "\n 6.-Sin"
                    + "\n 7.-Cos"
                    + "\n Please enter an option : "
                    );

                Int32.TryParse(ReadLine(), out int option);
                if (option == 1 || option == 6 || option==7)
                {
                    WriteLine("\nPlease enter your info number: ");
                    double.TryParse(ReadLine(), out double input);
                    DelegateCalculator.Operator(option, input);
                    FunctionCalculator.Lambda(option, input);
                }
                else
                {
                    
                    WriteLine("\nPlease enter your first number : ");
                    double.TryParse(ReadLine(), out double input);
                    WriteLine("\nPlease enter your second number : ");
                    double.TryParse(ReadLine(), out double input2);
                    DelegateCalculator.Operator(option, input, input2);
                    FunctionCalculator.Lambda(option, input, input2);
                }

                WriteLine("Do you want to do something else? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);

        }

        
    
    }

    class DelegateCalculator
    {
        public delegate double SelfOperatorSquare(double x);
        public delegate double SelfOperatorAdition(double x, double y);
        public delegate double SelfOperatorSubstrac(double x, double y);
        public delegate double SelfOperatorMulti(double x, double y);
        public delegate double SelfOperatorDivision(double x, double y);
        public delegate double SelfOperatorSin(double x);
        public delegate double SelfOperatorCos(double x);



        public static void Operator(int option, double num, double num2 = 0)
        {
            switch (option)
            {
                case 1:
                    SelfOperatorSquare square = new SelfOperatorSquare(x => x * x);
                    WriteLine("Delegate : " + square(num));
                    break;
                case 2:
                    SelfOperatorAdition adition = new SelfOperatorAdition((x, y) => x + y);
                    WriteLine("Delegate : " + adition(num, num2));
                    break;
                case 3:
                    SelfOperatorSubstrac substraction = new SelfOperatorSubstrac((x, y) => x - y);
                    WriteLine("Delegate : " + substraction(num, num2));
                    break;
                case 4:
                    SelfOperatorMulti multi = new SelfOperatorMulti((x, y) => x * y);
                    WriteLine("Delegate : " + multi(num, num2));
                    break;
                case 5:
                    SelfOperatorDivision divition = new SelfOperatorDivision((x, y) => x / y);
                    var result = num2 != 0 ? divition(num, num2).ToString() : "Imposible!! divisor is 0";
                    WriteLine("Delegate : " + result);
                    break;
                case 6:
                    SelfOperatorSin sin = new SelfOperatorSin(x => Math.Sin(x));
                    WriteLine("Delegate : " + sin(num));
                    break;
                case 7:
                    SelfOperatorCos cos = new SelfOperatorCos(x => Math.Cos(x));
                    WriteLine("Delegate : " + cos(num));
                    break;
                default:
                    WriteLine("Invalid numbers!!!");
                    break;

            };   
        }
    }
    class FunctionCalculator
    {
        public static void Lambda(int option, double x, double y = 0)
        {
            switch (option)
            {
                case 1:
                    Func<double, double> sqr = (x=> x *x);
                    WriteLine("Func : " + sqr(x));
                    break;
                case 2:
                    Func<double, double, double> addition = ((x, y) => x + y);
                    WriteLine("Func : " + addition(x, y));
                    break;
                case 3:
                    Func<double, double, double> substrac = ((x, y) => x - y);
                    WriteLine("Func : " + substrac(x, y));
                    break;
                case 4:
                    Func<double, double, double> multi = ((x, y) => x * y);
                    WriteLine("Func : " + multi(x, y));
                    break;
                case 5:
                    Func<double, double, double> div = ((x, y) => x / y);
                    var result = y != 0 ? div(x, y).ToString() : "Imposible!! divisor is 0";
                    WriteLine("Func : " + result);
                    break;
                case 6:
                    Func<double, double> Sen = (x => Math.Sin(x));
                    WriteLine("Func : " + Sen(x));
                    break;
                case 7:
                    Func<double, double> Cos = (x => Math.Cos(x));
                    WriteLine("Func : " + Cos(x));
                    break;
                default:
                    WriteLine("Invalid numbers!!!");
                    break;
            };


            





        }
        
    }
}
