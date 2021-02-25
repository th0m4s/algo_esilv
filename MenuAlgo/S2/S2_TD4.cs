using MenuAlgo;
using OutilsTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuAlgo
{
    public class S2_TD4
    {
        [Exercice("1-1", "Méthode 'bool[] CreerTasAllumettes(int taille)'", exerciceSource = true)]
        static bool[] CreerTasAllumettes(int taille)
        {
            if (taille < 0) return null;

            bool[] tab = new bool[taille];

            for(int i = 0; i < taille; i++)
            {
                tab[i] = true;
            }

            return tab;
        }

        [Exercice("1-2", "Méthode 'void AfficherTasAlumettes(bool[] tasAlumettes)'", exerciceSource = true)]
        static void AfficherTasAlumettes(bool[] tasAlumettes)
        {
            if (tasAlumettes == null || tasAlumettes.Length == 0) return;

            int tailleLigne = tasAlumettes.Length * 4 + 1;
            string ligne = S2_TD1.Repeter("-", tailleLigne);

            for(int i = 0; i < tasAlumettes.Length; i++)
            {
                Console.Write((i+1) < 10 ? "  " : " ");
                Console.Write((i+1) + " ");
            }

            Console.WriteLine("\n" + ligne);
            Console.Write("|");

            for(int i = 0; i < tasAlumettes.Length; i++)
            {
                Console.Write(" " + (tasAlumettes[i] ? "*" : " ") + " |");
            }

            Console.WriteLine("\n" + ligne);
        }

        [Exercice("2-1", "Méthode 'bool PositionValide(bool[] tableau, int index)'", exerciceSource = true)]
        static bool PositionValide(bool[] tableau, int index)
        {
            return tableau != null && index >= 0 && index < tableau.Length;
        }

        [Exercice("2-2", "Méthode ' bool RetirerUneAllumette(bool[] tasAllumettes, int index)'", exerciceSource = true)]
        static bool RetirerUneAllumette(bool[] tasAllumettes, int index)
        {
            bool res = false;

            if(PositionValide(tasAllumettes, index))
            {
                tasAllumettes[index] = false;
                res = true;
            }

            return res;
        }

        [Exercice("2-3", "Méthode 'int NombreAllumettesRestantes(bool[] tasAllumettes)'", exerciceSource = true)]
        static int NombreAllumettesRestantes(bool[] tasAllumettes)
        {
            int res = 0;

            if(tasAllumettes != null)
            {
                foreach(bool item in tasAllumettes)
                {
                    if(item)
                    {
                        res++;
                    }
                }
            }

            return res;
        }

        [Exercice("3-1", "Méthode 'int DemanderNombreAllumettesARetirer(int max)'", exerciceSource = true)]
        static int DemanderNombreAllumettesARetirer(int max)
        {
            int res = 0;

            while(res < 1 || res > max)
            {
                Console.Write("Combien d'allumettes voulez-vous retirer ? (entre 1 et " + max + " inclus) ");
                res = int.Parse(Console.ReadLine());
            }

            return res;
        }

        [Exercice("3-2", "Méthode 'bool PartieGagnee(bool[] tasAllumettes)'", exerciceSource = true)]
        static bool PartieGagnee(bool[] tasAllumettes)
        {
            return NombreAllumettesRestantes(tasAllumettes) == 1;
        }

        [Exercice("3-3", "Méthode 'bool PartiePerdue(bool[] tasAllumettes)'", exerciceSource = true)]
        static bool PartiePerdue(bool[] tasAllumettes)
        {
            return tasAllumettes != null && NombreAllumettesRestantes(tasAllumettes) == 0;
        }

        [Exercice("3-4", "Méthode 'bool FinPartie(bool[] tasAllumettes)'", exerciceSource = true)]
        static bool FinPartie(bool[] tasAllumettes)
        {
            return PartieGagnee(tasAllumettes) || PartiePerdue(tasAllumettes);
        }

        static void Exercice99()
        {
            bool[] allumettes = CreerTasAllumettes(12);

            allumettes[3] = false;
            allumettes[6] = false;
            allumettes[10] = false;

            AfficherTasAlumettes(allumettes);
        }
    }
}
