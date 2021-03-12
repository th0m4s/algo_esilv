using MenuAlgo;
using OutilsTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAlgo
{
    public class S2_TD5
    {
        [Exercice("1", "Méthode 'void AfficherMatrice(int[,] matrice)'", exerciceSource = true)]
        public static void AfficherMatrice(int[,] matrice)
        {
            if(matrice == null)
            {
                Console.WriteLine("(matrice null)");
            } else if(matrice.Length == 0)
            {
                Console.WriteLine("(matrice vide)");
            } else
            {
                for(int i = 0; i < matrice.GetLength(0); i++)
                {
                    for(int j = 0; j < matrice.GetLength(1); j++)
                    {
                        int val = matrice[i, j];
                        if (val < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(val + " ");
                    }

                    Console.WriteLine();
                }
            }
        }

        [Exercice("2-1", "Méthode 'int[,] CreerMatriceNombresPairs(int nombreLignes, int nombreColonnes)'", exerciceSource = true)]
        static int[,] CreerMatriceNombresPairs(int nombreLignes, int nombreColonnes)
        {
            int[,] matrice = null;

            if(nombreLignes >=0 && nombreColonnes >= 0)
            {
                matrice = new int[nombreLignes, nombreColonnes];

                for(int i = 0; i < nombreLignes; i++)
                {
                    for(int j = 0; j < nombreColonnes; j++)
                    {
                        matrice[i, j] = (i * nombreColonnes + j + 1) * 2;
                    }
                }
            }

            return matrice;
        }

        [Exercice("Création et remplissage d'une matrice de nombre pairs")]
        static void Exercice2_2()
        {
            Console.Write("Entrez un nombre de lignes : ");
            int lignes = int.Parse(Console.ReadLine());

            Console.Write("Entrez un nombre de colonnes : ");
            int colonnes = int.Parse(Console.ReadLine());

            int[,] matrice = CreerMatriceNombresPairs(lignes, colonnes);
            AfficherMatrice(matrice);
        }

        [Exercice("3-1", "Méthode 'int[] ExtraireColonne(int[,] matrice, int indexColonne)'", exerciceSource = true)]
        static int[] ExtraireColonne(int[,] matrice, int indexColonne)
        {
            int[] res = null;

            if(matrice != null && indexColonne < matrice.GetLength(1))
            {
                int taille = matrice.GetLength(0);
                res = new int[taille];

                for (int i = 0; i < taille; i++)
                {
                    res[i] = matrice[i, indexColonne];
                }
            }

            return res;
        }

        [Exercice("Extraire une colonne")]
        static void Exercice3_2()
        {
            Console.Write("Entrez un nombre de lignes : ");
            int lignes = int.Parse(Console.ReadLine());

            Console.Write("Entrez un nombre de colonnes : ");
            int colonnes = int.Parse(Console.ReadLine());

            int[,] matrice = CreerMatriceNombresPairs(lignes, colonnes);

            Console.Write("Entrez un numéro de colonne : ");
            int indexColonne = int.Parse(Console.ReadLine());

            int[] colonne = ExtraireColonne(matrice, indexColonne);

            S2_TD2.AfficherTableau(colonne);
        }

        [Exercice("4-1", "Méthode 'void AfficherDiagonale1(int[,] matrice)'", exerciceSource = true)]
        static void AfficherDiagonale1(int[,] matrice)
        {
            if(matrice == null)
            {
                Console.WriteLine("(matrice nulle)");
            } else if(matrice.Length == 0)
            {
                Console.WriteLine("(matrice vide)");
            } else
            {
                int d0 = matrice.GetLength(0);
                int d1 = matrice.GetLength(1);

                if(d0 == d1)
                {
                    for(int i = 0; i < d0; i++)
                    {
                        Console.Write(matrice[i, i] + " ");
                    }
                } else
                {
                    Console.WriteLine("Impossible de trouver la diagonale.");
                }
            }
        }

        [Exercice("4-2", "Méthode 'void AfficherDiagonale2(int[,] matrice)'", exerciceSource = true)]
        static void AfficherDiagonale2(int[,] matrice)
        {
            if (matrice == null)
            {
                Console.WriteLine("(matrice nulle)");
            }
            else if (matrice.Length == 0)
            {
                Console.WriteLine("(matrice vide)");
            }
            else
            {
                int d0 = matrice.GetLength(0);
                int d1 = matrice.GetLength(1);

                if (d0 == d1)
                {
                    for (int i = 0; i < d0; i++)
                    {
                        Console.Write(matrice[i, d0 - 1 - i] + " ");
                    }
                }
                else
                {
                    Console.WriteLine("Impossible de trouver la diagonale.");
                }
            }
        }

        [Exercice("5-1", "Méthode 'int[,] TableMultiplication(int nombreMax, int multiplicateurMax)'", exerciceSource = true)]
        static int[,] TableMultiplication(int nombreMax, int multiplicateurMax)
        {
            int[,] res = null;

            if(nombreMax > 1 && multiplicateurMax > 1)
            {
                res = new int[nombreMax, multiplicateurMax];

                for(int i = 1; i <= nombreMax; i++)
                {
                    for(int j = 1; j <= multiplicateurMax; j++)
                    {
                        res[i-1, j-1] = i * j;
                    }
                }
            }

            return res;
        }

        [Exercice("Afficher table de multiplication")]
        static void Exercice5_2()
        {
            Console.Write("Entrez un nombre max : ");
            int max = int.Parse(Console.ReadLine());

            Console.Write("Entrez un multiplicateur max : ");
            int mult = int.Parse(Console.ReadLine());

            int[,] table = TableMultiplication(max, mult);
            AfficherMatrice(table);
        }

        [Exercice("6-1", "Méthode 'void AfficherTabTab(int[][] tabTab)'", exerciceSource = true)]
        public static void AfficherTabTab(int[][] tabTab)
        {
            if(tabTab == null)
            {
                Console.WriteLine("(tableau de tableaux null)");
            } else if(tabTab.Length == 0)
            {
                Console.WriteLine("(tableau de tableaux vide)");
            } else
            {
                for(int i = 0; i < tabTab.Length; i++)
                {
                    S2_TD2.AfficherTableau(tabTab[i]);
                }
            }
        }

        [Exercice("6-2", "Méthode 'int[][] CreerTabTabPair(int nbLignes, int nbColonnes)'", exerciceSource = true)]
        static int[][] CreerTabTabPair(int nbLignes, int nbColonnes)
        {
            int[][] res = null;

            if(nbLignes >= 0)
            {
                res = new int[nbLignes][];

                if (nbColonnes >= 0)
                {
                    for (int i = 0; i < nbLignes; i++)
                    {
                        res[i] = new int[nbColonnes];

                        for (int j = 0; j < nbColonnes; j++)
                        {
                            res[i][j] = (i * nbColonnes + j + 1) * 2;
                        }
                    }
                }
            }

            return res;
        }

        [Exercice("Création tableau de tableaux à valeurs paires")]
        static void Exercice6_3()
        {
            Console.Write("Entrez un nombre de lignes : ");
            int lignes = int.Parse(Console.ReadLine());

            Console.Write("Entrez un nombre de colonnes : ");
            int colonnes = int.Parse(Console.ReadLine());

            int[][] tabTab = CreerTabTabPair(lignes, colonnes);
            AfficherTabTab(tabTab);
        }

        [Exercice("7-1", "Méthode 'int[] ExtraireLigne(int[,] matrice, int indexLigne)'", exerciceSource = true)]
        static int[] ExtraireLigne(int[,] matrice, int indexLigne)
        {
            int[] res = null;

            if (matrice != null && indexLigne < matrice.GetLength(0))
            {
                int taille = matrice.GetLength(1);
                res = new int[taille];

                for (int i = 0; i < taille; i++)
                {
                    res[i] = matrice[indexLigne, i];
                }
            }

            return res;
        }

        [Exercice("Extraire une ligne")]
        static void Exercice7_2()
        {
            Console.Write("Entrez un nombre de lignes : ");
            int lignes = int.Parse(Console.ReadLine());

            Console.Write("Entrez un nombre de colonnes : ");
            int colonnes = int.Parse(Console.ReadLine());

            int[,] matrice = CreerMatriceNombresPairs(lignes, colonnes);

            Console.Write("Entrez un numéro de ligne : ");
            int indexLigne = int.Parse(Console.ReadLine());

            int[] ligne = ExtraireLigne(matrice, indexLigne);

            S2_TD2.AfficherTableau(ligne);
        }

        [Exercice("8-1", "Méthode 'void AfficherTableMultiplication(int[,] table)'", exerciceSource = true)]
        static void AfficherTableMultiplication(int[,] table)
        {
            // au moins 2*2
            if(table != null && table.Length >= 4)
            {
                Console.Write("    ");
                for(int i = 0; i < table.GetLength(1); i++)
                {
                    if(i < 9)
                    {
                        Console.Write(" ");
                    }

                    Console.Write((i + 1) + " ");
                }
                Console.WriteLine();

                int lignes = table.GetLength(0);
                int colonnes = table.GetLength(1);

                string pointilles = S2_TD1.Repeter("-", colonnes * 3 + 1);
                Console.WriteLine(" X" + pointilles);

                for(int l = 0; l < lignes; l++)
                {
                    if (l < 9)
                    {
                        Console.Write(" ");
                    }
                    Console.Write((l + 1) + " |");

                    for (int c = 0; c < colonnes; c++)
                    {
                        int val = (c + 1) * (l + 1);
                        if (val < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(val + "|");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("   " + pointilles);
            }
        }

        [Exercice("Afficher joliement table de multiplication")]
        static void Exercice8_2()
        {
            Console.Write("Entrez un nombre max : ");
            int max = int.Parse(Console.ReadLine());

            Console.Write("Entrez un multiplicateur max : ");
            int mult = int.Parse(Console.ReadLine());

            int[,] table = TableMultiplication(max, mult);
            AfficherTableMultiplication(table);
        }
    }
}
