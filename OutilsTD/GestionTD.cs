using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OutilsTD
{
    public class GestionTD
    {
        Semestre semestre;
        int numeroTD;
        Dictionary<int, KeyValuePair<string, Action>> exercices = new Dictionary<int, KeyValuePair<string, Action>>();

        public GestionTD(Semestre semestre, int numeroTD, Type classeTD)
        {
            this.semestre = semestre;
            this.numeroTD = numeroTD;

            string patternExo = @"^Exercice(?<n>\d+)$";
            foreach (MethodInfo methodInfo in classeTD.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Match match = Regex.Match(methodInfo.Name, patternExo);
                if (match.Success)
                {
                    int numExo = int.Parse(match.Groups["n"].Value);

                    string nomExercice = "";
                    List<ExerciceAttribute> exerciceAttributes = new List<ExerciceAttribute>(methodInfo.GetCustomAttributes<ExerciceAttribute>());
                    if (exerciceAttributes.Count > 0)
                        nomExercice = exerciceAttributes[0].nomExercice;

                    exercices.Add(numExo, new KeyValuePair<string, Action>(nomExercice, () =>
                    {
                        methodInfo.Invoke(null, null);
                    }));
                }
            }     
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
                    int numeroExercice = DemanderExercice();
                    if (numeroExercice > 0)
                    {
                        ExecuterExercice(numeroExercice);

                        Console.WriteLine("\nEntre 'r' pour revenir au TD, 'q' pour quitter ou n'importe quelle touche pour revenir au menu principal...");
                        continuer = Console.ReadKey(true).KeyChar;
                    }
                    else if (numeroExercice == 0)
                        continuer = 'm'; // ou n'importe quoi, on veut juste revenir au menu, donc il faut quelque chose différent de r et q
                    else continuer = 'q';
                }

                return continuer != 'q';
            }

            return true;
        }

        public int DemanderExercice()
        {
            Console.WriteLine("Liste des exercices disponibles pour le TD" + numeroTD + " (" + semestre.Display() + ") :");
            foreach(KeyValuePair<int, KeyValuePair<string, Action>> exercice in exercices)
            {
                Console.WriteLine(" - Exercice " + exercice.Key + (exercice.Value.Key.Length > 0 ? " : " + exercice.Value.Key + "" : ""));
            }

            Console.WriteLine(""); // marge

            int numeroChoisi, max = exercices.Count;
            do
            {
                Console.Write("Entre un numéro d'exercice, 0 pour revenir au menu principal et 'q' pour quitter : ");
                string ligne = Console.ReadLine();
                if (ligne == "q") return -1;
                numeroChoisi = int.Parse(ligne);
            } while (numeroChoisi <= 0 || numeroChoisi > max);

            return numeroChoisi;
        }

        public void ExecuterExercice(int numeroExercice)
        {
            if (exercices.ContainsKey(numeroExercice))
            {
                KeyValuePair<string, Action> exercice = exercices[numeroExercice];

                Console.WriteLine("\nExecution de l'exercice " + numeroExercice + (exercice.Key.Length > 0 ? " (" + exercice.Key + ")" : "") + "...");
                exercice.Value.Invoke();
            } else Console.WriteLine("Cet exercice n'existe pas.");
        }
    }
}
