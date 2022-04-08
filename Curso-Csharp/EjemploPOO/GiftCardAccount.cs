using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace EjemploPOO
{
    public class GiftCardAccount : Account
    {
        //base hace referencia a un cosntructor alojado en el padre
        // si queremos un constructuor nuevo, el padre debe tener un cosntructor vacio
        public GiftCardAccount(string name, decimal initialBalance, int minimumBalance) : base(name, initialBalance, minimumBalance)
        {

        }
    }
}
