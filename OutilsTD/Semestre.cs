using System;
using System.Collections.Generic;
using System.Text;

namespace OutilsTD
{
    public class Semestre
    {
        int annee;
        int semestre;

        public Semestre(int semestre)
        {
            this.annee = (int)Math.Floor(semestre/2f) + 1;
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
    }
}
