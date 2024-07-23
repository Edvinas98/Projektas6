using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektas6.Models
{
    public class AutomobiliuParkas
    {
        private Automobilis[] Automobiliai { get; set; }

        public AutomobiliuParkas()
        {
            Automobiliai = Array.Empty<Automobilis>();
        }

        public Automobilis[] GetAllCars()
        {
            return Automobiliai;
        }

        /// <summary>
        /// Prideda automobili i automobiliu masyva
        /// </summary>
        /// <param name="marke"></param>
        /// <param name="modelis"></param>
        /// <param name="pagaminimoMetai"></param>
        /// <param name="rida"></param>
        public void AddAutomobilis(string marke, string modelis, DateOnly pagaminimoMetai, int rida)
        {
            if (Automobiliai != null)
            {
                Automobilis[] temp = new Automobilis[Automobiliai.Length + 1];
                for (int i = 0; i < Automobiliai.Length; i++)
                    temp[i] = Automobiliai[i];
                Automobiliai = temp;
            }
            else
                Automobiliai = new Automobilis[1];

            Automobiliai[Automobiliai.Length - 1] = new Automobilis(marke, modelis, pagaminimoMetai, rida);
        }

        /// <summary>
        /// Istrina automobili is automobiliu masyvo pagal marke ir modeli
        /// </summary>
        /// <param name="marke"></param>
        /// <param name="modelis"></param>
        public void RemoveAutomobilis(string marke, string modelis)
        {
            while (true)
            {
                if (Automobiliai == null || Automobiliai.Length == 0)
                    break;

                int index = FindAutomobilis(marke, modelis);

                if (index == -1)
                    break;

                if (Automobiliai.Length == 1)
                {
                    Automobiliai = Array.Empty<Automobilis>();
                    break;
                }

                Automobilis[] temp = new Automobilis[Automobiliai.Length - 1];
                int idx = 0;
                for (int i = 0; i < Automobiliai.Length; i++)
                {
                    if (i == index)
                        continue;
                    temp[idx] = Automobiliai[i];
                    idx++;
                }
                Automobiliai = temp;
            }
        }

        /// <summary>
        /// Grazina indeksa autmobiliu masyve pagal nurodyta marke ir modeli
        /// </summary>
        /// <param name="marke"></param>
        /// <param name="modelis"></param>
        /// <returns></returns>
        public int FindAutomobilis(string marke, string modelis)
        {
            for (int i = 0; i < Automobiliai.Length; i++)
            {
                if (Automobiliai[i].Marke == marke && Automobiliai[i].Modelis == modelis)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Grazina bendra automobiliu rida
        /// </summary>
        /// <returns></returns>
        public int TotalRida()
        {
            int total = 0;

            if (Automobiliai != null)
            {
                for (int i = 0; i < Automobiliai.Length; i++)
                {
                    total += Automobiliai[i].Rida;
                }
            }
            return total;
        }

        /// <summary>
        /// Grazina seniausio automobilio klase
        /// </summary>
        /// <returns></returns>
        public Automobilis GetOldestCar()
        {
            if (Automobiliai != null && Automobiliai.Length > 0)
            {
                int age = 0;
                int idx = 0;
                for (int i = 0; i < Automobiliai.Length; i++)
                {
                    if (Automobiliai[i].GetAgeInYears() >= age)
                    {
                        age = Automobiliai[i].GetAgeInYears();
                        idx = i;
                    }
                }
                return Automobiliai[idx];
            }
            return null;
        }
    }
}
