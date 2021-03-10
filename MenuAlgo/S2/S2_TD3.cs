using MenuAlgo;
using OutilsTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAlgo
{
    public class S2_TD3
    {
        [Exercice("1-0", "Méthode 'int[] GenererTableauAleatoire(int taille, int valeurMin, int valeurMax)'", exerciceSource = true)]
        static int[] GenererTableauAleatoire(int taille, int valeurMin, int valeurMax)
        {
            int[] tab = null;

            if(taille >= 0)
            {
                tab = new int[taille];
                Random rdn = new Random();
                for (int i = 0; i < taille; i++)
                {
                    tab[i] = rdn.Next(valeurMin, valeurMax + 1); // because max is exclusive
                }
            }

            return tab;
        }

        [Exercice("Tableau aléatoire")]
        static void Exercice1_1()
        {
            Console.Write("Entrez une taille de tableau : ");
            int taille = int.Parse(Console.ReadLine());

            Console.Write("Entrez une valeur max : ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Entrez une valeur min : ");
            int max = int.Parse(Console.ReadLine());

            Console.WriteLine("Tableau généré :");
            S2_TD2.AfficherTableau(GenererTableauAleatoire(taille, min, max));
        }

        [Exercice("2-0", "Méthode 'int Rechercher(int[] tableau, int valeur)'", exerciceSource = true)]
        static int Rechercher(int[] tableau, int valeur)
        {
            int res = -1;

            if(tableau != null)
            {
                for (int i = 0; i < tableau.Length && res < 0; i++)
                {
                    if (tableau[i] == valeur)
                    {
                        res = i;
                    }
                }
            }

            return res;
        }

        [Exercice("Recherche d'une valeur")]
        static void Exercice2_1()
        {
            int[] tab = S2_TD2.RemplirTableau();

            Console.Write("Entrez une valeur à rechercher : ");
            int val = int.Parse(Console.ReadLine());

            int pos = Rechercher(tab, val);
            if(pos == -1)
            {
                Console.WriteLine("Valeur introuvable (ou le tableau est null).");
            } else
            {
                Console.WriteLine("La valeur " + val + " est à la position " + pos + ".");
            }
        }

        [Exercice("3-0", "Méthode 'int PositionMaximum(int[] tableau)'", exerciceSource = true)]
        static int PositionMaximum(int[] tableau)
        {
            int pos = -1;
            int max = int.MinValue;

            if(tableau != null)
            {
                for(int i = 0; i < tableau.Length; i++)
                {
                    int val = tableau[i];
                    if(val > max)
                    {
                        max = val;
                        pos = i;
                    }
                }
            }

            return pos;
        }

        [Exercice("Position de la valeur maximum")]
        static void Exercice3_1()
        {
            int[] tab = S2_TD2.RemplirTableau();
            int posMax = PositionMaximum(tab);

            if(posMax == -1)
            {
                Console.WriteLine("Le tableau est null ou vide et n'admet pas de valeur max.");
            } else
            {
                Console.WriteLine("Pour le tableau...");
                S2_TD2.AfficherTableau(tab);
                Console.WriteLine("... la valeur max est à la position " + posMax + ".");
            }
        }

        [Exercice("4-0", "Méthode 'bool EstPresent(int[] tableau, int valeur)'", exerciceSource = true)]
        static bool EstPresent(int[] tableau, int valeur)
        {
            // autorisé ?
            return Rechercher(tableau, valeur) != -1;
        }

        [Exercice("Test de présence dans un tableau")]
        static void Exercice4_1()
        {
            int[] tab = S2_TD2.RemplirTableau();

            Console.Write("Entrez une valeur à tester : ");
            int val = int.Parse(Console.ReadLine());

            Console.WriteLine("La valeur " + val + " " + (EstPresent(tab, val) ? "est" : "n'est pas") + " présente dans le tableau.");
        }

        [Exercice("5-0", "Méthode 'int NombreOccurrences(int[] tableau, int valeur)'", exerciceSource = true)]
        static int NombreOccurrences(int[] tableau, int valeur)
        {
            int res = 0;

            if(tableau != null)
            {
                foreach(int item in tableau)
                {
                    if(item == valeur)
                    {
                        res++;
                    }
                }
            }

            return res;
        }

        [Exercice("Nombre d'occurence dans un tableau")]
        static void Exercice5_1()
        {
            int[] tab = S2_TD2.RemplirTableau();

            Console.Write("Entrez une valeur à rechercher : ");
            int val = int.Parse(Console.ReadLine());

            Console.WriteLine("La valeur " + val + " est présente " + NombreOccurrences(tab, val) + " fois dans le tableau.");
        }

        [Exercice("6-0", "Méthode 'bool AdditionnerValeur(int[] tableau, int valeur)'", exerciceSource = true)]
        static bool AdditionnerValeur(int[] tableau, int valeur)
        {
            bool res = false;

            if (tableau != null && tableau.Length > 0)
            {
                for (int i = 0; i < tableau.Length; i++)
                {
                    tableau[i] += valeur;
                }

                res = true;
            }

            return res;
        }

        [Exercice("Addition à tous les éléments d'un tableau")]
        static void Exercice6_1()
        {
            int[] tab = S2_TD2.RemplirTableau();

            Console.Write("Entrez une valeur à ajouter : ");
            int val = int.Parse(Console.ReadLine());

            if(AdditionnerValeur(tab, val))
            {
                Console.WriteLine("Nouveau tableau :");
                S2_TD2.AfficherTableau(tab);
            } else
            {
                Console.WriteLine("Impossible d'ajouter la valeur au tableau (celui est vide ou null).");
            }
        }

        [Exercice("7-0", "Méthode 'int[] AdditionnerTableaux(int[] tableau1, int[] tableau2)'", exerciceSource =  true)]
        static int[] AdditionnerTableaux(int[] tableau1, int[] tableau2)
        {
            int[] res = null;

            if(tableau1 != null && tableau2 != null && tableau1.Length == tableau2.Length)
            {
                res = new int[tableau1.Length];

                for(int i = 0; i < tableau1.Length; i++)
                {
                    res[i] = tableau1[i] + tableau2[i];
                }
            }

            return res;
        }

        [Exercice("Addition des éléments de 2 tableaux")]
        static void Exercice7_1()
        {
            int[] tab1 = S2_TD2.RemplirTableau();
            int[] tab2 = S2_TD2.RemplirTableau();

            Console.WriteLine("Tableau additionné :");
            S2_TD2.AfficherTableau(AdditionnerTableaux(tab1, tab2));
        }

        [Exercice("8-0", "Méthode 'int NombreValeursDifferentes(int[] tableau)'", exerciceSource = true)]
        static int NombreValeursDifferentes(int[] tableau)
        {
            int res = -1;

            if(tableau != null)
            {
                res = 0;

                for(int i = 0; i < tableau.Length; i++)
                {

                    if(Rechercher(tableau, tableau[i]) == i)
                    {
                        res++;
                    }
                }
            }

            return res;
        }

        [Exercice("Comptage du nombre de valeurs différentes")]
        static void Exercice8_1()
        {
            int[] tab = S2_TD2.RemplirTableau();
            int compte = NombreValeursDifferentes(tab);

            Console.WriteLine("Dans le tableau, il y a " + compte + " valeur(s) différente(s).");
        }

        [Exercice("9-0", "Méthode 'int[] Echange(int [] tableau, int indice1, int indice2)'", exerciceSource = true)]
        static int[] Echange(int[] tableau, int indice1, int indice2)
        {
            if(tableau != null)
            {
                int l = tableau.Length;

                if(indice1 >= 0 && indice1 < l && indice2 >= 0 && indice2 < l)
                {
                    int t = tableau[indice1];
                    tableau[indice1] = tableau[indice2];
                    tableau[indice2] = t;
                }
            }

            return tableau;
        }

        [Exercice("Echange de 2 valeurs")]
        static void Exercice9_1()
        {
            int[] tab = S2_TD2.RemplirTableau();

            Console.Write("Entrez l'indice 1 : ");
            int i1 = int.Parse(Console.ReadLine());

            Console.Write("Entrez l'indice 2 : ");
            int i2 = int.Parse(Console.ReadLine());

            Console.WriteLine("\nTableau avant échange :");
            S2_TD2.AfficherTableau(tab);

            Echange(tab, i1, i2);

            Console.WriteLine("Tableau après échange :");
            S2_TD2.AfficherTableau(tab);
        }
    }
}
