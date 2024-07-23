using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektas6.Models
{
    public class Studentas
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public int[] Pazymiai { get; set; }

        public Studentas(string vardas, string pavarde)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            Pazymiai = Array.Empty<int>();
        }

        /// <summary>
        /// Prideda pazymi i pazymiu masyva
        /// </summary>
        /// <param name="pazymys"></param>
        public void AddPazymys(int pazymys)
        {
            if (Pazymiai != null)
            {
                int[] Temp = new int[Pazymiai.Length + 1];

                for (int i = 0; i < Pazymiai.Length; i++)
                    Temp[i] = Pazymiai[i];

                Temp[Temp.Length - 1] = pazymys;
                Pazymiai = Temp;
            }
            else
            {
                Pazymiai = new int[1];
                Pazymiai[0] = pazymys;
            }
        }

        /// <summary>
        /// Grazina visu pazymiu vidurki
        /// </summary>
        /// <returns></returns>
        public double GetAverage()
        {
            if (Pazymiai.Length > 0)
                return Math.Round(Convert.ToDouble(Pazymiai.Sum()) / Convert.ToDouble(Pazymiai.Length), 1);
            else
                return 0;
        }

        /// <summary>
        /// Atspausdina varda, pavarde, pazymius ir pazymiu vidurki
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string Text;

            Text = $"{Vardas} {Pavarde}\n";

            if( Pazymiai != null )
            {
                Text += "Pazymiai:";
                for (int i = 0; i < Pazymiai.Length; i++)
                {
                    Text += $" {Pazymiai[i]}";
                }
                Text += $"\nPazymiu vidurkis: {GetAverage()}";
            }
            else
                Text += "Pazymiu nera";

            return Text + "\n";
        }
    }
}
