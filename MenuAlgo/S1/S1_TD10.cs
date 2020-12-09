using System;
using OutilsTD;

namespace MenuAlgo
{
    public class S1_TD10
    {
        [Exercice("Répétition de texte (boucle for)")]
        static void Exercice1_1()
        {
            for(int i = 1; i <= 20; i++)
            {
                Console.WriteLine("ça tourne : ligne " + i);
            }
        }

        [Exercice("Répétition de texte (boucle while)")]
        static void Exercice1_2()
        {
            int i = 1;
            while(i <= 20)
            {
                Console.WriteLine("ça tourne : ligne " + i);
                i++;
            }
        }

        [Exercice("Nombres de 10 à 20 (séparés par ' ')")]
        static void Exercice2()
        {
            for(int i = 10; i <= 20; i++)
            {
                Console.Write(i + " ");
            }
        }

        [Exercice("Nombres de 10 à 20 (séparés par ';')")]
        static void Exercice3()
        {
            for (int i = 10; i <= 20; i++)
            {
                Console.Write(i + (i < 20 ? " ; " : ""));
            }
        }

        [Exercice("Entiers pairs entre 20 et 40")]
        static void Exercice4()
        {
            for (int i = 20; i <= 40; i += 2)
            {
                Console.WriteLine(i);
            }
        }

        [Exercice("Entiers pairs entre 60 et 40")]
        static void Exercice5()
        {
            for (int i = 60; i >= 40; i -= 2)
            {
                Console.WriteLine(i);
            }
        }

        [Exercice("Somme d'entiers jusqu'à 100")]
        static void Exercice6()
        {
            int somme = 0;
            do
            {
                Console.Write("Entrez un nombre entier : ");
                somme += int.Parse(Console.ReadLine());
            } while (somme <= 100);

            Console.WriteLine("La somme est " + somme);
        }

        [Exercice("Plus grand parmi 2 entiers")]
        static void Exercice8()
        {
            Console.Write("Entrez un premier entier : ");
            int xx = int.Parse(Console.ReadLine());

            Console.Write("Entrez un deuxième entier : ");
            int yy = int.Parse(Console.ReadLine());

            if (xx == yy)
            {
                Console.WriteLine("Les nombres sont égaux et valent " + xx);
            }
            else if (xx > yy)
            {
                Console.WriteLine("Le nombre " + xx + " est plus grand que " + yy);
            }
            else
            {
                Console.WriteLine("Le nombre " + yy + " est plus grand que " + xx);
            }
        }

        [Exercice("Somme de 10 entiers")]
        static void Exercice10()
        {
            int somme = 0;
            for(int i = 0; i < 10; i++)
            {
                Console.Write("Saisis un entier : ");
                somme += int.Parse(Console.ReadLine());
            }

            Console.WriteLine("La somme est " + somme);
        }

        [Exercice("Premier nombre positif saisi")]
        static void Exercice11()
        {
            int nombre = 0;
            do
            {
                Console.Write("Entre un entier strictement positif : ");
                nombre = int.Parse(Console.ReadLine());
            } while (nombre <= 0);

            Console.WriteLine("Nombre saisi = " + nombre);
        }

        [Exercice("Somme jusqu'à 200 (test direct)")]
        static void Exercice12_1()
        {
            int somme = 0;
            while (somme <= 200)
            {
                Console.Write("Entrez un nombre entier : ");
                somme += int.Parse(Console.ReadLine());
            }

            Console.WriteLine("La somme est " + somme);
        }

        [Exercice("Somme jusqu'à 200 (variable booléene)")]
        static void Exercice12_2()
        {
            int somme = 0;
            bool fin = false;
            while (!fin)
            {
                Console.Write("Entrez un nombre entier : ");
                somme += int.Parse(Console.ReadLine());

                fin = somme > 200;
            }

            Console.WriteLine("La somme est " + somme);
        }

        [Exercice("Carrés jusqu'à 'fin' (boucle while)")]
        static void Exercice13()
        {
            while(true)
            {
                Console.Write("Entrez un nombre : ");
                string saisie = Console.ReadLine().ToLower();
                if (saisie == "fin")
                {
                    break;
                }

                int nombre = int.Parse(saisie);
                Console.WriteLine("Le carré de " + nombre + " est " + (nombre * nombre));
            }
        }

        [Exercice("Vérification de somme")]
        static void Exercice14()
        {
            Console.Write("Entre un premier nombre : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Entre un deuxième nombre : ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Entre la somme de ces 2 nombres : ");
            int s = int.Parse(Console.ReadLine());

            if (a + b == s)
            {
                Console.WriteLine("Gagné !");
            }
            else
            {
                Console.WriteLine("Retourne en primaire !");
            }
        }

        [Exercice("Nombres impairs entre 1 et 10")]
        static void Exercice15()
        {
            // normalement on met < dans un for, surtout  que là, la dernière valeur utile de i sera 9
            for(int i = 1; i <= 10; i++)
            {
                // on aura pu faire i += 2 au lieu du if
                if (i % 2 == 1)
                {
                    Console.Write(i + " ");
                }
            }
        }

        [Exercice("Multiples de 3 et 7 entre 0 et 100")]
        static void Exercice16()
        {
            for(int i = 0; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 7 == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }

        [Exercice("Entiers impairs divisibles par 3 ou 5 entre 0 et 10")]
        static void Exercice17()
        {
            for(int i = 1; i <= 10; i += 2)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }

        [Exercice("Notes minimum et maximum")]
        static void Exercice18()
        {
            Console.Write("Entrez le nombre d'élèves : ");
            int nombre = int.Parse(Console.ReadLine());

            if (nombre > 0)
            {
                int min = int.MaxValue;
                int max = int.MinValue;

                for(int i = 1; i <= nombre; i++)
                {
                    Console.Write("Saisir la note de l'élève " + i + " : ");
                    int note = int.Parse(Console.ReadLine());

                    if (note < min) min = note;
                    if (note > max) max = note;
                }

                Console.WriteLine("La note maximum est " + max);
                Console.WriteLine("La note minimum est " + min);
            } else Console.WriteLine("Le nombre de notes doit être strictement positif !");
        }

        [Exercice("Calcul du nombre d'or (boucle for)")]
        static void Exercice19_1()
        {
            Console.Write("Nombre d'itérations : ");
            int nombre = int.Parse(Console.ReadLine());

            if (nombre > 0)
            {
                double u1 = 1, u2 = 2;
                for(int i = 0; i < nombre; i++)
                {
                    double u = u1 + u2;
                    u1 = u2;
                    u2 = u;
                }

                Console.WriteLine("Le nombre d'or est approximativement " + (u2 / u1) + " (avec " + nombre + " itération" + (nombre > 1 ? "s" : "") + ")");
            } else Console.WriteLine("Le nombre d'itérations doit être strictement positif !");
        }

        [Exercice("Calcul du nombre d'or (boucle while)")]
        static void Exercice19_2()
        {
            Console.Write("Nombre d'itérations : ");
            int nombre = int.Parse(Console.ReadLine());

            if (nombre > 0)
            {
                double u1 = 1, u2 = 2;
                int i = 0;
                while(i < nombre)
                {
                    double u = u1 + u2;
                    u1 = u2;
                    u2 = u;

                    i++;
                }

                Console.WriteLine("Le nombre d'or est approximativement " + (u2 / u1) + " (avec " + nombre + " itération" + (nombre > 1 ? "s" : "") + ")");
            } else Console.WriteLine("Le nombre d'itérations doit être strictement positif !");
        }
    }
}
