using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektas6.Models
{
    public class StudentuRegistras
    {
        private Studentas[] Studentai { get; set; }

        public StudentuRegistras()
        {
            Studentai = Array.Empty<Studentas>();
        }

        public Studentas[] GetAllStudents()
        {
            return Studentai;
        }

        /// <summary>
        /// Prideda studenta i studentu masyva
        /// </summary>
        /// <param name="vardas"></param>
        /// <param name="pavarde"></param>
        /// <param name="pazymiai"></param>
        public void AddStudentas(string vardas, string pavarde, int[] pazymiai)
        {
            if (Studentai != null)
            {
                for (int i = 0; i < Studentai.Length; i++)
                {
                    if (Studentai[i].Vardas == vardas && Studentai[i].Pavarde == pavarde)
                    {
                        Console.WriteLine($"Studentas {vardas} {pavarde} jau yra sarase!");
                        Console.WriteLine();
                        return;
                    }
                }
                Studentas[] temp = new Studentas[Studentai.Length + 1];
                for (int i = 0; i < Studentai.Length; i++)
                    temp[i] = Studentai[i];
                Studentai = temp;
            }
            else
                Studentai = new Studentas[1];

            Studentai[Studentai.Length-1] = new Studentas(vardas, pavarde);
            for (int i = 0; i < pazymiai.Length; i++)
                Studentai[Studentai.Length-1].AddPazymys(pazymiai[i]);
        }

        /// <summary>
        /// Isima studenta is studentu masyvo pagal varda ir pavarde
        /// </summary>
        /// <param name="vardas"></param>
        /// <param name="pavarde"></param>
        public void RemoveStudentas(string vardas, string pavarde)
        {
            while (true)
            {
                if (Studentai == null || Studentai.Length == 0)
                    break;

                int index = FindStudentas(vardas, pavarde);

                if (index == -1)
                    break;

                if (Studentai.Length == 1)
                {
                    Studentai = Array.Empty<Studentas>();
                    break;
                }

                Studentas[] temp = new Studentas[Studentai.Length - 1];
                int idx = 0;
                for (int i = 0; i < Studentai.Length; i++)
                {
                    if (i == index)
                        continue;
                    temp[idx] = Studentai[i];
                    idx++;
                }
                Studentai = temp;
            }
        }

        /// <summary>
        /// Grazina indeksa studentu masyve pagal varda ir pavarde
        /// </summary>
        /// <param name="vardas"></param>
        /// <param name="pavarde"></param>
        /// <returns></returns>
        public int FindStudentas(string vardas, string pavarde)
        {
            for (int i = 0; i < Studentai.Length; i++)
            {
                if (Studentai[i].Vardas == vardas && Studentai[i].Pavarde == pavarde)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Grazina visu studentu pazymiu vidurki
        /// </summary>
        /// <returns></returns>
        public double GetTotalAverage()
        {
            double total = 0;
            double totalCount = 0;

            if (Studentai != null)
            {
                for (int i = 0; i < Studentai.Length; i++)
                {
                    if (Studentai[i].Pazymiai != null)
                    {
                        for (int j = 0; j < Studentai[i].Pazymiai.Length; j++)
                        {
                            total += Convert.ToDouble(Studentai[i].Pazymiai[j]);
                        }
                        totalCount += Convert.ToDouble(Studentai[i].Pazymiai.Length);
                    }
                }
            }

            if (total > 0 && totalCount > 0)
                return Math.Round(total / totalCount, 1);
            else
                return 0;
        }
    }
}
