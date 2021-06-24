using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemDeCinzas.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Nuvem nuvem = new Nuvem();

            Console.WriteLine(nuvem.RetornarDias()); 

            Console.Read();
        }

    }
}
