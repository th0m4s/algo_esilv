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
    public class S2_TD9
    {
        [Exercice("0-0", "Méthode 'void AfficherListeEntiers(List<int> liste)'", exerciceSource = true)]
        public static void AfficherListeEntiers(List<int> liste)
        {
            if(liste == null)
            {
                Console.WriteLine("(liste nulle)");
            } else if(liste.Count == 0)
            {
                Console.WriteLine("(liste vide)");
            } else
            {
                foreach(int val in liste)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }

        [Exercice("0-1", "Méthode 'void AfficherListeReels(List<double> liste)'", exerciceSource = true)]
        public static void AfficherListeReels(List<double> liste)
        {
            if (liste == null)
            {
                Console.WriteLine("(liste nulle)");
            }
            else if (liste.Count == 0)
            {
                Console.WriteLine("(liste vide)");
            }
            else
            {
                foreach (double val in liste)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }

        [Exercice("Liste d'entiers positifs et négatifs")]
        static void Exercice2()
        {
            List<double> valeurs = new List<double>();

            string val;

            do
            {
                val = Console.ReadLine();
                if(double.TryParse(val, out double intVal))
                {
                    valeurs.Add(intVal);
                }
            } while (val != "fin");

            List<double> valeursPos = valeurs.FindAll(x => x >= 0);
            Console.WriteLine("Valeurs positives :");
            AfficherListeReels(valeursPos);
            if(valeursPos.Count > 0)
            {
                Console.WriteLine("Moyenne des valeurs positives : " + valeursPos.Average());
            }

            List<double> valeursNeg = valeurs.FindAll(x => x < 0);
            Console.WriteLine("Valeurs négatives :");
            AfficherListeReels(valeursNeg);
            if (valeursNeg.Count > 0)
            {
                Console.WriteLine("Moyenne des valeurs négatives : " + valeursNeg.Average());
            }
        }

        [Exercice("Opérations sur une liste")]
        static void Exercice3()
        {
            int[] tab = new int[] { 3, 5, 1, 2, 7, 2, 8, 5, 2, 4 };
            List<int> list = new List<int>(tab);
            AfficherListeEntiers(list);

            int indexDe8 = list.IndexOf(8);
            Console.WriteLine("indexDe8 = " + indexDe8);

            int dernierIndexDe5 = list.LastIndexOf(5);
            Console.WriteLine("dernierIndexDe = " + dernierIndexDe5);

            Console.WriteLine("indexDe42 = " + list.IndexOf(42));

            int valeurIndex4 = list.ElementAt(4);
            Console.WriteLine("valeurIndex4 = " + valeurIndex4);

            int min = list.Min();
            int max = list.Max();

            Console.WriteLine("min = " + min + " ; max = " + max);

            list.Reverse();
            AfficherListeEntiers(list);

            list.Remove(2);
            AfficherListeEntiers(list);

            list.Sort();
            AfficherListeEntiers(list);

            list.Clear();
            AfficherListeEntiers(list); 
        }

        [Exercice("4-0", "Méthode 'int CoeffBinomial(int k, int n)'", exerciceSource = true)]
        static int CoeffBinomial(int k, int n)
        {
            return S1_TD11.Factorielle_BoucleFor(n) / (S1_TD11.Factorielle_BoucleFor(k) * S1_TD11.Factorielle_BoucleFor(n - k));
        }

        [Exercice("4-1", "Méthode 'List<List<int>> GenererTrianglePascal(int n)'", exerciceSource = true)]
        static List<List<int>> GenererTrianglePascal(int n) {
            List<List<int>> triangle = null;

            if(n >= 0)
            {
                triangle = new List<List<int>>();

                for(int i = 0; i < n; i++)
                {
                    List<int> ligne = new List<int>();
                    for(int j = 0; j <= i; j++)
                    {
                        ligne.Add(CoeffBinomial(j, i));
                    }
                    triangle.Add(ligne);
                }
            }

            return triangle;
        }

        [Exercice("4-2", "Méthode 'void AfficherTrianglePascal(List<List<int>>)'", exerciceSource = true)]
        static void AfficherTrianglePascal(List<List<int>> triangle)
        {
            if(triangle == null)
            {
                Console.WriteLine("(triangle nul)");
            } else if(triangle.Count == 0)
            {
                Console.WriteLine("(triangle vide)");
            } else
            {
                foreach(List<int> list in triangle)
                {
                    AfficherListeEntiers(list);
                }
            }
        }

        [Exercice("Triangles de pascal")]
        static void Exercice4_3()
        {
            Console.Write("Entrez une taille : ");
            int n = int.Parse(Console.ReadLine());

            List<List<int>> triangle = GenererTrianglePascal(n);
            AfficherTrianglePascal(triangle);
        }
    }
}
