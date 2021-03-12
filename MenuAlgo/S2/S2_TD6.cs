using MenuAlgo;
using OutilsTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAlgo
{
    public class S2_TD6
    {
        [Exercice("0-0", "Méthode 'int[,] MatriceAleatoire(int lignes, int colonnes)'", exerciceSource = true)]
        public static int[,] MatriceAleatoire(int lignes, int colonnes, int min = 0, int max = 100)
        {
            int[,] matrice = null;

            if (lignes >= 0 && lignes >= 0)
            {
                Random random = new Random();

                matrice = new int[lignes, colonnes];

                for(int i = 0; i < lignes; i++)
                {
                    for(int j = 0; j < colonnes; j++)
                    {
                        matrice[i, j] = random.Next(min, max);
                    }
                }
            }

            return matrice;
        }

        [Exercice("0-1", "Méthode 'int[,] DemandeMatriceAleatoire()'", exerciceSource = true)]
        public static int[,] DemandeMatriceAleatoire()
        {
            Console.Write("Entrez un nombre de lignes : ");
            int lignes = int.Parse(Console.ReadLine());

            Console.Write("Entrez un nombre de colonnes : ");
            int colonnes = int.Parse(Console.ReadLine());

            int min = 0;
            int max = 0;

            if(lignes > 0 && colonnes > 0)
            {
                Console.Write("Entrez une valeur min : ");
                min = int.Parse(Console.ReadLine());

                Console.Write("Entrez une valeur max : ");
                max = int.Parse(Console.ReadLine());
            }

            return MatriceAleatoire(lignes, colonnes, min, max);
        }

        [Exercice("0-2", "Méthode 'void AfficherMatriceTitre(int[,] matrice)'", exerciceSource = true)]
        public static void AfficherMatriceTitre(int[,] matrice, string titre = "Matrice")
        {
            Console.WriteLine("\n" + titre + " :");
            S2_TD5.AfficherMatrice(matrice);
            Console.WriteLine();
        }

        [Exercice("1-0", "Méthode 'int[] Rechercher(int[,] matrice, int valeur)'", exerciceSource = true)]
        static int[] Rechercher(int[,] matrice, int valeur)
        {
            int[] res = null;

            if(matrice != null && matrice.Length > 0)
            {
                for(int i = 0; i < matrice.GetLength(0) && res == null; i++)
                {
                    for (int j = 0; j < matrice.GetLength(1) && res == null; j++)
                    {
                        if (matrice[i, j] == valeur)
                        {
                            res = new int[] { i, j };
                        }
                    }
                }
            }

            return res;
        }

        [Exercice("Rechercher une valeur dans une matrice")]
        static void Exercice1_1()
        {
            int[,] matrice = DemandeMatriceAleatoire();

            Console.Write("Entrez une valeur à rechercher : ");
            int val = int.Parse(Console.ReadLine());

            AfficherMatriceTitre(matrice);

            int[] res = Rechercher(matrice, val);
            if(res == null)
            {
                Console.WriteLine("La valeur n'a pas été trouvée.");
            } else
            {
                Console.WriteLine("La valeur a été trouvée à ligne " + res[0] + " et la colonne " + res[1]);
            }
        }

        [Exercice("2-0", "Méthode 'int[] PositionMinimum(int[,] matrice)'", exerciceSource = true)]
        static int[] PositionMinimum(int[,] matrice)
        {
            int[] res = null;
            int min = int.MaxValue;

            if(matrice != null)
            {
                for(int i = 0; i < matrice.GetLength(0); i++)
                {
                    for(int j = 0; j < matrice.GetLength(1); j++)
                    {
                        int val = matrice[i, j];
                        if(val < min)
                        {
                            min = val;
                            res = new int[] { i, j };
                        }
                    }
                }
            }

            return res;
        }

        [Exercice("Position de la valeur minimum d'une matrice")]
        static void Exercice2_1()
        {
            int[,] matrice = DemandeMatriceAleatoire();

            AfficherMatriceTitre(matrice);

            int[] posMin = PositionMinimum(matrice);

            if(posMin == null)
            {
                Console.WriteLine("Il n'a pas de valeur minimum");
            } else
            {
                Console.WriteLine("La valeur minimum est à la ligne " + posMin[0] + " et à la colonne " + posMin[1]);
            }
        }

        [Exercice("3-0", "Méthode 'bool AjouterValeur(int[,] matrice, int valeur)'", exerciceSource = true)]
        static bool AjouterValeur(int[,] matrice, int valeur)
        {
            bool res = false;

            if(matrice != null && matrice.Length > 0)
            {
                res = true;
                for(int i = 0; i < matrice.GetLength(0); i++)
                {
                    for(int j = 0; j < matrice.GetLength(1); j++)
                    {
                        matrice[i, j] += valeur;
                    }
                }
            }

            return res;
        }

        [Exercice("Ajouter une valeur à toute une matrice")]
        static void Exercice3_1()
        {
            int[,] matrice = DemandeMatriceAleatoire();

            Console.Write("Quelle valeur ajouter ? ");
            int val = int.Parse(Console.ReadLine());

            AfficherMatriceTitre(matrice, "Matrice avant ajout");
            if(AjouterValeur(matrice, val))
            {
                AfficherMatriceTitre(matrice, "Matrice après ajout");
            } else
            {
                Console.WriteLine("L'ajout n'a pas pu se faire.");
            }
        }

        [Exercice("4-0", "Méthode 'int[,] AdditionnerMatrices(int[,] matrice1 , int[,] matrice2)'", exerciceSource = true)]
        static int[,] AdditionnerMatrices(int[,] matrice1, int[,] matrice2)
        {
            int[,] res = null;

            if(matrice1 != null && matrice2 != null
                && matrice1.GetLength(0) == matrice2.GetLength(1)
                && matrice1.GetLength(1) == matrice2.GetLength(1))
            {
                int l = matrice1.GetLength(0);
                int c = matrice2.GetLength(1);
                res = new int[l, c];

                for(int i = 0; i < l; i++)
                {
                    for(int j = 0; j < c; j++)
                    {
                        res[i, j] = matrice1[i, j] + matrice2[i, j];
                    }
                }
            }

            return res;
        }

        [Exercice("Addition de 2 matrices")]
        static void Exercice4_1()
        {
            int[,] mat1 = DemandeMatriceAleatoire();
            int[,] mat2 = DemandeMatriceAleatoire();

            int[,] somme = AdditionnerMatrices(mat1, mat2);

            AfficherMatriceTitre(mat1, "Matrice 1");
            AfficherMatriceTitre(mat2, "Matrice 2");
            AfficherMatriceTitre(somme, "Somme des matrices");
        }

        [Exercice("5-0", "Méthode 'double[] calcul_moyenne_matiere(int[,] matrice)'", exerciceSource = true)]
        static double[] calcul_moyenne_matiere(int[,] matrice)
        {
            double[] res = null;

            if(matrice != null)
            {
                int l = matrice.GetLength(0);
                res = new double[l];

                int c = matrice.GetLength(1);

                for(int i = 0; i < l; i++)
                {
                    double total = 0;

                    for(int j = 0; j < c; j++)
                    {
                        total += matrice[i, j];
                    }

                    res[i] = total / c;
                }
            }

            return res;
        }

        [Exercice("Moyenne par ligne")]
        static void Exercice5_1()
        {
            int[,] matrice = DemandeMatriceAleatoire();
            double[] moyennes = calcul_moyenne_matiere(matrice);

            AfficherMatriceTitre(matrice, "Notes des élèves");

            Console.WriteLine("Moyennes par matière :");
            S2_TD2.AfficherTableau(moyennes);
        }

        [Exercice("6-0", "Méthode 'int[,] MatriceTransposee(int[,] matrice)'", exerciceSource = true)]
        static int[,] MatriceTransposee(int[,] matrice)
        {
            int[,] res = null;

            if(matrice != null)
            {
                int l = matrice.GetLength(0);
                int c = matrice.GetLength(1);

                res = new int[c, l];

                for(int i = 0; i < l; i++)
                {
                    for(int j = 0; j < c; j++)
                    {
                        res[j, i] = matrice[i, j];
                    }
                }
            }

            return res;
        }

        [Exercice("Matrice transposée")]
        static void Exercice6_1()
        {
            int[,] matrice = DemandeMatriceAleatoire();
            int[,] transposee = MatriceTransposee(matrice);

            AfficherMatriceTitre(matrice);
            AfficherMatriceTitre(transposee, "Matrice tranposée");
            AfficherMatriceTitre(MatriceTransposee(transposee), "Vérification");
        }

        [Exercice("7-0", "Méthode 'int[,] ProduitMatriciel(int[,] mat1, int[,] mat2)'", exerciceSource = true)]
        static int[,] ProduitMatriciel(int[,] mat1, int[,] mat2)
        {
            int[,] res = null;

            if(mat1 != null && mat2 != null)
            {
                int m = mat1.GetLength(0);
                int n1 = mat1.GetLength(1);
                int n2 = mat2.GetLength(0);
                int p = mat2.GetLength(1);

                if(n1 == n2)
                {
                    res = new int[m, p];

                    for(int l = 0; l < m; l++)
                    {
                        for(int c = 0; c < p; c++)
                        {
                            int val = 0;

                            for(int i = 0; i < n1; i++)
                            {
                                val += mat1[l, i] * mat2[i, c];
                            }

                            res[l, c] = val;
                        }
                    }
                }
            }

            return res;
        }

        [Exercice("Produit matricel de 2 matrices")]
        static void Exercice7_1()
        {
            int[,] mat1 = DemandeMatriceAleatoire();
            int[,] mat2 = DemandeMatriceAleatoire();

            int[,] res = ProduitMatriciel(mat1, mat2);

            AfficherMatriceTitre(mat1, "Matrice A");
            AfficherMatriceTitre(mat2, "Matrice B");

            AfficherMatriceTitre(res, "Produit matriciel AB");
        }
    }
}
