using MenuAlgo;
using OutilsTD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MenuAlgo
{
    public class S2_TD8
    {
        [Exercice("1-0", "Méthode 'void TriInsertionPermut(int[] tab)'", exerciceSource = true)]
        static void TriInsertionPermut(int[] tab)
        {
            if(tab != null)
            {
                for(int i = 1; i < tab.Length; i++)
                {
                    for(int j = i; j > 0; j--)
                    {
                        if(tab[j] < tab[j-1])
                        {
                            S2_TD7.Permuter(tab, j, j - 1);
                        }
                    }
                }
            }
        }

        [Exercice("Tri par insertion (et permutations)")]
        static void Exercice1_1()
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

            TriInsertionPermut(tableau);

            Console.WriteLine("\nTableau après tri :");
            S2_TD2.AfficherTableau(tableau);
        }

        [Exercice("1-2", "Méthode 'void TriInsertionTemp(int[] tab)'", exerciceSource = true)]
        static void TriInsertionTemp(int[] tab)
        {
            if (tab != null)
            {
                for (int i = 1; i < tab.Length; i++)
                {
                    int temp = tab[i];
                    int j = i;
                    for(; j > 0 && tab[j-1] > temp; j--)
                    {
                        tab[j] = tab[j-1];
                    }
                    tab[j] = temp;
                }
            }
        }

        [Exercice("Tri par insertion (et variable temporaire)")]
        static void Exercice1_3()
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

            TriInsertionTemp(tableau);

            Console.WriteLine("\nTableau après tri :");
            S2_TD2.AfficherTableau(tableau);
        }

        [Exercice("2-0", "Méthode 'void ShuffleLinq(int[] tab)'", exerciceSource = true)]
        static void ShuffleLinq(int[] tab)
        {
            // pas vu dans le cours mais très très pratique, comme toujours avec LINQ
            Random random = new Random();
            Array.Copy(tab.OrderBy(x => random.Next()).ToArray(), tab, tab.Length);
        }

        [Exercice("Mélange d'un tableau (avec LINQ)")]
        static void Exercice2_1()
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

            Console.WriteLine("Tableau avant mélange :");
            S2_TD2.AfficherTableau(tableau);

            ShuffleLinq(tableau);

            Console.WriteLine("\nTableau après tmélangeri :");
            S2_TD2.AfficherTableau(tableau);
        }

        [Exercice("2-2", "Méthode 'void Shuffle(int[] tab)'", exerciceSource = true)]
        static void Shuffle(int[] tab)
        {
            if(tab != null)
            {
                Random random = new Random();
                int l = tab.Length;
                for (int i = 0; i < l; i++)
                {
                    S2_TD7.Permuter(tab, i, random.Next(l));
                }
            }
        }

        [Exercice("Mélange d'un tableau (classique)")]
        static void Exercice2_3()
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

            Console.WriteLine("Tableau avant mélange :");
            S2_TD2.AfficherTableau(tableau);

            Shuffle(tableau);

            Console.WriteLine("\nTableau après tmélangeri :");
            S2_TD2.AfficherTableau(tableau);
        }

        [Exercice("3-0", "Méthode 'void TriSelection(int[] tab)'", exerciceSource = true)]
        static void TriSelection(int[] tab)
        {
            if(tab != null)
            {
                for(int i = 0; i < tab.Length; i++)
                {
                    int min = int.MaxValue;
                    int pos = -1;

                    for(int j = i; j < tab.Length; j++)
                    {
                        if(tab[j] < min)
                        {
                            min = tab[j];
                            pos = j;
                        }
                    }

                    S2_TD7.Permuter(tab, i, pos);
                }
            }
        }

        [Exercice("Tri par sélection")]
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

            TriSelection(tableau);

            Console.WriteLine("\nTableau après tri :");
            S2_TD2.AfficherTableau(tableau);
        }
    }
}
