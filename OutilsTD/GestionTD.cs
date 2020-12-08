using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OutilsTD
{
    public class GestionTD
    {
        Semestre semestre;
        int numeroTD;
        Dictionary<string, KeyValuePair<string, Action>> exercices = new Dictionary<string, KeyValuePair<string, Action>>();

        public GestionTD(Semestre semestre, int numeroTD, Type classeTD)
        {
            this.semestre = semestre;
            this.numeroTD = numeroTD;

            string patternExo = @"^Exercice(?<n>\d+)(_(?<s>\d+)){0,1}$";
            foreach (MethodInfo methodInfo in classeTD.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Match match = Regex.Match(methodInfo.Name, patternExo);
                if (match.Success)
                {
                    string keyExo = match.Groups["n"].Value;
                    string subKey = match.Groups["s"].Value;
                    if(subKey != null && subKey.Length > 0) keyExo += "-" + subKey;

                    string nomExercice = "";
                    List<ExerciceAttribute> exerciceAttributes = new List<ExerciceAttribute>(methodInfo.GetCustomAttributes<ExerciceAttribute>());
                    if (exerciceAttributes.Count > 0)
                        nomExercice = exerciceAttributes[0].nomExercice;

                    exercices.Add(keyExo, new KeyValuePair<string, Action>(nomExercice, () =>
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

                Console.WriteLine("\nExecution de l'exercice " + numeroExercice + (exercice.Key.Length > 0 ? " (" + exercice.Key + ")" : "") + "...");
                exercice.Value.Invoke();
            } else Console.WriteLine("Cet exercice n'existe pas.");
        }
    }
}
