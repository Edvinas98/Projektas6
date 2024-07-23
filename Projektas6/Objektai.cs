using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektas6.Models;

namespace Projektas6
{
    internal class Objektai
    {
        public static void Main()
        {
            PirmojiUzduotis();
        }

        /// <summary>
        /// Prekiu katalogo uzduotis
        /// </summary>
        public static void PirmojiUzduotis()
        {
            PrekiuKatalogas prekiuKatalogas = new PrekiuKatalogas();

            AddItems(ref prekiuKatalogas);
            ListItems(ref prekiuKatalogas);
            FindItem(ref prekiuKatalogas, "Sausainiai");
            RemoveItem(ref prekiuKatalogas, "Pienas", 1);
            RemoveItem(ref prekiuKatalogas, "Dribsniai", 1);
            ListItems(ref prekiuKatalogas);
        }

        /// <summary>
        /// Prideda prekes i prekiu kataloga. Nurodomas prekiu pavadinimas, kaina ir kiekis
        /// </summary>
        /// <param name="prekiuKatalogas"></param>
        public static void AddItems(ref PrekiuKatalogas prekiuKatalogas)
        {
            prekiuKatalogas.AddPreke("Pienas", 1.89, 2);
            prekiuKatalogas.AddPreke("Sausainiai", 2.39, 3);
            prekiuKatalogas.AddPreke("Dribsniai", 3.19, 1);
            prekiuKatalogas.AddPreke("Vanduo", 0.89, 2);
        }

        /// <summary>
        /// Atspausdina prekiu, kurios yra prekiu kataloge, pavadinima, kaina ir kieki. Taip pat atspausdina bendra prekiu kaina
        /// </summary>
        /// <param name="prekiuKatalogas"></param>
        public static void ListItems(ref PrekiuKatalogas prekiuKatalogas)
        {
            Console.WriteLine("Visos Prekes:");
            Preke[] visosPrekes = prekiuKatalogas.GetAllPrekes();
            foreach (Preke preke in visosPrekes)
            {
                if (preke == null)
                {
                    break;
                }
                Console.WriteLine(preke);
            }
            Console.WriteLine($"Bendra prekiu kaina: {prekiuKatalogas.PrekiuKaina()}");
            Console.WriteLine("");
        }

        /// <summary>
        /// Suranda prekiu kataloge preke pagal pavadinima ir atspausdina sios prekes pavadinima, kaina ir kieki
        /// </summary>
        /// <param name="prekiuKatalogas"></param>
        /// <param name="itemName"></param>
        public static void FindItem(ref PrekiuKatalogas prekiuKatalogas, string itemName)
        {
            Console.WriteLine($"Ieskoma preke '{itemName}'");
            Console.WriteLine(prekiuKatalogas.GetItemInfo(prekiuKatalogas.FindPreke(itemName)));
            Console.WriteLine("");
        }

        /// <summary>
        /// Istrina prekiu kataloge prekes pagal nurodyta pavadinima ir kieki
        /// </summary>
        /// <param name="prekiuKatalogas"></param>
        /// <param name="ItemName"></param>
        /// <param name="Amount"></param>
        public static void RemoveItem(ref PrekiuKatalogas prekiuKatalogas, string ItemName, int Amount)
        {
            Console.WriteLine($"Istrinama preke '{ItemName}', kiekis: {Amount}");
            Console.WriteLine("");
            prekiuKatalogas.RemovePreke(ItemName, Amount);
        }
    }
}
