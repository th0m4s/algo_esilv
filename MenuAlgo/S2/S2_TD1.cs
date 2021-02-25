using System;
using OutilsTD;

namespace MenuAlgo
{
    public class S2_TD1
    {
        [Exercice("1-1", "Affichage tableau avec une boucle while")]
        static void Exercice1_1()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            int i = 0;
            while(i < tab.Length)
            {
                Console.Write(tab[i] + " ");
                i++;
            }

            Console.WriteLine();
        }

        [Exercice("1-2", "Affichage tableau avec une boucle for")]
        static void Exercice1_2()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }

            Console.WriteLine();
        }

        [Exercice("1-3", "Affichage tableau avec une boucle foreach")]
        static void Exercice1_3()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            foreach(int item in tab)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        [Exercice("Affichage d'un tableau avec séparateur")]
        static void Exercice2()
        {
            int[] tab = new int[] { 5, 8, 3, 2, 6, 4 };
            for(int i = 0; i < tab.Length - 1; i++)
            {
                Console.Write(tab[i] + " ; ");
            }

            Console.WriteLine(tab[tab.Length-1]);

            // on aurait pu utiliser string.Join(" ; ", tab);
        }

        [Exercice("Affichage tableau à l'envers")]
        static void Exercice3()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            for (int i = tab.Length - 1; i >= 0; i--)
            {
                Console.Write(tab[i] + " ");
            }

            Console.WriteLine();
        }

        [Exercice("Affichage 1 coup sur 2")]
        static void Exercice4()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            for (int i = 0; i < tab.Length; i+=2)
            {
                Console.Write(tab[i] + " ");
            }

            Console.WriteLine();
        }

        [Exercice("Affichage des valeurs paires")]
        static void Exercice5()
        {
            int[] tab = new int[6] { 5, 8, 3, 2, 6, 4 };
            for (int i = 0; i < tab.Length; i++)
            {
                int val = tab[i];
                if (val % 2 == 0)
                {
                    Console.Write(val + " ");
                }
            }

            Console.WriteLine();
        }

        [Exercice("Remplissage d'un tableau en ordre décroissant")]
        static void Exercice6()
        {
            Console.Write("Entrez une taille : ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] tab = new int[size];

            for(int i = 0; i < size; i++)
            {
                tab[i] = size-i;
            }

            // on a déjà fait des affichages de tableau
            Console.WriteLine(string.Join(" ", tab));
        }

        [Exercice("Remplissage d'un tableau de valeurs paires")]
        static void Exercice7()
        {
            Console.Write("Entrez une taille : ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] tab = new int[size];

            for (int i = 0; i < size; i++)
            {
                tab[i] = (i+1)*2;
            }

            // on a déjà fait des affichages de tableau
            Console.WriteLine(string.Join(" ", tab));
        }

        [Exercice("Remplissage d'un tableau de puissances de 2")]
        static void Exercice8()
        {
            Console.Write("Entrez une taille : ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] tab = new int[size];
            int val = 2;

            for (int i = 0; i < size; i++)
            {
                tab[i] = val;
                val *= 2;
            }

            // on a déjà fait des affichages de tableau
            Console.WriteLine(string.Join(" ", tab));
        }

        [Exercice("Tableau et moyenne")]
        static void Exercice9()
        {
            int size = 0;
            do
            {
                Console.Write("Entrez une taille : ");
                size = Convert.ToInt32(Console.ReadLine());
            } while (size < 2 || size > 5);

            double[] tab = new double[size];
            double total = 0;

            for(int i = 0; i < size; i++)
            {
                Console.Write("Entrez la valeur " + (i + 1) + " : ");
                double val = Convert.ToDouble(Console.ReadLine());
                total += val;
                tab[i] = val;
            }

            Console.WriteLine("La moyenne est " + (total / size));
            Console.WriteLine(string.Join(" ", tab));
        }

        [Exercice("10-0", "Méthode 'string Repeter(string chaine, int count)'", exerciceSource = true)]
       public static string Repeter(string chaine, int count)
        {
            string res = "";

            for(int i = 0; i < count; i++)
            {
                res += chaine;
            }

            return res;
        }

        [Exercice("Affichage d'un tableau en colonne")]
        static void Exercice10_1()
        {
            int[] tab = { 1, 23, 45, 6, 7, 1080 };
            int max = int.MinValue;

            foreach(int val in tab)
            {
                if(max < val)
                {
                    max = val;
                }
            }

            int chars = max.ToString().Length;

            // marge <=> ligne de pointillés
            string marge = Repeter("-", chars + 2);
            Console.WriteLine(marge);

            foreach(int val in tab)
            {
                string str = val.ToString();
                str = Repeter("0", chars - str.Length) + str;

                Console.WriteLine("|" + str + "|");
                Console.WriteLine(marge);
            }
        }

        [Exercice("Affichage d'un tableau en ligne")]
        static void Exercice11()
        {
            int[] tab = { 1, 23, 45, 6, 7, 1080 };
            int max = int.MinValue;

            foreach (int val in tab)
            {
                if (max < val)
                {
                    max = val;
                }
            }

            int chars = max.ToString().Length;

            // marge <=> ligne de pointillés
            string marge = Repeter("-", (chars+1)*tab.Length+1);
            Console.Write(marge + "\n|");

            foreach (int val in tab)
            {
                string str = val.ToString();
                str = Repeter("0", chars - str.Length) + str;

                Console.Write(str + "|");
            }

            Console.WriteLine("\n" + marge);
        }
    }
}
