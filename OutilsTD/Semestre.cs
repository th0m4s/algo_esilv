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
            this.annee = (int)Math.Ceiling(semestre/2f) + 1;
            this.semestre = semestre - (annee - 1) * 2; 
        }

        public Semestre(int annee, int semestre)
        {
            this.annee = annee;
            this.semestre = semestre;
        }

        public string Display()
        {
            return "ANNEE " + annee + " SEMESTRE " + semestre;
        }
    }
}
