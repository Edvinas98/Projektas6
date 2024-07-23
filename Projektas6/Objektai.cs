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
            //PirmojiUzduotis();

            //AntrojiUzduotis();

            //TreciojiUzduotis();
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
            Console.WriteLine();
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
            Console.WriteLine();
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
            Console.WriteLine();
            prekiuKatalogas.RemovePreke(ItemName, Amount);
        }

        /// <summary>
        /// Studentu registro uzduotis
        /// </summary>
        public static void AntrojiUzduotis()
        {
            StudentuRegistras studentuRegistras = new StudentuRegistras();

            AddStudents(ref studentuRegistras);
            ListStudents(ref studentuRegistras);
            RemoveStudent(ref studentuRegistras, "Vardenis", "Pavardenis");
            RemoveStudent(ref studentuRegistras, "Linas", "Linaitis");
            ListStudents(ref studentuRegistras);
        }

        /// <summary>
        /// Prideti studentus i registra
        /// </summary>
        /// <param name="studentuRegistras"></param>
        public static void AddStudents(ref StudentuRegistras studentuRegistras)
        {
            studentuRegistras.AddStudentas("Vardenis", "Pavardenis", new int[] { 8, 9, 5, 7, 10, 8 });
            studentuRegistras.AddStudentas("Jonas", "Jonaitis", new int[] { 9, 6, 7 });
            studentuRegistras.AddStudentas("Petras", "Petraitis", new int[] { 10, 9, 8, 9, 8 });
            studentuRegistras.AddStudentas("Linas", "Linaitis", new int[] { 4, 6, 5, 7 });
        }

        /// <summary>
        /// Atspausdinti visu studentu sarasa su ju pazymiais ir pazymiu vidurkiais. Taip pat atspausdina bendra visu studentu pazymiu vidurki
        /// </summary>
        /// <param name="studentuRegistras"></param>
        public static void ListStudents(ref StudentuRegistras studentuRegistras)
        {
            Studentas[] visiStudentai = studentuRegistras.GetAllStudents();
            if (visiStudentai != null && visiStudentai.Length > 0)
            {
                Console.WriteLine("Visi Studentai:");
                Console.WriteLine();
                foreach (Studentas studentas in visiStudentai)
                {
                    Console.WriteLine(studentas);
                }
                double average = studentuRegistras.GetTotalAverage();
                Console.WriteLine($"Bendras visu studentu pazymiu vidurkis: {average}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Pasalina studenta is studentu registro pagal varda ir pavarde
        /// </summary>
        /// <param name="studentuRegistras"></param>
        /// <param name="vardas"></param>
        /// <param name="pavarde"></param>
        public static void RemoveStudent(ref StudentuRegistras studentuRegistras, string vardas, string pavarde)
        {
            Console.WriteLine($"Ismestas studentas: {vardas} {pavarde}");
            Console.WriteLine();
            studentuRegistras.RemoveStudentas(vardas, pavarde);
        }

        public static void TreciojiUzduotis()
        {
            AutomobiliuParkas automobiliuparkas = new AutomobiliuParkas();

            AddCars(ref automobiliuparkas);
            ListCars(ref automobiliuparkas);
            FindOldestCar(ref automobiliuparkas);
            RemoveCar(ref automobiliuparkas, "Audi", "A6");
            RemoveCar(ref automobiliuparkas, "Toyota", "Yaris");
            ListCars(ref automobiliuparkas);
            FindOldestCar(ref automobiliuparkas);
        }

        public static void AddCars(ref AutomobiliuParkas automobiliuparkas)
        {
            automobiliuparkas.AddAutomobilis("Honda", "Civic", DateOnly.Parse("2015-08-15"), 188520);
            automobiliuparkas.AddAutomobilis("Audi", "A6", DateOnly.Parse("2017-09-08"), 134870);
            automobiliuparkas.AddAutomobilis("Toyota", "Yaris", DateOnly.Parse("2016-07-23"), 167950);
            automobiliuparkas.AddAutomobilis("Audi", "A4", DateOnly.Parse("2012-01-14"), 244520);
            automobiliuparkas.AddAutomobilis("Audi", "A6", DateOnly.Parse("2011-05-06"), 223000);
        }

        public static void ListCars(ref AutomobiliuParkas automobiliuparkas)
        {
            Automobilis[] visiAutomobiliai = automobiliuparkas.GetAllCars();
            if (visiAutomobiliai != null && visiAutomobiliai.Length > 0)
            {
                Console.WriteLine("Visi automobiliai:");
                Console.WriteLine();
                foreach (Automobilis auto in visiAutomobiliai)
                {
                    Console.WriteLine(auto);
                }
                Console.WriteLine();
                Console.WriteLine($"Bendra automobiliu rida: {automobiliuparkas.TotalRida()}");
                Console.WriteLine();
            }
        }

        public static void RemoveCar(ref AutomobiliuParkas automobiliuparkas, string marke, string modelis)
        {
            Console.WriteLine($"Pasalintas automobilis: {marke} {modelis}");
            Console.WriteLine();
            automobiliuparkas.RemoveAutomobilis(marke, modelis);
        }

        public static void FindOldestCar(ref AutomobiliuParkas automobiliuparkas)
        {
            Automobilis auto = automobiliuparkas.GetOldestCar();
            if (auto != null)
            {
                Console.WriteLine($"Seniausias automobilis: {auto}");
                Console.WriteLine();
            }
        }
    }
}
