using System;
using System.Collections.Generic;

namespace Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> predciate = new Predicate<int>(GetPairs);
            Predicate<int> predciate2 = new Predicate<int>(GetNotPairs);

            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            List<int> resultPairs = list.FindAll(predciate);
            List<int> resultNotPairs = list.FindAll(predciate2);

            Console.WriteLine("Numeros pares\n");
            foreach (var item in resultPairs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\t================================\n");
            Console.WriteLine("Numeros primos");
            foreach (var item in resultNotPairs)
            {
                Console.WriteLine(item);
            }

            static bool GetPairs(int num)
            {
                return num % 2 == 0 ? true : false;
            }
            static bool GetNotPairs(int num)
            {
                //variable auxiliar para guardar el resultado de la evaluacion
                bool esPrimo = true;

                //se divide el numero n entre todos los numeros anteriores
                if (num == 2) esPrimo = false;
                else
                {
                    for (int i = 2; i < num; i++)
                    {
                        //si el modulo de la division es 0 entonces el numero no es primo
                        //se marca la variable esPrimo como false y se termina el for
                        if (num % i == 0) esPrimo = false;


                    }
                }
                return esPrimo;
            }
        }
    }
}
