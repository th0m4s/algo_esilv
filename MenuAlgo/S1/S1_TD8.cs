using OutilsTD;
using System;

namespace MenuAlgo
{
    public class S1_TD8
    {
        [Exercice("Valeur absolue (sans Math.Abs())")]
        static void Exercice1_1()
        {
            Console.WriteLine("Saisir un nombre :");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n < 0)
            {
                n = -n;
            }

            Console.WriteLine("La valeur absolue est " + n);
        }

        [Exercice("Liste des carrés < 100")]
        static void Exercice2_2()
        {
            Console.WriteLine("Liste des carrés < 100");
            int n = 1;
            int carre = n * n;
            while (carre < 100)
            {
                Console.WriteLine(n + " au carré = " + carre);
                n = n + 1;
                carre = n * n;
            }
        }

        [Exercice("Liste des 9 premiers carrés")]
        static void Exercice3_2()
        {
            Console.WriteLine("Liste des carrés");
            for (int i = 1; i <= 9; i++)
            {
                int carre = i * i;
                Console.WriteLine(i + " au carré = " + carre);
            }
        }

        [Exercice("Factorielle")]
        static void Exercice4_1()
        {
            Console.Write("Saisir un nombre : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }

            Console.WriteLine("La factorielle de " + n + " est " + fact);
        }

        [Exercice("PGCD de 2 nombres")]
        static void Exercice4_2()
        {
            Console.Write("Saisir un premier nombre : ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Saisir un deuxième nombre : ");
            int b = Convert.ToInt32(Console.ReadLine());

            int ca = a, cb = b, t = 0;
            while (cb != 0)
            {
                t = cb;
                cb = ca % cb;
                ca = t;
            }

            Console.WriteLine("Le PGCD de " + a + " et de " + b + " est " + ca);
        }

        [Exercice("Division euclidienne")]
        static void Exercice4_3()
        {
            Console.Write("Saisir un premier nombre : ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Saisir un deuxième nombre : ");
            int b = Convert.ToInt32(Console.ReadLine());


            // Version rapide :)
            /*int q = a/b;
            int r = a - q*b;*/


            int ca = a, q = 0;
            while (ca > b)
            {
                ca -= b;
                q++;
            }
            int r = ca;


            Console.WriteLine("Pour la division euclidienne de " + a + " par " + b + ", q = " + q + " et r = " + r);
        }

        [Exercice("Test de primarité d'un nombre")]
        static void Exercice4_4()
        {
            Console.Write("Saisir un nombre : ");
            int n = Convert.ToInt32(Console.ReadLine());

            bool premier = true;
            // vu qu'il y a plein de cas possibles et que c'est mieux d'afficher à un seul endroit,
            // je stocke dans une variable la primarité de n

            if (n > 2)
            { // 2 est un cas spécial, c'est premier, donc je regarde d'abord si n > 2
              // ensuite je regarde si n est divisible par un nombre plus petit que n mais plus
              // grand que 1
                for (int i = 2; i <= Math.Floor(Math.Sqrt(n)); i++)
                {
                    if (n % i == 0)
                    {
                        premier = false;
                        // break sort du for, on sait que le nombre n'est pas premier
                        // on aurait pu faire un WriteLine puis un return pous arrêter la fonction
                        break;
                    }
                }
            }
            else if (n <= 1)
            {
                premier = false;
            }
            // si n == 2, premier reste à true, mais si n vaut 1, 0, ou si n est négatif,
            // alors ce n'est pas un nombre premier

            if (premier)
            {
                Console.WriteLine("Le nombre " + n + " est premier");
            }
            else
            {
                Console.WriteLine("Le nombre " + n + " n'est pas premier");
            }
        }
    }
}
