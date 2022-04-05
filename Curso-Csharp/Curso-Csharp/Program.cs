using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoIntegon
{
    class Program
    {
        static void Main(string[] args)
        {
            //    List<obj> lista = new List<obj>() {
            //         new obj {Id =1,nombre = "obj1"},
            //         new obj {Id =2,nombre = "obj2"},
            //         new obj {Id =3,nombre = "obj3"},
            //         new obj {Id =4,nombre = "obj4"},
            //         new obj {Id =5,nombre = "obj5"},
            //         new obj {Id =6,nombre = "obj6"},
            //         new obj {Id =7,nombre = "obj7"},
            //         new obj {Id =8,nombre = "obj8"},
            //         new obj {Id =9,nombre = "obj9"},
            //         new obj {Id =10,nombre = "obj10"}

            //};

            //    Console.WriteLine("Id: " +GetByName(lista, "obj5").Id);
            //    Console.WriteLine("Nombre: " + GetByIndex(lista, 6).nombre);
            //    DeleteByIndex(lista, 10);
            //    foreach (var item in lista)
            //    {
            //        Console.WriteLine("Nobmre: " + item.nombre + " Id : " + item.Id);
            //    }
            //    lista = InsertByIndex(lista, 6, new obj { Id = 55, nombre = "zzz" });
            //    foreach (var item in lista)
            //    {
            //        Console.WriteLine("Nobmre: " + item.nombre + " Id : " + item.Id);
            //    }

            //int[] a = { 1,2,3,4,5};
            //int d = 4;

            //for (int j = 0; j<d; j++)
            //{
            //for (int i = 1; i < a.Length; i++)
            //{
            //    var temp = a[i-1];
            //    var lastPosition = a.Length - 1;

            //        //if (i != lastPosition)
            //        //{
            //            a[i-1] = a[i];
            //        //}
            //        //else {
            //            a[i] = temp;
            //        //}     
            //}
            //}

            //foreach (var item in a)
            //{
            //    Console.WriteLine(item);
            //}

            //string[] exem = { "U", "D", "D", "U", "U", "D", "U", "U" };
            //string eje = "UDUDUDUD";
            //var array = eje.ToCharArray();
            //int valles = 0;
            //int nivel = 0;

            //for(int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] == 'u')
            //    {
            //        if (nivel == -1)
            //        {
            //            valles++;
            //        }

            //        nivel++;
            //    }
            //    if (array[i] == 'D')
            //    {
            //        nivel--;
            //    }
            //}

            //Console.WriteLine("Valles caminados : " + valles);


            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] aDesor = { 1, 3, 2, 4, 5, 8, 6, 7 };
            int movimientos = 0;
            var band = false;

            for (int i = 0; i < aDesor.Length; i++)
            {
                var posFin = i;
                var posIni = Array.IndexOf(a, aDesor[i]);
                var movTemp = posIni - posFin;


                if (movTemp > 2)
                {
                    band = true;
                    Console.WriteLine("Too Cahotic");
                    break;
                }
                else if (movTemp > 0)
                {
                    movimientos += movTemp;
                }
            }

            if (!band)
            {
                if (movimientos > 0) Console.WriteLine("Movimientos: " + movimientos);
                else Console.WriteLine("La fila sigue igual");
            }
        }



        public class obj
        {
            public int Id { get; set; }
            public string nombre { get; set; }


        }

        public static obj GetByName(List<obj> lista, string name)
        {
            return lista.Where(x => x.nombre == name).FirstOrDefault();
        }
        public static obj GetByIndex(List<obj> lista, int index)
        {
            return lista.Where(x => x.Id == index).FirstOrDefault();
        }
        public static string DeleteByIndex(List<obj> lista, int index)
        {
            lista.RemoveAt(index - 1);
            return "Objeto en posicion " + index + " borrado";
        }
        public static List<obj> InsertByIndex(List<obj> lista, int index, obj objeto)
        {
            lista.Insert(index - 1, objeto);
            var newList = lista;
            return newList;
        }
    }
}