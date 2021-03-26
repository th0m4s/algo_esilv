using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using OutilsTD;
using System.IO;
#if !NO_COMPILER
using RuntimeCompiler;
#endif
#if !NO_SOURCE
using Microsoft.CodeAnalysis.CSharp;
#endif

namespace MenuAlgo
{
    class Program
    {
        static void PrintCompileOptions()
        {
            Console.WriteLine("Options de compilation (v" + Assembly.GetExecutingAssembly().GetName().Version + ") :");

            // Affichage des sources
#if NO_SOURCE
            Console.WriteLine(" - Affichage des sources désactivé.");
#else
            Console.WriteLine(" - Affichage des sources activé.");
#endif

            // Compilation sur le tas
#if NO_COMPILER
            Console.WriteLine(" - Compilation des fichiers locaux désactivée.");
#else
            Console.WriteLine(" - Compilation des fichiers locaux activée.");
#endif

            // Marge
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ESILV - COURS D'ALGORITHMIQUE");
            Console.WriteLine("Exercices par Thomas LEDOS\n");
            // Ce programme détecte automatiquement quels semestres, TD et exercices existent et propose un menu pour les lancer

            PrintCompileOptions();

            string pattern = @"^S(?<s>\d+)_TD(?<td>\d+)$";

            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());
            assemblies.AddRange(assemblies[0].GetReferencedAssemblies().Select(x => Assembly.Load(x)));

            string appFolder = new FileInfo(Assembly.GetEntryAssembly().Location).DirectoryName;
#if !NO_SOURCE
            SourcesManager.InitSources(appFolder);
#endif
#if !NO_COMPILER
            CompilerExercices exercicesCompiler = new CompilerExercices(appFolder);
            if (exercicesCompiler.CheckFiles())
            {
                Console.WriteLine("Compilation des fichiers locaux...");
                if (exercicesCompiler.Compile())
                    Console.WriteLine("Compilation terminée avec succès.");
                else Console.WriteLine("Impossible de compiler les fichiers locaux.");
            }

            if(exercicesCompiler.HasAssemblies)
            {
                if(!exercicesCompiler.HasCompiled) Console.WriteLine("Chargement des fichiers locaux...");
                exercicesCompiler.LoadAssemblies();
                Console.WriteLine("Fichiers locaux chargés.");
            }

            assemblies.AddRange(exercicesCompiler.LoadedAssemblies);
#endif

            SortedDictionary<int, KeyValuePair<Semestre, SortedDictionary<int, Type>>> semestres = new SortedDictionary<int, KeyValuePair<Semestre, SortedDictionary<int, Type>>>();

            foreach(Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetExportedTypes())
                {
                    Match match = Regex.Match(type.Name, pattern);
                    if (match.Success)
                    {
                        int semestre = int.Parse(match.Groups["s"].Value);
                        int numeroTD = int.Parse(match.Groups["td"].Value);

                        if (!semestres.ContainsKey(semestre))
                        {
                            Semestre objectSemestre = new Semestre(semestre);
                            semestres.Add(semestre, new KeyValuePair<Semestre, SortedDictionary<int, Type>>(objectSemestre, new SortedDictionary<int, Type>()));
                        }

                        semestres[semestre].Value.Add(numeroTD, type);
                    }
                }
            }

            // semestres.OrderBy(pair => pair.Key).ToDictionary();

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("\nListe des semestres disponibles :");

                foreach (KeyValuePair<int, KeyValuePair<Semestre, SortedDictionary<int, Type>>> semestre in semestres)
                {
                    int nombreTD = semestre.Value.Value.Count;
                    Console.WriteLine(" " + semestre.Key + ". " + semestre.Value.Key.Display() + " : " + nombreTD + " séance" + (nombreTD == 1 ? "" : "s") + " de TD");
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

                string[] semestreParts = semestreString.Split('-', '_', '.', ',');

                int semestreId = 0;
                if (!int.TryParse(semestreParts[0], out semestreId))
                {
                    Console.WriteLine("Ce n'est pas un numéro de semestre...");
                    continue;
                }

                if (!semestres.ContainsKey(semestreId))
                {
                    Console.WriteLine("Ce semestre n'existe pas.\n");
                    continue;
                }

                int chosenTD = 0;
                KeyValuePair<Semestre, SortedDictionary<int, Type>> semestrePair = semestres[semestreId];

                if (semestreParts.Length != 2 || !int.TryParse(semestreParts[1], out chosenTD) || chosenTD <= 0)
                {
                    Console.WriteLine("\nListe des TD disponibles pour ce semestre (" + semestrePair.Key.Display() + ") :");

                    Console.WriteLine(string.Join(", ", semestrePair.Value.Keys.Select(x => "TD" + x)));

                    Console.Write("\nEntre un numéro de TD ou 0 pour annuler : ");
                    chosenTD = int.Parse(Console.ReadLine());
                } 

                if(chosenTD > 0)
                {
                    if(semestrePair.Value.ContainsKey(chosenTD))
                    {
                        GestionTD gestionTD = semestrePair.Key.GetGestionTD(chosenTD, semestrePair.Value[chosenTD]);
                        continuer = gestionTD.MenuExercice();
                    } else Console.WriteLine("Ce TD n'existe pas pour le semestre demandé.\n");
                }
            }

            // Console.ReadKey();
        }
    }
}
