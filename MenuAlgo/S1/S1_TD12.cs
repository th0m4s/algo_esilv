using OutilsTD;
using System;

namespace MenuAlgo
{
    public class S1_TD12
    {
        [Exercice("Ecriture en toutes lettres d'un chiffre")]
        static void Exercice0()
        {
            Console.Write("Entrez un chiffre (0-9 inclus) : ");
            string input = Console.ReadLine();
            // je ne convertis pas input en int, car si on tape une mauvaise valeur, il n'y aura pas d'exception,
            // mais on affiche un message avec default dans le switch

            switch(input)
            {
                case "0":
                    Console.WriteLine("zéro");
                    break;
                case "1":
                    Console.WriteLine("un");
                    break;
                case "2":
                    Console.WriteLine("deux");
                    break;
                case "3":
                    Console.WriteLine("trois");
                    break;
                case "4":
                    Console.WriteLine("quatre");
                    break;
                case "5":
                    Console.WriteLine("cinq");
                    break;
                case "6":
                    Console.WriteLine("six");
                    break;
                case "7":
                    Console.WriteLine("sept");
                    break;
                case "8":
                    Console.WriteLine("huit");
                    break;
                case "9":
                    Console.WriteLine("neuf");
                    break;
                default:
                    Console.WriteLine("La valeur rentrée n'est pas un chiffre...");
                    break;
            }
        }

        [Exercice(1, "Méthode 'bool EstPremier(int n)'", exerciceSource = true)]
        public static bool EstPremier(int n)
        {
            bool premier = true;
            for(int i = 2; i < n; i+=2)
            {
                if(n % i == 0)
                {
                    premier = false;
                    break;
                }
            }

            return premier;
        }

        [Exercice("Primalité des entiers de 1 à 100")]
        static void Exercice2()
        {
            for(int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i + (EstPremier(i) ? " est" : " n'est pas") + " premier");
            }
        }

        [Exercice("Primalité d'entiers")]
        static void Exercice3()
        {
            Console.Write("Entrez une borne inférieure : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Entrez une borne supérieure : ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Voulez vous afficher les nombres premiers ? (true ou false) ");
            bool affiche = bool.Parse(Console.ReadLine());

            int compte = 0;
            for (int i = a; i <= b; i++)
            {
                compte++;
                if(affiche)
                {
                    Console.WriteLine(i + (EstPremier(i) ? " est" : " n'est pas") + " premier");
                }
            }

            Console.WriteLine("Entre " + a + " et " + b + ", il y a " + compte + " nombre(s) premier(s)");
        }

        [Exercice("4-1", "Méthode 'double Arrondi_2decimales_Troncature(double valeur)'", exerciceSource = true)]
        static double Arrondi_2decimales_Troncature(double valeur)
        {
            valeur = valeur * 100;
            int entier = (int)valeur;

            return entier / 100d;
        }

        [Exercice("Arrondi d'un nombre à 2 décimales par troncature")]
        public static void Exercice4_2()
        {
            Console.Write("Entrez un nombre : ");
            double valeur = double.Parse(Console.ReadLine());
            double arrondi = Arrondi_2decimales_Troncature(valeur);
            Console.WriteLine("L'arrondi à 2 décimales par troncature de " + valeur + " est " + arrondi);
        }

        [Exercice("5-1", "Méthode 'double Arrondi_2decimales_Proche(double value)'")]
        public static double Arrondi_2decimales_Proche(double value)
        {
            value = value * 100;
            int entier = (int)value;

            double resultat = entier / 100d;

            if(value - entier > 0.5d)
            {
                resultat += 0.01d;
            }

            return resultat;
        }

        [Exercice("Arrondi d'un nombre à 2 décimales au plus proche")]
        public static void Exercice5_2()
        {
            Console.Write("Entrez un nombre : ");
            double valeur = double.Parse(Console.ReadLine());
            double arrondi = Arrondi_2decimales_Proche(valeur);
            Console.WriteLine("L'arrondi à 2 décimales au plus proche de " + valeur + " est " + arrondi);
        }

        [Exercice(6, "Méthode 'double Arrondi_nDecimales(double value, int n)'", exerciceSource = true)]
        public static double Arrondi_nDecimales(double value, int n)
        {
            double puissance = Math.Pow(10, n);

            value = value * puissance;
            int entier = (int)value;

            double resultat = entier / puissance;

            if (value - entier > 0.5d)
            {
                resultat += 1/puissance;
            }

            return resultat;
        }

        [Exercice("7-1", "Méthode 'void AfficheTriangle(int n)'", exerciceSource = true)]
        public static void AfficheTriangle(int n)
        {
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }

                Console.WriteLine("");
            }
        }

        [Exercice("Afficher un triangle de nombres")]
        public static void Exercice7_2()
        {
            Console.Write("Entrez un nombre de ligne : ");
            int n = int.Parse(Console.ReadLine());

            AfficheTriangle(n);
        }

        [Exercice("Solutions d'une équation du 2nd degré")]
        public static void Exercice8()
        {
            Console.Write("Entrez le coefficient a : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Entrez le coefficient b : ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Entrez le coefficient c : ");
            int c = int.Parse(Console.ReadLine());

            double d = b * b - 4d * a * c;

            if(d < 0)
            {
                Console.WriteLine("Il n'existe pas de solutions réelles...");
            } else if(d == 0)
            {
                Console.WriteLine("L'unique solution est x = " + (-b / (2d * a)));
            } else
            {
                double x1 = (-b + Math.Sqrt(d)) / (2d * a);
                double x2 = (-b - Math.Sqrt(d)) / (2d * a);
                Console.WriteLine("Les 2 solutions sont " + x1 + " et " + x2);
            }
        }

        [Exercice("9-1", "Méthode 'void jeuNombreAleatoireIllimite()'", exerciceSource = true)]
        public static void jeuNombreAleatoireIllimite()
        {
            Random generateurAlea = new Random();
            int nombreAleatoire = generateurAlea.Next(1000); // 1000 est la limite, sinon on peut générer des nombres dans les milliards

            int coups = 0;
            while(true)
            {
                Console.Write("Entrez un nombre : ");
                int n = int.Parse(Console.ReadLine());

                coups++;

                if(n == nombreAleatoire)
                {
                    Console.WriteLine("Bravo, vous avez gagné en " + coups + " coup(s) !");
                    break;
                } else if(nombreAleatoire > n)
                {
                    Console.WriteLine("Le nombre est plus grand que " + n);
                } else
                {
                    Console.WriteLine("Le nombre est plus petit que " + n);
                }
            }
        }

        [Exercice("Jeu nombre aléatoire illimité")]
        public static void Exercice9_2()
        {
            jeuNombreAleatoireIllimite();
        }

        [Exercice("9-3", "Méthode 'void jeuNombreAleatoireLimite()'", exerciceSource = true)]
        public static void jeuNombreAleatoireLimite()
        {
            const int coupsMax = 11;

            Random generateurAlea = new Random();
            int nombreAleatoire = generateurAlea.Next(1000); // 1000 est la limite, sinon on peut générer des nombres dans les milliards

            int coups = 0;
            bool trouve = false;
            while (coups < coupsMax && !trouve)
            {
                Console.Write("Entrez un nombre : ");
                int n = int.Parse(Console.ReadLine());

                coups++;

                if (n == nombreAleatoire)
                {
                    trouve = true;
                }
                else if (nombreAleatoire > n)
                {
                    Console.WriteLine("Le nombre est plus grand que " + n);
                }
                else
                {
                    Console.WriteLine("Le nombre est plus petit que " + n);
                }
            }

            if(trouve)
            {
                Console.WriteLine("Bravo, vous avez gagné en " + coups + " coup(s) !");
            } else
            {
                Console.WriteLine("Vous avez perdu, le nombre était " + nombreAleatoire);
            }
        }

        [Exercice("Jeu nombre aléatoire avec limite")]
        public static void Exercice9_4()
        {
            jeuNombreAleatoireLimite();
        }

        [Exercice("10-1", "Méthode 'string InverseMot(string mot)'", exerciceSource = true)]
        public static string InverseMot(string mot)
        {
            string inverse = "";
            for(int i = mot.Length-1; i >= 0; i--)
            {
                inverse += mot[i];
            }

            return inverse;
        }

        [Exercice("Inverser un mot")]
        public static void Exercice10_2()
        {
            Console.Write("Entrez un mot à inverser : ");
            string mot = Console.ReadLine();
            string inverse = InverseMot(mot);
            Console.WriteLine("L'inverse de " + mot + " est " + inverse);
        }

        [Exercice("Afficher un carré")]
        public static void Exercice11()
        {
            int cote = 4;
            for(int i = 0; i < cote; i++)
            {
                for(int j = 0; j < cote; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        [Exercice("Afficher un triangle")]
        public static void Exercice12()
        {
            int hauteur = 4;
            for(int i = 0; i < hauteur; i++)
            {
                for(int j = 0; j < i+1; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        [Exercice(13, "Méthode 'string FabString(int n, char c)'", exerciceSource = true)]
        public static string FabString(int n, char c)
        {
            string resultat = "";

            for(int i = 0; i < n; i++)
            {
                resultat += c;
            }

            return resultat;
        }

        [Exercice("Afficher un carré V2")]
        public static void Exercice14()
        {
            int cote = 4;
            for (int i = 0; i < cote; i++)
            {
                Console.WriteLine(FabString(cote, '*'));
            }
        }

        [Exercice(100, "Méthode 'string FabString2(int n, string s)' pour le problème 2")]
        public static string FabString2(int n, string s)
        {
            // dans le problème 2, on veut des espaces entre les *, donc il faut mettre 2 caractères
            // à chaque fois, ce qui ne fonctionne pas un avec char (d'où le string)

            string resultat = "";

            for(int i = 0; i < n; i++)
            {
                resultat += s;
            }

            return resultat;
        }

        [Exercice("101", "Problème 1 : Calcul de PI via la méthode de Monte-Carlo")]
        public static void Probleme1()
        {
            Console.Write("Combien de points voulez vous générer ? ");
            int n = int.Parse(Console.ReadLine());

            int dedans = 0;

            Random generateurAlea = new Random();

            for (int i = 0; i < n; i++)
            {
                // l'énonce n'était pas clair, car les points doivent être dans [0, 1] mais le cercle à un rayon de 1, donc un diamètre de 2
                // j'ai donc choisi un cercle de diamètre 1 (rayon 0.5d) centré sur l'origine
                double x = generateurAlea.NextDouble() - 0.5d;
                double y = generateurAlea.NextDouble() - 0.5d;

                double distance = Math.Sqrt(x * x + y * y);
                if(distance < 0.5d) // la distance ne peut pas être 1 car 1 est exclus de x et y
                {
                    dedans++;
                }
            }


            if(n == 0)
            {
                Console.WriteLine("Veuillez entrer un nombre positif non nul de points.");
            } else
            {
                // le rapport dedans / n donne la surface
                // donc pi = surface / r²   (r² = 0.5d² = 0.25d)
                Console.WriteLine("PI est environ égal à " + ((double)dedans / n)/0.25d);
            }
        }

        [Exercice("102-0", "Méthode 'int u_n(int n)' pour le problème 2", exerciceSource = true)]
        public static int u_n(int n)
        {
            // pour le problème 2, il faut le nombre de point par ligne, ce qui s'apparente à une suite arithmétique de raison 2 et de premier terme u1 = 1
            return 1 + (n - 1) * 2;
        }

        [Exercice("102-1", "Problème 2.1 : Méthode 'void Prb2_AfficheTriangle(int hauteur)'", exerciceSource = true)]
        public static void Prb2_AfficheTriangle(int hauteur)
        {
            // pour centrer le texte, il faut connaitre le nombre de points sur la dernière ligne
            // on devrait la multipliée par 2 pour les espaces, mais comme on doit aussi la diviser par 2 plus bas
            // pour calculer les marges, on la laisse comme ça

            int largeur = u_n(hauteur);
            for(int i = 1; i <= hauteur; i++)
            {
                string ligne = FabString2(u_n(i), "* ");
                int marge = largeur - i * 2;

                Console.WriteLine(FabString2(marge, " ") + ligne);
            }
        }

        [Exercice("102-2", "Problème 2.2 : Méthode 'void Prb2_AfficheTrapeze(int debut, int hauteur)'", exerciceSource = true)]
        public static void Prb2_AfficheTrapeze(int debut, int hauteur)
        {
            int largeur = u_n(hauteur);
            for (int i = debut; i <= hauteur; i++)
            {
                string ligne = FabString2(u_n(i), "* ");
                int marge = largeur - i * 2;

                Console.WriteLine(FabString2(marge, " ") + ligne);
            }
        }

        [Exercice("102-3", "Probleme 2.3 : Afficher un sapin")]
        public static void Prb2_AfficherSapin()
        {
            Prb2_AfficheTriangle(5);
            Prb2_AfficheTrapeze(3, 5);
            Prb2_AfficheTrapeze(3, 5);
        }

        [Exercice("102-4", "Problème 2.4 : Afficher un sapin, une boule de Noël et un pied")]
        public static void Prb2_DecourEtSapin()
        {
            // comme il y a 5 points sur le sapin, on calcule à l'avance les marges
            int margeSimple = 7;
            int margeEpais = 5;

            // boule
            Console.WriteLine(FabString2(margeSimple, " ") + "*");
            Console.WriteLine(FabString2(margeEpais, " ") + FabString2(3, "* "));
            Console.WriteLine(FabString2(margeSimple, " ") + "*");

            // sapin
            Prb2_AfficherSapin();

            // pied
            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine(FabString2(margeEpais, " ") + FabString2(3, "* "));
            }
        }
    }
}
