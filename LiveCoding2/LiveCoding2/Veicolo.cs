using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding2
{
    public class Veicolo
    {

        //modificatore accesso' 'tipo' 'nome' { get; set; }

        public int Speed { get; set; }


        public void PrintSpeed()
        {
            Console.WriteLine(Speed);

        }
    }
}
