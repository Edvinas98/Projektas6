using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektas6.Models
{
    public class Preke
    {
        public string Pavadinimas { get; set; }
        public double Kaina { get; set; }
        public int Kiekis { get; set; }

        public double GetTotalPrice()
        {
            return Kaina * Convert.ToDouble(Kiekis);
        }

        public Preke(string pavadinimas, double kaina, int kiekis)
        {
            Pavadinimas = pavadinimas;
            Kaina = kaina;
            Kiekis = kiekis;
        }

        public override string ToString()
        {
            return $"{Pavadinimas} {Kaina}Eur Kiekis: {Kiekis}";
        }
    }
}
