using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektas6.Models
{
    public class PrekiuKatalogas
    {
        private Preke[] Prekes { get; set; }
        private int paskutinisPridetas = 0;

        public PrekiuKatalogas()
        {
            Prekes = new Preke[1000];
        }

        public Preke[] GetAllPrekes()
        {
            return Prekes;
        }

        public void AddPreke(string pavadinimas, double kaina, int kiekis)
        {
            for (int i = 0; i < paskutinisPridetas; i++)
            {
                if (Prekes[i].Pavadinimas == pavadinimas)
                {
                    if (Prekes[i].Kaina == kaina)
                    {
                        Prekes[i].Kiekis += kiekis;
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Preke '{pavadinimas}' (kaina {kaina}Eur) nebuvo prideta, nes preke su tokiu pavadinimu jau yra, taciau kaina skiriasi.");
                        return;
                    }
                }
            }
            Prekes[paskutinisPridetas] = new Preke(pavadinimas, kaina, kiekis);
            paskutinisPridetas++;
        }

        /// <summary>
        /// Istrina preke pagal pavadinima ir kieki
        /// </summary>
        /// <param name="pavadinimas"></param>
        /// <param name="kiekis"></param>
        public void RemovePreke(string pavadinimas, int kiekis)
        {
            bool bDeleted = false;
            bool bFound = false;

            for(int i = 0; i < paskutinisPridetas; i++)
            {
                if (!bDeleted)
                {
                    if (!bFound && Prekes[i].Pavadinimas == pavadinimas)
                    {
                        bFound = true;
                        if (kiekis >= Prekes[i].Kiekis)
                        {
                            if(i < paskutinisPridetas - 1)
                                Prekes[i] = Prekes[i+1];
                            paskutinisPridetas--;
                            bDeleted = true;
                        }
                        else
                            Prekes[i].Kiekis -= kiekis;
                    }
                }
                else
                    Prekes[i] = Prekes[i + 1];
            }
            if (bDeleted)
            {
                Prekes[paskutinisPridetas] = null;
            }
        }

        /// <summary>
        /// Grazina bendra prekiu kaina
        /// </summary>
        /// <returns></returns>
        public double PrekiuKaina()
        {
            double bendraKaina = 0.00;

            for (int i = 0; i < paskutinisPridetas; i++)
            {
                bendraKaina += Prekes[i].GetTotalPrice();
            }
            return Math.Round(bendraKaina, 2);
        }

        /// <summary>
        /// Grazina indeksa prekiu kataloge pagal nurodyta prekes pavadinima
        /// </summary>
        /// <param name="pavadinimas"></param>
        /// <returns></returns>
        public int FindPreke(string pavadinimas)
        {
            for (int i = 0; i < paskutinisPridetas; i++)
            {
                if (Prekes[i].Pavadinimas == pavadinimas)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Grazina prekes pavadinima, kaina ir kieki pagal nurodyta indeksa prekiu kataloge
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public string GetItemInfo(int Index)
        {
            if (Index >= 0 && Index < paskutinisPridetas)
            {
                return Prekes[Index].ToString();
            }
            else return "Preke nerasta";
        }
    }
}
