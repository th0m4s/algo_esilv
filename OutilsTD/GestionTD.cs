using System;
using System.Diagnostics;

namespace OutilsTD
{
    public class GestionTD
    {
        Semestre semestre;
        int numeroTD;
        Action[] exercices;

        public GestionTD(Semestre semestre, int numeroTD, params Action[] exercices)
        {
            this.semestre = semestre;
            this.numeroTD = numeroTD;
            this.exercices = exercices;
        }

        public void MenuExercice()
        {
            Console.WriteLine("ESILV " + semestre.Display() + " - COURS D'ALGORITHMIQUE");
            Console.WriteLine("Exercices du TD" + numeroTD + " par Thomas LEDOS\n");

            if (exercices.Length == 0)
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

                        Console.WriteLine("\nAppuie sur 'r' pour recommencer ou sur n'importe quelle autre touche pour quitter...");
                        continuer = Console.ReadKey(true).KeyChar;
                    }
                    else continuer = 'q';
                }
            }
        }

        public int DemanderExercice()
        {
            int numeroChoisi = 0, max = exercices.Length;
            do
            {
                Console.Write("Entrez un numéro d'exercice (entre 1 et " + max + ", tape 'q' pour quitter) : ");
                string ligne = Console.ReadLine();
                if (ligne == "q") return -1;
                numeroChoisi = int.Parse(ligne);
            } while (numeroChoisi <= 0 && numeroChoisi > max);

            return numeroChoisi;
        }

        public void ExecuterExercice(int numeroExercice)
        {
            if (numeroExercice > 0 && numeroExercice <= exercices.Length && exercices[numeroExercice - 1] != null)
            {
                Console.WriteLine("\nExecution de l'exercice " + numeroExercice + "...");
                exercices[numeroExercice - 1].Invoke();
            }
            else Console.WriteLine("Cet exercice n'existe pas.");
        }
    }
}
