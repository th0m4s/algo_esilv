using System;
using OutilsTD;

namespace MenuAlgo
{
    public class S1_TD11
    {
        [Exercice("1-1", "Méthode CaTourne (boucle for)", exerciceSource = true)]
        static void Exercice1_BoucleFor()
        {
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine("ça tourne " + i);
            }
        }

        [Exercice("1-2", "Méthode CaTourne (boucle while)", exerciceSource = true)]
        static void Exercice1_BoucleWhile()
        {
            int i = 1;
            while(i <= 5)
            {
                Console.WriteLine("ça tourne " + i);
                i++;
            }
        }

        [Exercice("Affichage de la boucle CaTourne")]
        static void Exercice1_3()
        {
            Console.Write("Choisir entre une boucle 'for' et 'while' pour lancer le programme : ");
            string boucle = Console.ReadLine().ToLower();

            switch(boucle)
            {
                case "for":
                    Exercice1_BoucleFor();
                    break;
                case "while":
                    Exercice1_BoucleWhile();
                    break;
                default:
                    Console.WriteLine("Type de boucle inconnu");
                    break;
            }
        }

        [Exercice(2, "Méthode 'double SurfCarre(double cote)'", exerciceSource = true)]
        static double SurfCarre(double cote)
        {
            return cote * cote;
        }

        [Exercice("Affichage surface d'un carré")]
        static void Exercice3()
        {
            Console.Write("Entrez le côté du carré : ");
            double cote = double.Parse(Console.ReadLine());

            if(cote > 0)
            {
                Console.WriteLine("Le carré de côté " + cote + " a pour surface " + SurfCarre(cote));
            } else
            {
                Console.WriteLine("Le côté doit être strictement positif !");
            }
        }

        [Exercice("4-1", "Méthode 'double SurfCercle(double rayon)'", exerciceSource = true)]
        static double SurfCercle(double rayon)
        {
            return Math.PI * rayon * rayon;
        }

        [Exercice("Affichage surface d'un cercle")]
        static void Exercice4_2()
        {
            Console.Write("Entrez le rayon du cercle : ");
            double rayon = double.Parse(Console.ReadLine());

            if (rayon > 0)
            {
                Console.WriteLine("Le cercle de rayon " + rayon + " a pour surface " + SurfCercle(rayon));
            }
            else
            {
                Console.WriteLine("Le rayon doit être strictement positif !");
            }
        }

        [Exercice("5-1", "Méthode 'double CoteCarre(double surface)'", exerciceSource = true)]
        static double CoteCarre(double surface)
        {
            return Math.Sqrt(surface);
        }

        [Exercice("Affichage côté d'un carré à partir de sa surface")]
        static void Exercice5_2()
        {
            Console.Write("Entrez la surface du carré : ");
            double surface = double.Parse(Console.ReadLine());

            if (surface > 0)
            {
                Console.WriteLine("Le carré de surface " + surface + " a pour côté " + CoteCarre(surface));
            }
            else
            {
                Console.WriteLine("La surface doit être strictement positive !");
            }
        }

        [Exercice("6-1", "Méthode 'double CarreCercleMemeSurface(double rayon)'", exerciceSource = true)]
        static double CarreCercleMemeSurface(double rayon)
        {
            return CoteCarre(SurfCercle(rayon));
        }

        [Exercice("Côté d'un carré de même surface qu'un cercle")]
        static void Exercice6_2()
        {
            Console.Write("Entrez le rayon du cercle : ");
            double rayon = double.Parse(Console.ReadLine());

            if (rayon > 0)
            {
                Console.WriteLine("Le cercle de rayon " + rayon + " a la même surface qu'un carré de côté " + CarreCercleMemeSurface(rayon));
            }
            else
            {
                Console.WriteLine("Le rayon doit être strictement positif !");
            }
        }

        [Exercice(7, "Méthode 'bool EstStrictementPositif(int valeur)'", exerciceSource = true)]
        static bool EstStrictementPositif(int valeur)
        {
            // même exercice que sur Schooding
            return valeur > 0;
        }

        [Exercice("Test automatique de positivité")]
        static void Exercice8_1()
        {
            for(int i = -10; i <= 10; i++)
            {
                Console.WriteLine("L'entier " + i + " est " + (EstStrictementPositif(i) ? "strictement positif." : "négatif ou nul."));
            }
        }

        [Exercice("Test manuel de positivité d'un entier")]
        static void Exercice8_2()
        {
            Console.Write("Entrez un nombre entier : ");
            int valeur = int.Parse(Console.ReadLine());

            Console.WriteLine("L'entier " + valeur + " est " + (EstStrictementPositif(valeur) ? "strictement positif." : "négatif ou nul."));
        }

        [Exercice("9-1", "Méthode 'int Max2(int a, int b)'", exerciceSource = true)]
        static int Max2(int a, int b)
        {
            /* On peut aussi avoir
            if(a > b)
            {
                return a;
            }
            else
            {
                return b;
            }*/

            return a > b ? a : b;
        }

        [Exercice("Maximum entre 2 entiers (définis dans le code)")]
        static void Exercice9_2()
        {
            int a = 8;
            int b = 15;

            Console.WriteLine("Le maximum entre " + a + " et " + b + " est " + Max2(a, b));
        }

        [Exercice(10, "Méthode 'int Max3(int a, int b, int c)'", exerciceSource = true)]
        static int Max3(int a, int b, int c)
        {
            /* On peut aussi avoir (cette version est plus lisible, mais l'autre est plus courte)
            if(a > b)
            {
                if(c > a)
                {
                    return c;
                }
                else
                {
                    return a;
                }
            }
            else
            {
                if(c > b)
                {
                    return c;
                }
                else
                {
                    return b;
                }
            }*/

            return a > b ? (c > a ? c : a) : (c > b ? c : b);
        }

        [Exercice("11-1", "Affichage du maximum entre 3 entiers", exerciceSource = true)]
        static void AfficheMax3(int a, int b, int c)
        {
            Console.WriteLine("Le maximum entre " + a + " ; " + b + " et " + c + " est " + Max3(a, b, c));
        }

        [Exercice("Maximum entre 3 entiers (automatique)")]
        static void Exercice11_2()
        {
            int minRandom = -100;
            int maxRandom = 100;

            Random random = new Random();
            int a = random.Next(minRandom, maxRandom);
            int b = random.Next(minRandom, maxRandom);
            int c = random.Next(minRandom, maxRandom);

            AfficheMax3(a, b, c);
        }

        [Exercice(12, "Méthode 'int Abs1(int n)'", exerciceSource = true)]
        static int Abs1(int n)
        {
            /* On peut aussi avoir
            if(n < 0)
            {
                n = -n;
            }
            
            return n;*/

            return n > 0 ? n : -n;
        }

        [Exercice("13-1", "Méthode 'int PosNeg(int a, int b)'", exerciceSource = true)]
        static int PosNeg(int a, int b)
        {
            /* On peut aussi avoir
            if(a == 0 || b == 0)
            {
                return 0;
            }
            else if(a < 0 ^ b < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }*/

            return (a == 0 || b == 0) ? 0 : (a < 0 ^ b < 0 ? -1 : 1); // ^ est l'opérateur XOR
            // le produit est négatif si l'un des 2 facteurs est négatif, mais pas si les 2 le sont
        }

        [Exercice("13-2", "Affichage du signe d'un produit de 2 entiers", exerciceSource = true)]
        static void TesterPosNeg(int a, int b)
        {
            int resultat = PosNeg(a, b);
            Console.Write("Sans effectuer le calcul, le produit de " + a + " et de " + b + " sera ");
            if(resultat == 0)
            {
                Console.WriteLine("nul.");
            } else if(resultat < 0)
            {
                Console.WriteLine("négatif.");
            } else
            {
                Console.WriteLine("positif.");
            }
        }

        [Exercice("Signe d'un produit d'entiers (automatique)")]
        static void Exercice13_3()
        {
            int minRandom = -100;
            int maxRandom = 100;

            Random random = new Random();
            int a = random.Next(minRandom, maxRandom);
            int b = random.Next(minRandom, maxRandom);

            TesterPosNeg(a, b);
        }

        [Exercice("Signe d'un produit d'entiers (manuel)")]
        static void Exercice13_4()
        {
            Console.Write("Entrez le premier facteur : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Entrez le deuxième facteur : ");
            int b = int.Parse(Console.ReadLine());

            TesterPosNeg(a, b);
        }

        [Exercice("14-1", "Méthode 'double MoyenneEntiers(int a, int b)'", exerciceSource = true)]
        static double MoyenneEntiers(int a, int b)
        {
            return (a + b) / 2d; // le d force le résultat à être un double
        }

        [Exercice("14-2", "Affichage de la moyenne de 2 entiers", exerciceSource = true)]
        static void TestMoyenne(int a, int b)
        {
            double moyenne = MoyenneEntiers(a, b);
            Console.WriteLine("La moyenne de " + a + " et de " + b + " est " + moyenne);
        }

        [Exercice("Moyenne de 2 entiers (automatique)")]
        static void Exercice14_3()
        {
            int minRandom = 0;
            int maxRandom = 20;

            Random random = new Random();
            int a = random.Next(minRandom, maxRandom);
            int b = random.Next(minRandom, maxRandom);

            TestMoyenne(a, b);
        }

        [Exercice("Moyenne de 2 entiers (manuelle)")]
        static void Exercice14_4()
        {
            Console.Write("Entrez le premier entier : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Entrez le deuxième entier : ");
            int b = int.Parse(Console.ReadLine());

            TestMoyenne(a, b);
        }

        [Exercice("15-1", "Calcul de la factorielle (boucle for)", exerciceSource = true)]
        static int Factorielle_BoucleFor(int n)
        {
            int f = 1;
            for(int i = 2; i < n; i++)
            {
                f *= i;
            }

            return f;
        }

        [Exercice("15-2", "Calcul de la factorielle (récursive)", exerciceSource = true)]
        static int Factorielle_Recursive(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factorielle_Recursive(n - 1);
            }

            // return n <= 1 ? 1 : n * Factorielle_Recursive(n - 1);
        }

        [Exercice("15-3", "Affichage de la factorielle d'un entier", exerciceSource = true)]
        static void TestFactorielle(int n)
        {
            int f1 = Factorielle_BoucleFor(n);
            Console.WriteLine("La factorielle de " + n + " est " + n + "! = " + f1);
        }

        [Exercice("Factorielle d'un entier donné")]
        static void Exercice15_4()
        {
            Console.Write("Entrez un nombre entier : ");
            int n = int.Parse(Console.ReadLine());

            TestFactorielle(n);
        }

        [Exercice("16-1", "Méthode 'int Puissance(int n1, int n2)'", exerciceSource = true)]
        static int Puissance(int n1, int n2)
        {
            // si n2 est négatif, il faudrait faire l'inverse, mais ici on a que des entiers, donc on va dire que c'est 0
            if (n2 <= 0) return 0;

            int resultat = 1;
            for(int i = 0; i < n2; i++)
            {
                resultat *= n1;
            }

            return resultat;
        }
    }
}
