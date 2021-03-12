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
        [Exercice("0-1", "Méthode 'void EffacerDerniereLigne()'", exerciceSource = true)]
        public static void EffacerDerniereLigne()
        {
            int currentLineCursor = Console.CursorTop - 1;
            Console.SetCursorPosition(0, currentLineCursor);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, currentLineCursor);
        }

        [Exercice("1-1", "Méthode 'bool[] CreerTasAllumettes(int taille)'", exerciceSource = true)]
        static bool[] CreerTasAllumettes(int taille)
        {
            bool[] tab = null;

            if(taille >= 0)
            {
                tab = new bool[taille];

                for (int i = 0; i < taille; i++)
                {
                    tab[i] = true;
                }
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

            Console.WriteLine();
            while(res < 1 || res > max)
            {
                EffacerDerniereLigne();
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

        [Exercice("JEU COMPLET DES ALLUMETTES")]
        static void Exercice9_0()
        {
            bool[] allumettes = CreerTasAllumettes(12);

            int joueur = 0;
            string ligne = S2_TD1.Repeter("=", 36);

            while(!FinPartie(allumettes))
            {
                joueur = (joueur % 2) + 1;
                Console.WriteLine(ligne);
                Console.WriteLine("C'est au tour du joueur " + joueur + " de jouer !");
                Console.WriteLine(ligne + "\n");

                AfficherTasAlumettes(allumettes);
                Console.WriteLine();

                int count = DemanderNombreAllumettesARetirer(Math.Min(NombreAllumettesRestantes(allumettes), 3));

                for(int i = 0; i < count; i++)
                {
                    int pos = -1;
                    Console.WriteLine();
                    while(!PositionValide(allumettes, pos) || !allumettes[pos])
                    {
                        EffacerDerniereLigne();
                        Console.Write("A quel emplacement retirer l'allumette " + (i + 1) + " ? ");
                        pos = int.Parse(Console.ReadLine())-1;
                    }

                    RetirerUneAllumette(allumettes, pos);
                }

                Console.WriteLine("\n");
            }

            AfficherTasAlumettes(allumettes);
            Console.WriteLine("Le joueur " + joueur + " a " + (PartieGagnee(allumettes) ? "gagné !" : "perdu :(") + "\n");
        }

        [Exercice("JEU COMPLET AVEC REGLES SUPPLEMENTAIRES")]
        static void Exercice9_1()
        {
            int nbAllumettes = 0;
            Console.WriteLine();
            while(nbAllumettes < 3 || nbAllumettes > 20)
            {
                // 20 <=> limite arbitraire max
                EffacerDerniereLigne();
                Console.WriteLine("Combien d'allumettes utiliser ? (min 3) ");
                nbAllumettes = int.Parse(Console.ReadLine());
            }

            bool[] allumettes = CreerTasAllumettes(nbAllumettes);

            int joueur = 0;
            string ligne = S2_TD1.Repeter("=", 36);

            while (!FinPartie(allumettes))
            {
                joueur = (joueur % 2) + 1;
                Console.WriteLine(ligne);
                Console.WriteLine("C'est au tour du joueur " + joueur + " de jouer !");
                Console.WriteLine(ligne + "\n");

                AfficherTasAlumettes(allumettes);
                Console.WriteLine();

                int count = DemanderNombreAllumettesARetirer(Math.Min(NombreAllumettesRestantes(allumettes), 3));

                int lastPos = -1; // pour regarder si c'est consécutif
                for (int i = 0; i < count; i++)
                {
                    bool consecutif = true;
                    Console.WriteLine();
                    int pos = -1;
                    while (!PositionValide(allumettes, pos) || !allumettes[pos] || !consecutif)
                    {
                        EffacerDerniereLigne();
                        Console.Write("A quel emplacement retirer l'allumette " + (i + 1) + " ? ");
                        pos = int.Parse(Console.ReadLine()) - 1;
                        consecutif = true;

                        // si entre la pos et la lastPos on trouve une allumette, ce n'est pas consécutif
                        if (lastPos != -1) // car la 1re fois c'est toujours bon
                        {
                            for (int j = Math.Min(pos, lastPos) + 1; consecutif && j < Math.Max(pos, lastPos); j++)
                            {
                                if(allumettes[j])
                                {
                                    consecutif = false;
                                }
                            }
                        }
                    }

                    lastPos = pos;
                    RetirerUneAllumette(allumettes, pos);
                }

                Console.WriteLine("\n");
            }

            AfficherTasAlumettes(allumettes);
            Console.WriteLine("Le joueur " + joueur + " a " + (PartieGagnee(allumettes) ? "gagné !" : "perdu :(") + "\n");
        }
    }


}
