using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektas6.Models
{
    public class Automobilis
    {
        public string Marke { get; set; }
        public string Modelis { get; set; }
        public DateOnly PagaminimoMetai { get; set; }
        public int Rida { get; set; }

        public Automobilis(string marke, string modelis, DateOnly pagaminimoMetai, int rida)
        {
            Marke = marke;
            Modelis = modelis;
            PagaminimoMetai = pagaminimoMetai;
            Rida = rida;
        }

        /// <summary>
        /// Grazina automobilio amziu metais
        /// </summary>
        /// <returns></returns>
        public int GetAgeInYears()
        {
            int age = DateTime.Now.Year - PagaminimoMetai.Year;
            return age;
        }

        /// <summary>
        /// Atspausdina automobilio marke, modeli, pagaminimo metus ir rida
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Marke} {Modelis} Pagaminimo metai: {PagaminimoMetai} Rida: {Rida} km";
        }
    }
}
