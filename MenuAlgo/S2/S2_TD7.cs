using MenuAlgo;
using OutilsTD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAlgo
{
    public class S2_TD7
    {
        [Exercice("1", "Méthode 'bool Permuter(int[] tableau, int index1, int index2)'", exerciceSource = true)]
        static bool Permuter(int[] tableau, int index1, int index2, bool force = false)
        {
            bool res = false;

            if(tableau != null)
            {
                int length = tableau.Length;

                if (force || (index1 >= 0 && index2 >= 0 &&
                    index1 < length && index2 < length && 
                    index1 != index2))
                {
                    res = true;

                    int t = tableau[index2];
                    tableau[index2] = tableau[index1];
                    tableau[index1] = t;
                }
            }

            return res;
        }

        [Exercice("2-0", "Méthode 'void TriABulles(int[] tableau)'", exerciceSource = true)]
        static void TriABulles(int[] tableau)
        {
            if(tableau != null && tableau.Length > 1)
            {
                bool continuer = true;
                for (int i = 0; i < tableau.Length && continuer; i++)
                {
                    continuer = false;
                    for(int j = 0; j < tableau.Length - i - 1; j++)
                    {
                        if(tableau[j] > tableau[j+1])
                        {
                            Permuter(tableau, j, j + 1, true);
                            continuer = true;
                        }
                    }
                }
            }
        }

        [Exercice("Test du tri à bulles")]
        static void Exercice2_1()
        {
            Console.Write("Entrez une taille de tableau : ");
            int taille = int.Parse(Console.ReadLine());

            int min = 0;
            int max = 0;

            if(taille > 0)
            {
                Console.Write("Entrez une valeur min : ");
                min = int.Parse(Console.ReadLine());

                Console.Write("Entrez une valeur max : ");
                max = int.Parse(Console.ReadLine());
            }

            int[] tableau = S2_TD3.GenererTableauAleatoire(taille, min, max);

            Console.WriteLine("Tableau avant tri :");
            S2_TD2.AfficherTableau(tableau);

            TriABulles(tableau);

            Console.WriteLine("\nTableau après tri :");
            S2_TD2.AfficherTableau(tableau);
        }

        [Exercice("3-0", "Méthode 'void TriCocktail(int[] tableau)'", exerciceSource = true)]
        static void TriCocktail(int[] tableau)
        {
            if (tableau != null && tableau.Length > 1)
            {
                bool continuer = true;
                for (int i = 0; i < tableau.Length && continuer; i++)
                {
                    continuer = false;

                    for (int j = i; j < tableau.Length - i - 1; j++)
                    {
                        if (tableau[j] > tableau[j + 1])
                        {
                            Permuter(tableau, j, j + 1, true);
                            continuer = true;
                        }
                    }

                    for (int j = tableau.Length - i - 1; j > i; j--)
                    {
                        if (tableau[j] < tableau[j - 1])
                        {
                            Permuter(tableau, j, j - 1, true);
                            continuer = true;
                        }
                    }
                }
            }
        }

        [Exercice("Test du tri cocktail")]
        static void Exercice3_1()
        {
            Console.Write("Entrez une taille de tableau : ");
            int taille = int.Parse(Console.ReadLine());

            int min = 0;
            int max = 0;

            if (taille > 0)
            {
                Console.Write("Entrez une valeur min : ");
                min = int.Parse(Console.ReadLine());

                Console.Write("Entrez une valeur max : ");
                max = int.Parse(Console.ReadLine());
            }

            int[] tableau = S2_TD3.GenererTableauAleatoire(taille, min, max);

            Console.WriteLine("Tableau avant tri :");
            S2_TD2.AfficherTableau(tableau);

            TriCocktail(tableau);

            Console.WriteLine("\nTableau après tri :");
            S2_TD2.AfficherTableau(tableau);
        }


        [Exercice("Comparaison des 2 algorithmes")]
        static void Exercice4()
        {
            int count = 16000;
            int size = 1024;
            int[][] tableauxBulles = new int[count][];
            int[][] tableauxCocktail = new int[count][];

            Console.WriteLine("Génération des tableaux...");

            for(int i = 0; i < count; i++)
            {
                int[] tab = S2_TD3.GenererTableauAleatoire(size, 0, 10000);
                tableauxBulles[i] = tab;
                tableauxCocktail[i] = new int[size];
                Array.Copy(tab, tableauxCocktail[i], size);
            }

            Console.WriteLine("Début des tests...\n");

            Stopwatch bullesStopwatch = new Stopwatch();
            bullesStopwatch.Start();
            for(int i = 0; i < count; i++)
            {
                TriABulles(tableauxBulles[i]);
            }
            bullesStopwatch.Stop();
            TimeSpan tsBulles = bullesStopwatch.Elapsed;
            Console.WriteLine("Tri à bulles : " + string.Format("{0:00}.{1:00}s", tsBulles.Seconds, tsBulles.Milliseconds / 10));

            Stopwatch cocktailStopwatch = new Stopwatch();
            cocktailStopwatch.Start();
            for (int i = 0; i < count; i++)
            {
                TriCocktail(tableauxCocktail[i]);
            }
            cocktailStopwatch.Stop();
            TimeSpan tsCocktail = cocktailStopwatch.Elapsed;
            Console.WriteLine("Tri cocktail : " + string.Format("{0:00}.{1:00}s", tsCocktail.Seconds, tsCocktail.Milliseconds / 10));

            // ça prend beaucoup de mémoire donc on le libère le plus tôt possible
            tableauxBulles = null;
            tableauxCocktail = null;
            GC.Collect();
        }
    }
}
