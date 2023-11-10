using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCoding2
{
    public class Automobile : Veicolo
    {

        public string Model{get;}

        public Automobile(string model):base("Km/h")
        {
            Model = model;
            
        }

        public override string? ToString()
        {
            return $"Modello : {Model} \n{base.ToString()}";
        }

    }
}
