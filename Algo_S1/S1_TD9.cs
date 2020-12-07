using OutilsTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoS1
{
    public class S1_TD9
    {
        static void Exercice1()
        {          
            Console.Write("Quel est votre âge ? ");
            int age = int.Parse(Console.ReadLine());

            if (age < 0)
                Console.WriteLine("L'âge ne peut pas être un nombre négatif !");
            else if (age < 25)
                Console.WriteLine("Salut gamin !");
            else if (age < 55)
                Console.WriteLine("Bonjour Monsieur/Madame.");
            else Console.WriteLine("Je te vénère, oh mon grand maître !");
        }

        static void Exercice2()
        {
            Console.Write("Quel est votre poids (en kg) ? ");
            int poids = int.Parse(Console.ReadLine());

            if (poids <= 0)
            {
                Console.WriteLine("Le poids doit être un entier positif !");
                return;
            }

            Console.Write("Quelle est votre taille (en cm) ? ");
            int taille = int.Parse(Console.ReadLine());

            if (taille <= 0)
            {
                Console.WriteLine("La taille doit être un entier positif !");
                return;
            }

            double imc = poids / Math.Pow(taille, 2);

            if (imc < 19)
                Console.WriteLine("Vous êtes maigre.");
            else if (imc < 26)
                Console.WriteLine("Votre IMC est normal.");
            else if (imc < 40)
                Console.WriteLine("Vous êtes en surpoids.");
            else Console.WriteLine("Vous êtes en fort surpoids.");
        }

        static void Exercice3()
        {
            Console.Write("Entrez un premier nombre : ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Entrez un deuxième nombre : ");
            double b = double.Parse(Console.ReadLine());

            if (a == b)
                Console.WriteLine("Les 2 nombres sont égaux et valent " + a);
            else if (a > b)
                Console.WriteLine("Le premier nombre est plus grand : " + a + " > " + b);
            else Console.WriteLine("Le deuxième nombre est plus grand : " + a + " < " + b);
        }

        static void Exercice4()
        {
            Console.Write("Entrez un nombre : ");
            double n = double.Parse(Console.ReadLine());

            double abs = n > 0 ? n : -n;
            Console.WriteLine("La valeur absolue de " + n + " est " + abs);
        }

        static void Exercice5()
        {
            Console.Write("Entrez la longueur d'un côté du carré : ");
            double cote = double.Parse(Console.ReadLine());

            if (cote <= 0)
            {
                Console.WriteLine("Le côté doit être positif !");
                return;
            }

            double aire = Math.Pow(cote, 2);
            Console.WriteLine("L'aire d'un carré de côté " + cote + " est de " + aire);
        }

        static void Exercice6()
        {
            Console.Write("Entrez la longueur du rectangle : ");
            double longueur = double.Parse(Console.ReadLine());

            if (longueur <= 0)
            {
                Console.WriteLine("La longueur doit être positive !");
                return;
            }

            Console.Write("Entrez la largeur du rectangle : ");
            double largeur = double.Parse(Console.ReadLine());

            if (largeur <= 0)
            {
                Console.WriteLine("La largeur doit être positive !");
                return;
            }

            double aire = longueur * largeur;
            Console.WriteLine("L'aire d'un rectangle de dimensions " + longueur + "x" + largeur + " est de " + aire);
        }

        static void Exercice7()
        {
            Console.Write("Entrez le rayon du cercle : ");
            double rayon = double.Parse(Console.ReadLine());

            if (rayon <= 0)
            {
                Console.WriteLine("Le rayon doit être positif !");
                return;
            }

            double aire = Math.Pow(rayon, 2) * Math.PI;
            Console.WriteLine("L'aire d'un cercle de rayon " + rayon + " est " + aire);
        }

        static void Exercice8()
        {
            Console.Write("Entrez le rayon du cercle : ");
            double rayon = double.Parse(Console.ReadLine());

            if (rayon <= 0)
            {
                Console.WriteLine("Le rayon doit être positif !");
                return;
            }

            double aire = Math.Pow(rayon, 2) * Math.PI;
            double cote = Math.Sqrt(aire);
            Console.WriteLine("Un cercle de rayon " + rayon + " a la même aire qu'un carré de côté " + cote);
        }

        static void Exercice9()
        {
            Console.Write("Entrez un premier nombre : ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Entrez un deuxième nombre : ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("a = " + a + " et b = " + b);

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("a = " + a + " et b = " + b);
        }

        static void Exercice10()
        {
            string syllabe = "bon";
            string mot = syllabe + syllabe;

            Console.WriteLine("Le mot est " + mot);
        }

        static void Exercice11()
        {
            Console.Write("Combien de fois voulez-vous répéter le mot ? ");
            int n = int.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("Le nombre doit être un entier supérieur ou égal à 1 !");
                return;
            }

            string mot = "ah";
            // string repetition = string.Join(" ", Enumerable.Repeat(mot, n).ToArray());
            string repetition = mot + " ";
            for (int i = 1; i < n; i++)
                repetition += " " + mot;

            Console.WriteLine(repetition);
        }

        static void Exercice12()
        {
            // La consigne demande des nombres entiers, mais il est possible de le faire avec des doubles

            Console.Write("Entrez un premier nombre : ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Entrez un deuxième nombre : ");
            int b = int.Parse(Console.ReadLine());

            double moyenne = (a + b) / 2d;
            Console.WriteLine("La moyenne de " + a + " et de " + b + " est " + moyenne);
        }

        static void Exercice13()
        {
            Console.Write("Entrez une température en °C : ");
            double c = double.Parse(Console.ReadLine());

            double f = 32 + c * 9 / 5;
            Console.WriteLine("La température en est de " + f + "°F");
        }

        public static void Main(GestionTD gestionTD)
        {
            gestionTD.AjouterExercices(Exercice1, Exercice2, Exercice3, Exercice4, Exercice5, Exercice6, Exercice7, Exercice8, Exercice9, Exercice10, Exercice11, Exercice12, Exercice13);
            gestionTD.MenuExercice();
        }
    }
}
