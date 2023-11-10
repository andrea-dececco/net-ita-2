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
        public string Um { get; }
        public int Speed { get; private set; }

        public Veicolo(string um)
        {
            Um = um;
            
        }

        public void Accellerate() 
        {
            Speed++;
        }

        public override string? ToString()
        {
            return $"La velocità attuale: {Speed} {Um}";
        }

    }
}
