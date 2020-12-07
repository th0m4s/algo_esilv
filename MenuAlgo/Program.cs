using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using OutilsTD;

namespace MenuAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ESILV - COURS D'ALGORITHMIQUE");
            Console.WriteLine("Exercices par Thomas LEDOS\n");
            // Ce programme détecte automatiquement quels semestres, TD et exercices existent et propose un menu pour les lancer

            Dictionary<int, Dictionary<int, Type>> semestres = new Dictionary<int, Dictionary<int, Type>>();
            Dictionary<int, Semestre> objectsSemestres = new Dictionary<int, Semestre>();

            string pattern = @"^S(?<s>\d+)_TD(?<td>\d+)$";

            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach(Type type in assembly.GetExportedTypes())
            {
                Match match = Regex.Match(type.Name, pattern);
                if(match.Success)
                {
                    int semestre = int.Parse(match.Groups["s"].Value);
                    int numeroTD = int.Parse(match.Groups["td"].Value);

                    if (!semestres.ContainsKey(semestre))
                        semestres.Add(semestre, new Dictionary<int, Type>());

                    semestres[semestre].Add(numeroTD, type);

                    Semestre objectSemestre = new Semestre(semestre);
                    objectsSemestres.Add(semestre, objectSemestre);
                }
            }

            bool continuer = true;
            while(continuer)
            {
                Console.WriteLine("\nListe des semestres disponibles");

                foreach (KeyValuePair<int, Dictionary<int, Type>> semestre in semestres)
                {
                    int nombreTD = semestre.Value.Count;
                    Console.WriteLine(" - " + objectsSemestres[semestre.Key].Display() + " : " + nombreTD + " séance" + (nombreTD == 1 ? "" : "s") + " de TD");
                }

                Console.Write("\nEntre un numéro de semestre, 'c' pour voir le code source ou 'q' pour quitter : ");
                string semestreString = Console.ReadLine().ToLower();
                if (semestreString == "q") break;
                if (semestreString == "c")
                {
                    Console.WriteLine("Ouverture du code source...");
                    Process.Start("https://github.com/th0m4s/algo_esilv");
                    continue;
                }

                int semestreId = 0;
                if(!int.TryParse(semestreString, out semestreId))
                {
                    Console.WriteLine("Ce n'est pas un numéro de semestre...");
                    continue;
                }

                if (!semestres.ContainsKey(semestreId))
                {
                    Console.WriteLine("Ce semestre n'existe pas.\n");
                    continue;
                }

                Semestre semestreObject = objectsSemestres[semestreId];
                Console.WriteLine("\nListe des TD disponibles pour ce semestre (" + semestreObject.Display() + ") :");

                Dictionary<int, Type> semestreTypes = semestres[semestreId];
                Console.WriteLine(string.Join(", ", semestreTypes.Keys.Select(x => "TD" + x)));

                Console.Write("\nEntre un numéro de TD ou 0 pour annuler : ");
                int chosenTD = int.Parse(Console.ReadLine());

                if(chosenTD > 0)
                {
                    if(semestreTypes.ContainsKey(chosenTD))
                    {
                        GestionTD gestionTD = new GestionTD(semestreObject, chosenTD, semestreTypes[chosenTD]);
                        continuer = gestionTD.MenuExercice();
                    } else Console.WriteLine("Ce TD n'existe pas pour le semestre demandé.\n");
                }
            }

            // Console.ReadKey();
        }
    }
}
