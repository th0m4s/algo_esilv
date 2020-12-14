using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OutilsTD
{
    public class GestionTD
    {
        Semestre semestre;
        int numeroTD;

        // not using sorted dictionary because key is a string (and 10 comes before 2...)
        Dictionary<string, KeyValuePair<string, Action>> exercices = new Dictionary<string, KeyValuePair<string, Action>>();

        public GestionTD(Semestre semestre, int numeroTD, Type classeTD)
        {
            this.semestre = semestre;
            this.numeroTD = numeroTD;

            string patternExo = @"^Exercice(?<n>\d+)(_(?<s>\d+)){0,1}$";
            foreach (MethodInfo methodInfo in classeTD.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                string keyExo = null;
                bool exerciceSource = false;
                
                Match match = Regex.Match(methodInfo.Name, patternExo);
                if (match.Success)
                {
                    keyExo = match.Groups["n"].Value;
                    string subKey = match.Groups["s"].Value;
                    if(subKey != null && subKey.Length > 0) keyExo += "-" + subKey;
                }

                string nomExercice = "";
                List<ExerciceAttribute> exerciceAttributes = new List<ExerciceAttribute>(methodInfo.GetCustomAttributes<ExerciceAttribute>());
                if (exerciceAttributes.Count > 0)
                {
                    ExerciceAttribute attr = exerciceAttributes[0];
                    exerciceSource = attr.exerciceSource;

                    nomExercice = attr.nomExercice;

                    // if numeroExercice exists, it replace the value from method name
                    if (attr.numeroExercice >= 0)
                        keyExo = attr.numeroExercice.ToString();

                    // if keyExercice exists, it replace the value from the method name or numeroExercice
                    if (attr.keyExercice != null && attr.keyExercice.Trim().Length > 0)
                        keyExo = attr.keyExercice.Trim();
                }

                if(keyExo != null && keyExo.Length > 0)
                {
                    exercices.Add(keyExo, new KeyValuePair<string, Action>(nomExercice, () =>
                    {
                        if (exerciceSource)
                        {
#if NO_SOURCE
                            // Console.WriteLine("Impossible d'afficher la source de la méthode de cet exercice.");
                            Console.WriteLine("Cette version de l'application n'a pas été compilée avec le code permettant d'afficher la source d'un exercice.");
                            Console.WriteLine("Merci d'aller sur https://github.com/th0m4s/algo_esilv et de télécharger la version complète du programme.");
#else
                            string methodSource = SourcesManager.GetMethodSource(classeTD.Name, methodInfo.Name);
                            if(methodSource == null || methodSource.Trim().Length == 0)
                            {
                                Console.WriteLine("Impossible de trouver le code source de cet exercice.");
                                Console.WriteLine("Il s'agit sûrement d'un exercice compilé sur le tas dont le fichier source n'a pas été retrouvé.");
                            } else
                            {
                                Console.WriteLine("Code source de l'exercice " + keyExo + (nomExercice.Length > 0 ? " (" + nomExercice + ")" : "") + " :\n");
                                Console.WriteLine(methodSource);
                            }
#endif
                        }
                        else
                        {
                            Console.WriteLine("\nExecution de l'exercice " + keyExo + (nomExercice.Length > 0 ? " (" + nomExercice + ")" : "") + "...");
                            methodInfo.Invoke(null, null);
                        }
                    }));
                }
            }

            // transform dictionary to list of keyvaluepairs, sort that list and transform it back to a dictionary
            List<KeyValuePair<string, KeyValuePair<string, Action>>> exercicesList = exercices.ToList();
            exercicesList.Sort((pairA, pairB) =>
            {
                // sort the keys by their parts, separated with '-'

                string keyA = pairA.Key, keyB = pairB.Key;
                string[] partsA = keyA.Split('-'), partsB = keyB.Split('-');

                int lengthA = partsA.Length, lengthB = partsB.Length;
                int maxLength = Math.Max(lengthA, lengthB);

                for (int i = 0; i < maxLength; i++)
                {
                    if (i >= lengthA) return -1;
                    if (i >= lengthB) return 1;

                    int valueA = int.Parse(partsA[i]), valueB = int.Parse(partsB[i]);
                    if (valueA != valueB) return valueA - valueB;
                }

                return 0;
            });
            
            exercices = exercicesList.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public bool MenuExercice()
        {
            if (exercices.Count == 0)
                Console.WriteLine("Aucun exercice n'a été trouvé pour ce TD.");
            else
            {
                char continuer = 'r';

                while(continuer == 'r')
                {
                    string numeroExercice = DemanderExercice();
                    if (numeroExercice != null && numeroExercice.Length > 0)
                    {
                        ExecuterExercice(numeroExercice);

                        Console.WriteLine("\nEntre 'r' pour revenir au TD, 'q' pour quitter ou n'importe quelle touche pour revenir au menu principal...");
                        continuer = Console.ReadKey(true).KeyChar;
                    }
                    else if (numeroExercice == "")
                        continuer = 'm'; // ou n'importe quoi, on veut juste revenir au menu, donc il faut quelque chose différent de r et q
                    else continuer = 'q';
                }

                return continuer != 'q';
            }

            return true;
        }

        public string DemanderExercice()
        {
            Console.WriteLine("Liste des exercices disponibles pour le TD" + numeroTD + " (" + semestre.Display() + ") :");
            foreach(KeyValuePair<string, KeyValuePair<string, Action>> exercice in exercices)
            {
                Console.WriteLine(" - Exercice " + exercice.Key + (exercice.Value.Key.Length > 0 ? " : " + exercice.Value.Key + "" : ""));
            }

            Console.WriteLine(""); // marge

            string keyChoisie = "";
            do
            {
                Console.Write("Entre un numéro d'exercice, 0 pour revenir au menu principal et 'q' pour quitter : ");
                string ligne = Console.ReadLine();
                if (ligne == "q") return null;
                if (ligne == "0") return "";

                string[] parts = ligne.Split('-', '_', '.', ',');
                if(parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out var p1) && int.TryParse(parts[1], out var p2)) keyChoisie = string.Join("-", parts);
                } else if(parts.Length == 1)
                {
                    if (int.TryParse(parts[0], out var p1)) keyChoisie = parts[0].ToString();
                }
            } while (!exercices.ContainsKey(keyChoisie));

            return keyChoisie;
        }

        public void ExecuterExercice(string numeroExercice)
        {
            if (exercices.ContainsKey(numeroExercice))
            {
                KeyValuePair<string, Action> exercice = exercices[numeroExercice];

                exercice.Value.Invoke();
            } else Console.WriteLine("Cet exercice n'existe pas.");
        }
    }
}
