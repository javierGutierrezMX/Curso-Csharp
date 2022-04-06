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
namespace DesafioParalelo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool band = true;
            do
            {
                WriteLine("\tExamen con tiempo");
                WriteLine("\nTienes 15 seg para responder 3 pregutnas:");
                WriteLine("\nPresiona cualquier tecla para comenzar");
                ReadLine();

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var task1 = Process1(stopwatch);
                var task2 = Process2();
                await Task.WhenAny(task1, task2);
                stopwatch.Stop();

                WriteLine("Quieres intentarlo otra vez? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);
            
        }

        public static async Task Process1(Stopwatch time)
        {
            try
            {
                await Task.Run(() =>
                {
                    WriteLine("1.- Un kilometro tiene: "
                        + "\na.- 1 metro"
                        + "\nb.- 100 metros"
                        + "\nc.- 1000 metros"
                        );

                    Char.TryParse(ReadLine(), out char q1);
                });
                if (((time.ElapsedMilliseconds) / 1000) < 5)
                {
                    await Task.Run(() =>
                {
                    WriteLine("2.- Un perro : "
                        + "\na.- ladra"
                        + "\nb.- muje"
                        + "\nc.- grazna"
                        );

                    Char.TryParse(ReadLine(), out char q2);
                });
                }
                if (((time.ElapsedMilliseconds) / 1000) < 5)
                {
                    await Task.Run(() =>
                    {
                        WriteLine("3.- La  ser humano es: "
                        + "\na.- mamifero"
                        + "\nb.- reptil"
                        + "\nc.- anfibio"
                        );
                        Char.TryParse(ReadLine(), out char q3);
                    });
                }
                    if (((time.ElapsedMilliseconds) / 1000) < 5)
                        WriteLine("el examen ha terminado. restan: " + (time.ElapsedMilliseconds) / 1000 + " segundos. \n");
            }
            catch (OperationCanceledException)
            {
                WriteLine("\nTasks cancelled: timed out.\n");
            }
        }
        public static async Task Process2()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                   WriteLine("Se acabo el tiempo!!!.");
            }
                );
        }
    }
}

