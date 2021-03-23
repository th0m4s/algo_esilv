using MenuAlgo;
using OutilsTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAlgo
{
    public class S2_TD7
    {
        [Exercice("1", "Méthode 'bool Permuter(int[] tableau, int index1, int index2)'", exerciceSource = true)]
        static bool Permuter(int[] tableau, int index1, int index2)
        {
            bool res = false;

            if(tableau != null)
            {
                int length = tableau.Length;

                if (index1 >= 0 && index2 >= 0 &&
                    index1 < length && index2 < length && 
                    index1 != index2)
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
                            Permuter(tableau, j, j + 1);
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
    }
}
