using System;

namespace OutilsTD
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExerciceAttribute : Attribute
    {
        public int numeroExercice = -1;
        public string keyExercice = "";

        public string nomExercice;

        public bool exerciceSource = false;

        public ExerciceAttribute(int numeroExercice, string nomExercice)
        {
            this.numeroExercice = numeroExercice;
            this.nomExercice = nomExercice;
        }

        public ExerciceAttribute(string keyExercice, string nomExercice)
        {
            this.keyExercice = keyExercice;
            this.nomExercice = nomExercice;
        }

        public ExerciceAttribute(string nomExercice)
        {
            this.nomExercice = nomExercice;
        }
    }
}
