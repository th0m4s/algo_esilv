using System;
using OutilsTD;

namespace MenuAlgo
{
    public class S2_TD2
    {
        [Exercice("1-1", "Méthode 'bool Palindrome_2index(string mot)'", exerciceSource = true)]
        static bool Palindrome_2index(string mot)
        {
            bool palindrome = true;

            if(mot.Length == 0)
            {
                palindrome = false;
            } else
            {
                int a = 0;
                int b = mot.Length - 1;

                while (palindrome && a < b)
                {
                    if (mot[a] != mot[b])
                    {
                        palindrome = false;    
                    }

                    a++;
                    b--;
                }
            }

            return palindrome;
        }

        [Exercice("Test de palindrome avec 2 index")]
        static void Exercice1_2()
        {
            Console.Write("Entrez un mot : ");
            string mot = Console.ReadLine().ToLower();
            if (Palindrome_2index(mot)) Console.WriteLine("Le mot '" + mot + "' est un palindrome.");
            else Console.WriteLine("Le mot '" + mot + "' n'est pas un palindrome.");
        }

        [Exercice("1-3", "Méthode 'bool Palindrome_1index(string mot)'", exerciceSource = true)]
        static bool Palindrome_1index(string mot)
        {
            bool palindrome = true;

            if(mot.Length == 0)
            {
                palindrome = false;
            } else
            {
                for (int i = 0; palindrome && i < mot.Length / 2; i++)
                {
                    if (mot[i] != mot[mot.Length - 1 - i])
                    {
                        palindrome = false;
                    }
                }
            }

            return palindrome;
        }

        [Exercice("Test de palindrome avec 2 index")]
        static void Exercice1_4()
        {
            Console.Write("Entrez un mot : ");
            string mot = Console.ReadLine().ToLower();
            if (Palindrome_1index(mot)) Console.WriteLine("Le mot '" + mot + "' est un palindrome.");
            else Console.WriteLine("Le mot '" + mot + "' n'est pas un palindrome.");
        }

        [Exercice("2-1", "Méthode 'void AfficherTableau(int[] tab)'", exerciceSource = true)]
        public static void AfficherTableau(int[] tab)
        {
            if (tab == null)
            {
                Console.WriteLine("(tableau null)");
            }
            else if (tab.Length == 0)
            {
                Console.WriteLine("(tableau vide)");
            }
            else
            {
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    Console.Write(tab[i] + " ; ");
                }

                Console.WriteLine(tab[tab.Length - 1]);
            }
        }

        [Exercice("2-2", "Méthode 'void AfficherTableau(double[] tab)'", exerciceSource = true)]
        public static void AfficherTableau(double[] tab)
        {
            if (tab == null)
            {
                Console.WriteLine("(tableau null)");
            }
            else if (tab.Length == 0)
            {
                Console.WriteLine("(tableau vide)");
            }
            else
            {
                for (int i = 0; i < tab.Length - 1; i++)
                {
                    Console.Write(tab[i] + " ; ");
                }

                Console.WriteLine(tab[tab.Length - 1]);
            }
        }

        [Exercice("3-0", "Méthode 'int[] RemplirTableau()'", exerciceSource = true)]
        public static int[] RemplirTableau()
        {
            // demande à l'utilisateur un tableau
            Console.Write("Saisir une taille de tableau : ");
            int l = int.Parse(Console.ReadLine());

            if(l < 0)
            {
                Console.WriteLine("Le tableau sera null.");
                return null;
            }

            int[] tab = new int[l];
            for(int i = 0; i < l; i++)
            {
                Console.Write("Entrez l'élément " + i + " : ");
                tab[i] = int.Parse(Console.ReadLine());
            }

            return tab;
        }

        [Exercice("3-1", "Méthode 'int[] ConcatenerTableaux(int[] tab1, int[] tab2)'", exerciceSource = true)]
        static int[] ConcatenerTableaux(int[] tab1, int[] tab2)
        {
            if (tab1 == null && tab2 == null) return null;
            else
            {
                int l1 = 0;
                if (tab1 != null) l1 = tab1.Length;

                int l2 = 0;
                if (tab2 != null) l2 = tab2.Length;

                int[] tab = new int[l1 + l2];

                if(l1 > 0)
                {
                    for(int i = 0; i < l1; i++)
                    {
                        tab[i] = tab1[i];
                    }
                }

                if(l2 > 0)
                {
                    for(int i = 0; i < l2; i++)
                    {
                        tab[l1 + i] = tab2[i];
                    }
                }

                return tab;
            }
        }

        [Exercice("Concaténation de 2 tableaux")]
        static void Exercice3_3()
        {
            int[] tab1 = RemplirTableau();
            int[] tab2 = RemplirTableau();

            int[] tab = ConcatenerTableaux(tab1, tab2);
            Console.WriteLine("Voici le tableau concaténé : ");
            AfficherTableau(tab);
        }

        [Exercice("4-1", "Méthode 'int[] NouveauTableauInverse(int[] tab)'", exerciceSource = true)]
        static int[] NouveauTableauInverse(int[] tab)
        {
            int[] inverse = new int[tab.Length];
            for(int i = 0; i < tab.Length; i++)
            {
                inverse[tab.Length - 1 - i] = tab[i];
            }

            return inverse;
        }

        [Exercice("Inversion d'un tableau (avec nouveau tableau en retour)")]
        static void Exercice4_2()
        {
            int[] tab = RemplirTableau();
            if (tab != null)
            {
                int[] inverse = NouveauTableauInverse(tab);

                Console.WriteLine("Le tableau inversé est : ");
                AfficherTableau(inverse);
            }
            else Console.WriteLine("Impossible d'inverser un tableau null !");
        }

        [Exercice("5-1", "Méthode 'void InverserTableau(int[] tab)'", exerciceSource = true)]
        static void InverserTableau(int[] tab)
        {
            if(tab != null)
            {
                for (int i = 0; i < tab.Length / 2; i++)
                {
                    int t = tab[i];
                    int i2 = tab.Length - 1 - i;

                    tab[i] = tab[i2];
                    tab[i2] = t;
                }
            }
        }

        [Exercice("Inversion d'un tableau (avec référence)")]
        static void Exercice5_2()
        {
            int[] tab = RemplirTableau();
            if (tab != null)
            {
                InverserTableau(tab);

                Console.WriteLine("Le tableau inversé est : ");
                AfficherTableau(tab);
            }
            else Console.WriteLine("Impossible d'inverser un tableau null !");
        }

        [Exercice("6-1", "Méthode 'void AfficherTriangle(int[] tab)'")]
        static void AfficherTriangle(int[] tab)
        {
            for(int l = 0; l < tab.Length; l++)
            {
                for(int c = 0; c <= l; c++)
                {
                    Console.Write(tab[c] + " ");
                }

                Console.WriteLine();
            }
        }

        [Exercice("Afficher un tableau en triangle")]
        static void Exercice6_2()
        {
            int[] tab = RemplirTableau();
            if (tab == null) Console.WriteLine("Impossible d'afficher un tableau null en triangle !");
            else AfficherTriangle(tab);
        }

        [Exercice("7-1", "Méthode 'int[] AgrandirTableau(int[] tab, int nbSup, int valeurInit)'", exerciceSource = true)]
        static int[] AgrandirTableau(int[] tab, int nbSup, int valeurInit)
        {
            if (nbSup < 0) nbSup = 0;
            // on ne peut pas rajouter un nombre négatif de cases

            int l = 0;
            int total = nbSup;
            if (tab != null)
            {
                l = tab.Length;
                total += l;
            }

            int[] agrandi = new int[total];
            if(l > 0)
            {
                for(int i = 0; i < l; i++)
                {
                    agrandi[i] = tab[i];
                }
            }

            for(int i = 0; i < nbSup; i++)
            {
                agrandi[l + i] = valeurInit;
            }

            return agrandi;
        }

        [Exercice("Agrandir un tableau")]
        static void Exercice7_2()
        {
            int[] tab = RemplirTableau();
            Console.WriteLine("De combien de cases voulez-vous agrandir le tableau ? ");
            int nbSup = int.Parse(Console.ReadLine());
            Console.WriteLine("Par quelle valeur voulez-vous remplir ces cases ? ");
            int valeurInit = int.Parse(Console.ReadLine());

            int[] agrandi = AgrandirTableau(tab, nbSup, valeurInit);
            Console.WriteLine("Tableau agrandi : ");
            AfficherTableau(agrandi);
        }
    }
}
