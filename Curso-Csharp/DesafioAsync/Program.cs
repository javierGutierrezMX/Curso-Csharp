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

namespace DesafioAsync
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            bool band = true;
            do
            {
                WriteLine("\tOrganizador de eventos");
            WriteLine("Nombre de su evento: ");
            var eventName = ReadLine();
            WriteLine("Fecha de su evento  (MM/dd/yyyy): ");
                if (!DateTime.TryParseExact(ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime eventDate))
                {
                    WriteLine("Fecha invalida\n");
                    continue;
                }
            WriteLine("Dias de antelacion: ");
            if(!UInt32.TryParse(ReadLine(), out uint daysForAlert))
                {
                    WriteLine("Dias invalidos\n");
                    continue;
                }
            WriteLine("Fecha Actual  (MM/dd/yyyy): ");
            if(!DateTime.TryParseExact(ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime currentDate))
                {
                    WriteLine("Fecha invalida\n");
                    continue;
                }
            await WaitForEvent(eventName, eventDate, currentDate, (int)daysForAlert);

            WriteLine("Gracias por utilizar el organizador.");
                WriteLine("Quieres programar otro evento? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            }
            while (band == true);
        }
        public static async Task WaitForEvent( string name,DateTime finalDate, DateTime inicialDate, int daysForEvent)
        {
            var totalDays = (finalDate - inicialDate).Days;
            //var alertDate = finalDate.AddDays(-5);
            if (totalDays >= 0)
            {
                await Process1(name,totalDays, inicialDate, daysForEvent, finalDate);
            }
            else
            {
                WriteLine("Fecha de inicio posterior al evento!!!!");
            }
        }
        public static async Task Process1(string name,int days, DateTime inicialDate, int alertDay, DateTime finalDay)
        {
            for (int i = 0; i < (days + 1); i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                string message;
                    message = finalDay == inicialDate ?
                        "EL EVENTO "+ name.ToUpper()+ " ES HOY!!! " 
                        :
                        (finalDay - inicialDate).Days <= alertDay ?
                        name + " Fecha actual: " + inicialDate.ToShortDateString() + " faltan : " + (finalDay - inicialDate).Days + " dias."
                        :
                        message = "Fecha actual : " + inicialDate.ToShortDateString(); 
                inicialDate = inicialDate.AddDays(1);
                WriteLine(message);
            }
        }
    }
}
