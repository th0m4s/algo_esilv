using System;
using System.Collections.Generic;
using System.Text;

namespace OutilsTD
{
    public class Semestre
    {
        int annee;
        int semestre;

        Dictionary<int, GestionTD> gestionsTD = new Dictionary<int, GestionTD>();

        public Semestre(int semestre)
        {
            this.annee = (int)Math.Ceiling(semestre/2f);
            this.semestre = semestre - (annee - 1) * 2; 
        }

        public Semestre(int annee, int semestre)
        {
            this.annee = annee;
            this.semestre = semestre;
        }

        public string Display(bool upperCase = false)
        {
            string display = "Année " + annee + " Semestre " + semestre;
            return upperCase ? display.ToUpper() : display;
        }

        public GestionTD GetGestionTD(int keyTD, Type classeTD)
        {
            if (!gestionsTD.ContainsKey(keyTD))
                gestionsTD[keyTD] = new GestionTD(this, keyTD, classeTD);

            return gestionsTD[keyTD];
        }
    }
}
